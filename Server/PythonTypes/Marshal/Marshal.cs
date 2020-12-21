using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MySqlX.XDevAPI.Relational;
using PythonTypes.Compression;
using PythonTypes.Types.Database;
using PythonTypes.Types.Primitives;

namespace PythonTypes.Marshal
{
    /// <summary>
    /// Takes care of parsing marshalled data from the Python-side into C# objects that the
    /// project can use to process the input data
    /// </summary>
    public class Marshal
    {
        /// <summary>
        /// Separator for the PyObject's data
        /// </summary>
        public const byte PackedTerminator = 0x2D;

        /// <summary>
        /// Converts the given <paramref name="data" /> python type into a byte stream
        /// </summary>
        /// <param name="data">The Python type to convert into a byte stream</param>
        /// <param name="writeHeader">Whether the Marshal header has to be written or not</param>
        /// <returns>The full object converted into a byte stream</returns>
        public static byte[] ToByteArray(PyDataType data, bool writeHeader = true)
        {
            MemoryStream stream = new MemoryStream();

            WriteToStream(stream, data, writeHeader);

            return stream.ToArray();
        }

        /// <summary>
        /// Converts the given <paramref name="data" /> python type into a byte stream and writes it to <paramref name="stream" />
        /// </summary>
        /// <param name="stream">The stream to write the byte data into</param>
        /// <param name="data">The Python type to convert into a byte stream</param>
        /// <param name="writeHeader">Whether the Marshal header has to be written or not</param>
        /// <returns>The full object converted into a byte stream</returns>
        public static void WriteToStream(Stream stream, PyDataType data, bool writeHeader = true)
        {
            BinaryWriter writer = new BinaryWriter(stream);

            if (writeHeader)
            {
                // write the marshal magic header
                writer.Write(Specification.MarshalHeader);
                // save-list isn't supported yet in the marshal (and will likely never be)
                writer.Write(0);
            }

            Process(writer, data);
        }

        /// <summary>
        /// Processes the given <paramref name="data" /> python type and writes it's byte stream equivalent into.
        /// Every Python object converted must write the opcode in front as this is how it's identified on unmarshal
        /// <paramref name="writer" />
        /// </summary>
        /// <param name="writer">The writer were to write the data to</param>
        /// <param name="data">The python object to convert</param>
        /// <exception cref="InvalidDataException">If an unknow python data type is detected</exception>
        private static void Process(BinaryWriter writer, PyDataType data)
        {
            if (data == null || data is PyNone)
                ProcessNone(writer);
            else if (data is PyInteger pyInteger)
                ProcessInteger(writer, pyInteger);
            else if (data is PyDecimal pyDecimal)
                ProcessDecimal(writer, pyDecimal);
            else if (data is PyToken pyToken)
                ProcessToken(writer, pyToken);
            else if (data is PyBool pyBool)
                ProcessBool(writer, pyBool);
            else if (data is PyBuffer pyBuffer)
                ProcessBuffer(writer, pyBuffer);
            else if (data is PyDictionary pyDictionary)
                ProcessDictionary(writer, pyDictionary);
            else if (data is PyList pyList)
                ProcessList(writer, pyList);
            else if (data is PyObjectData pyObjectData)
                ProcessObjectData(writer, pyObjectData);
            else if (data is PyObject pyObject)
                ProcessObject(writer, pyObject);
            else if (data is PyString pyString)
                ProcessString(writer, pyString);
            else if (data is PySubStream pySubStream)
                ProcessSubStream(writer, pySubStream);
            else if (data is PyChecksumedStream pyChecksumedStream)
                ProcessChecksumedStream(writer, pyChecksumedStream);
            else if (data is PySubStruct pySubStruct)
                ProcessSubStruct(writer, pySubStruct);
            else if (data is PyTuple pyTuple)
                ProcessTuple(writer, pyTuple);
            else if (data is PyPackedRow pyPackedRow)
                ProcessPackedRow(writer, pyPackedRow);
            else
                throw new InvalidDataException($"Unexpected type {data.GetType()}");
        }

        /// <summary>
        /// Converts the given <paramref name="data"/> to it's byte array representation.
        /// Integers are encoded based on their value, which determines it's size in the byte stream
        ///
        /// The following opcodes are supported
        /// <seealso cref="Opcode.IntegerOne" /> 1 byte, value = 1
        /// <seealso cref="Opcode.IntegerZero" /> 1 byte, value = 0
        /// <seealso cref="Opcode.IntegerMinusOne" /> 1 byte, value = -1
        /// <seealso cref="Opcode.IntegerByte" /> 2 bytes, value is one byte after the opcode, signed byte
        /// <seealso cref="Opcode.IntegerSignedShort" /> 3 bytes, value is two bytes after the opcode, signed short
        /// <seealso cref="Opcode.IntegerLong" /> 5 bytes, value is four bytes after the opcode, signed integer
        /// <seealso cref="Opcode.IntegerLongLong" /> 9 bytes, value is eight bytes after the opcode, signed long
        /// </summary>
        /// <param name="writer">Where to write the encoded data to</param>
        /// <param name="data">The value to write</param>
        private static void ProcessInteger(BinaryWriter writer, PyInteger data)
        {
            if (data == 1)
                writer.WriteOpcode(Opcode.IntegerOne);
            else if (data == 0)
                writer.WriteOpcode(Opcode.IntegerZero);
            else if (data == -1)
                writer.WriteOpcode(Opcode.IntegerMinusOne);
            else if (data < sbyte.MaxValue)
            {
                writer.WriteOpcode(Opcode.IntegerByte);
                writer.Write((byte) data.Value);
            }
            else if (data < short.MaxValue)
            {
                writer.WriteOpcode(Opcode.IntegerSignedShort);
                writer.Write((short) data.Value);
            }
            else if (data < int.MaxValue)
            {
                writer.WriteOpcode(Opcode.IntegerLong);
                writer.Write((int) data.Value);
            }
            else
            {
                writer.WriteOpcode(Opcode.IntegerLongLong);
                writer.Write(data.Value);
            }
        }

        /// <summary>
        /// Converts the given <paramref name="data"/> to it's byte array representation.
        /// Decimals are encoded based on their value
        ///
        /// The following opcodes are supported
        /// <seealso cref="Opcode.RealZero" /> 1 byte, value = 0.0
        /// <seealso cref="Opcode.Real" /> 9 bytes, value is eight bytes after the opcode, double
        /// </summary>
        /// <param name="writer">Where to write the encoded data to</param>
        /// <param name="data">The value to write</param>
        private static void ProcessDecimal(BinaryWriter writer, PyDecimal data)
        {
            if (data == 0.0)
                writer.WriteOpcode(Opcode.RealZero);
            else
            {
                writer.WriteOpcode(Opcode.Real);
                writer.Write(data.Value);
            }
        }

        /// <summary>
        /// Converts the given <paramref name="data"/> to it's byte array representation.
        /// Tokens are basic ASCII strings with a variable length up to 255 bytes
        ///
        /// The following opcodes are supported
        /// <seealso cref="Opcode.Token" /> 2 bytes minimum, the string data comes right after the length indicator
        /// </summary>
        /// <param name="writer">Where to write the encoded data to</param>
        /// <param name="data">The value to write</param>
        private static void ProcessToken(BinaryWriter writer, PyToken token)
        {
            writer.WriteOpcode(Opcode.Token);
            writer.Write((byte) token.Token.Length);
            writer.Write(Encoding.ASCII.GetBytes(token));
        }

        /// <summary>
        /// Converts the given <paramref name="data"/> to it's byte array representation.
        /// Booleans are encoded to their specific opcode as they only have two possible values
        ///
        /// The following opcodes are supported
        /// <seealso cref="Opcode.BoolTrue" /> 1 byte, value = true
        /// <seealso cref="Opcode.BoolFalse" /> 1 byte, value = false
        /// </summary>
        /// <param name="writer">Where to write the encoded data to</param>
        /// <param name="data">The value to write</param>
        private static void ProcessBool(BinaryWriter writer, PyBool boolean)
        {
            if (boolean)
                writer.WriteOpcode(Opcode.BoolTrue);
            else
                writer.WriteOpcode(Opcode.BoolFalse);
        }

        /// <summary>
        /// Converts the given <paramref name="data"/> to it's byte array representation.
        /// Buffer are basic, binary byte arrays that do not follow any specific format
        /// Their length is variable and is indicated by an extended size indicator
        ///
        /// The following opcodes are supported
        /// <seealso cref="Opcode.Buffer" /> 2 bytes minimum, the data comes right after the length indicator
        /// </summary>
        /// <param name="writer">Where to write the encoded data to</param>
        /// <param name="buffer">The value to write</param>
        private static void ProcessBuffer(BinaryWriter writer, PyBuffer buffer)
        {
            writer.WriteOpcode(Opcode.Buffer);
            writer.WriteSizeEx(buffer.Value.Length);
            writer.Write(buffer);
        }

        /// <summary>
        /// Converts the given <paramref name="data"/> to it's byte array representation.
        /// Dictionaries are complex, massive objects that encode other python objects
        /// Uses extended size indicator to specify the amount of key-value pairs available
        ///
        /// The following opcodes are supported
        /// <seealso cref="Opcode.Dictionary" /> 2 bytes minimum, extended size indicator, values are encoded as value-key values in python types
        /// </summary>
        /// <param name="writer">Where to write the encoded data to</param>
        /// <param name="dictionary">The value to write</param>
        private static void ProcessDictionary(BinaryWriter writer, PyDictionary dictionary)
        {
            writer.WriteOpcode(Opcode.Dictionary);
            writer.WriteSizeEx(dictionary.Length);

            foreach (KeyValuePair<PyDataType, PyDataType> pair in dictionary)
            {
                Process(writer, pair.Value);
                Process(writer, pair.Key);
            }
        }

        /// <summary>
        /// Converts the given <paramref name="data"/> to it's byte array representation.
        /// Lists are a bit simpler than dictionaries, the opcode can indicate the length of the list, and there is also
        /// support for extended size indicatos 
        ///
        /// The following opcodes are supported
        /// <seealso cref="Opcode.ListEmpty" /> 2 byte, no elements
        /// <seealso cref="Opcode.ListOne" /> 1 byte + encoded python element
        /// <seealso cref="Opcode.List" /> 1 byte + extended size indicator + python elements encoded
        /// </summary>
        /// <param name="writer">Where to write the encoded data to</param>
        /// <param name="list">The value to write</param>
        private static void ProcessList(BinaryWriter writer, PyList list)
        {
            if (list.Count == 0)
                writer.WriteOpcode(Opcode.ListEmpty);
            else if (list.Count == 1)
            {
                writer.WriteOpcode(Opcode.ListOne);
                Process(writer, list[0]);
            }
            else
            {
                writer.WriteOpcode(Opcode.List);
                writer.WriteSizeEx(list.Count);

                foreach (PyDataType entry in list)
                    Process(writer, entry);
            }
        }

        /// <summary>
        /// Converts the given <paramref name="data"/> to it's byte array representation.
        /// ObjectData are simple representations of Python objects.
        /// These objects are composed by one python string that indicates the type of the object (it's name)
        /// and an argument object that can be any kind of Python type
        ///
        /// The following opcodes are supported
        /// <seealso cref="Opcode.ObjectData" />
        /// </summary>
        /// <param name="writer">Where to write the encoded data to</param>
        /// <param name="data">The value to write</param>
        private static void ProcessObjectData(BinaryWriter writer, PyObjectData data)
        {
            writer.WriteOpcode(Opcode.ObjectData);
            Process(writer, data.Name);
            Process(writer, data.Arguments);
        }

        /// <summary>
        /// Nones are kind of special types that indicate No data
        ///
        /// The following opcodes are supported
        /// <seealso cref="Opcode.None" />
        /// </summary>
        /// <param name="writer">Where to write the encoded data to</param>
        private static void ProcessNone(BinaryWriter writer)
        {
            writer.WriteOpcode(Opcode.None);
        }

        /// <summary>
        /// Converts the given <paramref name="data"/> to it's byte array representation.
        /// Python Objects are a more flexible representation of actual class instances (similar to ObjectData)
        /// There are two types of Objects the marshal supports but both have almost the same structure, only varying
        /// on how the header data is created.  
        ///
        /// Both types have a Tuple as header, a list of items and a dictionary of items. The list and dictionary of items
        /// do not have any kind of size indication, instead their ends are marked by a specific flag <see cref="PackedTerminator"/>
        /// and they are encoded one after the other. The Header, List elements and Dictionary elements are normal python types
        /// so anything can be inside them.
        ///
        /// The list elements are encoded one after the other.
        /// The dictionary follows the same principle, each key-value pair is encoded one after the other, in this case
        /// the key is encoded first and the value after it
        /// 
        /// The following opcodes are supported
        /// <seealso cref="Opcode.Type1" />
        /// <seealso cref="Opcode.Type2" />
        /// </summary>
        /// <param name="writer">Where to write the encoded data to</param>
        /// <param name="data">The value to write</param>
        private static void ProcessObject(BinaryWriter writer, PyObject data)
        {
            if (data.IsType2 == true)
                writer.WriteOpcode(Opcode.ObjectType2);
            else
                writer.WriteOpcode(Opcode.ObjectType1);

            Process(writer, data.Header);

            if (data.List.Count > 0)
            {
                foreach (PyDataType entry in data.List)
                    Process(writer, entry);
            }

            writer.Write(PackedTerminator);

            if (data.Dictionary.Length > 0)
            {
                foreach (KeyValuePair<PyDataType, PyDataType> entry in data.Dictionary)
                {
                    Process(writer, entry.Key);
                    Process(writer, entry.Value);
                }
            }

            writer.Write(PackedTerminator);
        }

        /// <summary>
        /// Converts the given <paramref name="data"/> to it's byte array representation.
        /// There are different types of strings available in Python, normal (ASCII) strings, UTF8 Strings and
        /// Unicode strings (WStrings) with their corresponding opcodes. As an extra mechanism, a table of strings
        /// with commonly-used strings are also supported to minimize the length of the game packets.
        ///
        /// The following opcodes are supported
        /// <seealso cref="Opcode.StringEmpty" /> 1 byte, Empty, ascii string
        /// <seealso cref="Opcode.WStringEmpty" /> 1 byte, Empty, WString
        /// <seealso cref="Opcode.StringChar" /> 2 bytes, One-character string
        /// <seealso cref="Opcode.StringTable" /> 2 bytes, string table entry, the index starts on 1 instead of 0
        /// <seealso cref="Opcode.WStringUTF8" /> More than 2 bytes, contains an extended size indicator for the string length + the bytes that compose the string
        /// <seealso cref="Opcode.StringLong" /> More than 2 bytes, contains an extended size indicator for the string length + the bytes that compose the string
        ///
        /// There are some more available opcodes for string representation, but they are not really needed by the server as most strings will be
        /// UTF8 encoded, with only a few cases of non-UTF8-encoded strings
        /// </summary>
        /// <param name="writer">Where to write the encoded data to</param>
        /// <param name="data">The value to write</param>
        private static void ProcessString(BinaryWriter writer, PyString data)
        {
            if (data.Length == 0)
                writer.WriteOpcode(Opcode.WStringEmpty);
            else if (data.Length == 1)
            {
                writer.WriteOpcode(Opcode.StringChar);
                writer.Write(Encoding.ASCII.GetBytes(data)[0]);
            }
            else if (data.IsStringTableEntry)
            {
                writer.WriteOpcode(Opcode.StringTable);
                writer.Write(((byte) data.StringTableEntryIndex) + 1);
            }
            else if (data.IsUTF8)
            {
                byte[] str = Encoding.UTF8.GetBytes(data.Value);
                writer.WriteOpcode(Opcode.WStringUTF8);
                writer.WriteSizeEx(str.Length);
                writer.Write(str);
            }
            else
            {
                // TODO: ON SOME SITUATIONS A NORMAL STRING IS EXPECTED, PROVIDE A MECHANISM TO FORCE MARSHALING SUPPORT
                writer.WriteOpcode(Opcode.StringLong);
                writer.WriteSizeEx(data.Length);
                // writer.Write(Encoding.UTF8.GetBytes(data.Value));
                writer.Write(Encoding.ASCII.GetBytes(data.Value));
            }
        }

        /// <summary>
        /// Converts the given <paramref name="data"/> to it's byte array representation.
        /// A kind of object container without much usefulness, it just contains another python type in it and is prefixed
        /// by an extended size indicator. This is commonly used by EVE as the request body of a CallReq packet, and
        /// after some investigation looks like it might not be decoded by the proxy at all, just forwarded as is to the
        /// node the packet is destinated to, thus saving processing power on the node.
        ///
        /// TODO: CHECK IF THIS HYPOTHETICAL SITUATION IS REALLY WHAT'S GOING ON OR NOT (AND IF THE WHOLE PACKET IS ACTUALLY SENT OR JUST THE SUBSTREAM
        ///
        /// The following opcodes are supported
        /// <seealso cref="Opcode.SubStream" /> 2 bytes minimum, extended size indicator, data is encoded as a normal Marshal
        /// string with header and save lists
        /// </summary>
        /// <param name="writer">Where to write the encoded data to</param>
        /// <param name="data">The value to write</param>
        private static void ProcessSubStream(BinaryWriter writer, PySubStream data)
        {
            byte[] buffer = ToByteArray(data.Stream);

            writer.WriteOpcode(Opcode.SubStream);
            writer.WriteSizeEx(buffer.Length);
            writer.Write(buffer);
        }

        /// <summary>
        /// Converts the given <paramref name="data"/> to it's byte array representation.
        /// The ChecksumedStream is on the same situation as <seealso cref="ProcessSubStream"/> the only difference
        /// is that instead of an extended size indicator there is only a checksum of the data in the stream 
        ///
        /// The following opcodes are supported
        /// <seealso cref="Opcode.ChecksumedStream" /> 5 bytes minimum, Adler32 checksum, data is encoded as a normal Marshal string
        /// with header and save lists included
        /// </summary>
        /// <param name="writer">Where to write the encoded data to</param>
        /// <param name="data">The value to write</param>
        private static void ProcessChecksumedStream(BinaryWriter writer, PyChecksumedStream data)
        {
            byte[] buffer = ToByteArray(data.Data, false);

            uint checksum = Adler32.Checksum(buffer);

            writer.WriteOpcode(Opcode.ChecksumedStream);
            writer.Write(checksum);
            writer.Write(buffer);
        }

        /// <summary>
        /// Converts the given <paramref name="data"/> to it's byte array representation.
        /// Structs are some kind of container used to store other python objects. Each substruct only supports one element
        /// in it's definition.
        ///
        /// The following opcodes are supported
        /// <seealso cref="Opcode.SubStruct" /> 1 byte + encoded python type
        /// </summary>
        /// <param name="writer">Where to write the encoded data to</param>
        /// <param name="data">The value to write</param>
        private static void ProcessSubStruct(BinaryWriter writer, PySubStruct data)
        {
            writer.WriteOpcode(Opcode.SubStruct);
            Process(writer, data.Definition);
        }

        /// <summary>
        /// Converts the given <paramref name="data"/> to it's byte array representation.
        /// Tuples are a special kind of container, they do not grow automatically, could be seen as simple, static lists
        ///
        /// The following opcodes are supported
        /// <seealso cref="Opcode.TupleEmpty" /> 1 byte, empty tuple
        /// <seealso cref="Opcode.TupleOne" /> 1 byte + encoded python type
        /// <seealso cref="Opcode.TupleTwo"/> 1 byte + two encoded python types without any separator
        /// <seealso cref="Opcode.Tuple" /> 2 bytes minimun, contains an extended size indicator with the size of the
        /// tuple, all the elements are encoded after without any kind of separator
        /// </summary>
        /// <param name="writer">Where to write the encoded data to</param>
        /// <param name="tuple">The value to write</param>
        private static void ProcessTuple(BinaryWriter writer, PyTuple tuple)
        {
            if (tuple.Count == 0)
                writer.WriteOpcode(Opcode.TupleEmpty);
            else if (tuple.Count == 1)
                writer.WriteOpcode(Opcode.TupleOne);
            else if (tuple.Count == 2)
                writer.WriteOpcode(Opcode.TupleTwo);
            else
            {
                writer.WriteOpcode(Opcode.Tuple);
                writer.WriteSizeEx(tuple.Count);
            }

            foreach (PyDataType entry in tuple)
                Process(writer, entry);
        }

        /// <summary>
        /// Converts the given <paramref name="data"/> to it's byte array representation.
        /// Packed rows are the big elephant in the room. These are a direct representation of a row in any of the tables
        /// the server has and are composed of 3 parts.
        ///
        /// The first is the header that contains information about the columns that the PackedRow has data for.
        /// This header is known as <see cref="DBRowDescriptor" /> which is composed of a tuple with a string (column name)
        /// and an integer (column type). The column order doesn't matter on the header.
        ///
        /// The second part is the compressible bit data. Contains part of the actual data in the row. The columns are sorted
        /// by bit size in descending order, this way the amount of zeros one after the another is kept to a minimum, allowing
        /// the zero compression algorithm (<see cref="ZeroCompressionUtils" />) to greatly reduce the size of this data.
        /// Strings are not encoded here and are part of the third section of the PackedRow.
        /// The 1-bit sized columns (booleans) are encoded a bit differently from the rest of the data. Once the multi-bit
        /// sized data is written (long, int, short, byte) the bool values are grouped into 1 byte chunks, storing up to 8 booleans
        /// in each byte. The booleans are added to the byte from right to left and the byte blocks are written one after the other.
        /// These resources might be useful to better understand this operation
        /// https://stackoverflow.com/questions/36829860/using-binary-to-compress-boolean-array
        /// https://en.wikipedia.org/wiki/Bit_array
        /// https://sakai.rutgers.edu/wiki/site/e07619c5-a492-4ebe-8771-179dfe450ae4/bit-to-boolean%20conversion.html
        ///
        /// The third and last section contains the byte arrays and strings. These are encoded as normal python types
        /// after the second part.
        ///
        /// The following opcodes are supported
        /// <seealso cref="Opcode.PackedRow" /> 
        /// </summary>
        /// <param name="writer">Where to write the encoded data to</param>
        /// <param name="packedRow">The value to write</param>
        private static void ProcessPackedRow(BinaryWriter writer, PyPackedRow packedRow)
        {
            writer.WriteOpcode(Opcode.PackedRow);
            Process(writer, packedRow.Header);

            // prepare the zero-compression stream
            MemoryStream wholeByteStream = new MemoryStream();
            MemoryStream bitPacketStream = new MemoryStream();
            MemoryStream objectStream = new MemoryStream();

            BinaryWriter wholeByteWriter = new BinaryWriter(wholeByteStream);
            BinaryWriter bitPacketWriter = new BinaryWriter(bitPacketStream);
            BinaryWriter objectWriter = new BinaryWriter(objectStream);

            // sort the columns by size
            IOrderedEnumerable<DBRowDescriptor.Column> enumerator = packedRow.Header.Columns.OrderByDescending(c => Utils.GetTypeBits(c.Type));
            byte bitOffset = 0;
            byte toWrite = 0;

            foreach (DBRowDescriptor.Column column in enumerator)
            {
                PyDataType value = packedRow[column.Name];
                
                switch (column.Type)
                {
                    case FieldType.I8:
                    case FieldType.UI8:
                    case FieldType.CY:
                    case FieldType.FileTime:
                        wholeByteWriter.Write((long) (value as PyInteger ?? 0));
                        break;

                    case FieldType.I4:
                    case FieldType.UI4:
                        wholeByteWriter.Write((int) (value as PyInteger ?? 0));
                        break;

                    case FieldType.I2:
                    case FieldType.UI2:
                        wholeByteWriter.Write((short) (value as PyInteger ?? 0));
                        break;

                    case FieldType.I1:
                    case FieldType.UI1:
                        wholeByteWriter.Write((byte) (value as PyInteger ?? 0));
                        break;

                    case FieldType.R8:
                        wholeByteWriter.Write((double) (value as PyDecimal ?? 0));
                        break;

                    case FieldType.R4:
                        wholeByteWriter.Write((float) (value as PyDecimal ?? 0));
                        break;

                    // bools, bytes and str are handled differently
                    case FieldType.Bool:
                        if (value as PyBool)
                            // bytes are written from right to left in the buffer
                            toWrite |= (byte) (1 << bitOffset);

                        bitOffset++;

                        if (bitOffset > 7)
                        {
                            // byte is full, write the byte to the stream
                            bitPacketWriter.Write(toWrite);
                            // reset the byte to keep using it as buffer
                            toWrite = 0;
                            // do the same for the next bit offset
                            bitOffset = 0;
                        }

                        break;

                    case FieldType.Bytes:
                    case FieldType.Str:
                    case FieldType.WStr:
                        // write the object to the proper memory stream
                        Process(objectWriter, packedRow[column.Name]);
                        break;

                    default:
                        throw new Exception($"Unknown field type {column.Type}");
                }
            }

            // after the column loop is done there might be some leftover compressed bits
            // that have to be written to the bit stream too
            if (bitOffset > 0)
                bitPacketWriter.Write(toWrite);

            // append the bitStream to the to the wholeByteWriter
            bitPacketStream.WriteTo(wholeByteStream);
            // create a reader for the stream
            wholeByteStream.Seek(0, SeekOrigin.Begin);
            // create the reader used to compress the buffer
            BinaryReader reader = new BinaryReader(wholeByteStream);
            // finally compress the data into the output
            ZeroCompressionUtils.ZeroCompress(reader, writer);
            // as last step write the encoded objects after the packed data
            objectStream.WriteTo(writer.BaseStream);
        }
    }
}