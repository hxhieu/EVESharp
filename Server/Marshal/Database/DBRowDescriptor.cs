﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.Types;
using MySql.Data.MySqlClient;

namespace Marshal.Database
{
    public class DBRowDescriptor : PyObjectEx_Type1
    {
        public PyTuple ColumnList
        {
            get
            {
                return Args[0] as PyTuple;
            }
        }

        public int ColumnCount
        {
            get
            {
                return ColumnList.Items.Count;
            }
        }

        public DBRowDescriptor()
            : base(new PyToken("blue.DBRowDescriptor"), CreateArgs())
        {
        }

        public DBRowDescriptor(ref MySqlDataReader res)
            : base(new PyToken("blue.DBRowDescriptor"), CreateArgs())
        {
            int column = res.FieldCount;

            for (int i = 0; i < column; i++)
            {
                AddColumn(res.GetName(i), this.GetType(i, ref res));
            }
        }

        public void AddColumn(string name, FieldType type)
        {
            PyTuple column = new PyTuple();

            column.Items.Add(new PyString(name));
            column.Items.Add(new PyInt((int)type));

            ColumnList.Items.Add(column);
        }

        public PyString GetColumnName(int index)
        {
            return ColumnList[index].As<PyTuple>().Items[0].As<PyString>();
        }

        public FieldType GetColumnType(int index)
        {
            return (FieldType)ColumnList[index].As<PyTuple>().Items[1].As<PyInt>().Value;
        }

        public int FindColumn(string name)
        {
            int cc = ColumnCount;
            PyString stringName = new PyString(name);

            for (int i = 0; i < cc; i++)
            {
                if (stringName == GetColumnName(i))
                {
                    return i;
                }
            }

            return cc;
        }

        public PyTuple GetColumn(int index)
        {
            return ColumnList[index] as PyTuple;
        }

        public FieldType GetType(int index, ref MySqlDataReader reader)
        {
            Type type = reader.GetFieldType(index);

            switch (type.Name)
            {
                case "String":
                    return FieldType.Str;
                case "UInt32":
                    return FieldType.UI4;
                case "Int32":
                    return FieldType.I4;
                case "UInt16":
                    return FieldType.UI2;
                case "Int16":
                    return FieldType.I2;
                case "UInt64":
                    return FieldType.UI8;
                case "Int64":
                    return FieldType.I8;
                case "Byte[]":
                    return FieldType.Bytes;
                case "SByte":
                    return FieldType.I1; ;
                case "Double":
                    return FieldType.R8;
                case "Decimal":
                    return FieldType.R4;
                case "Boolean":
                    return FieldType.Bool;
                case "Byte":
                    return FieldType.UI1;
                default:
                    throw new Exception("Wrong FieldType");
            }
        }

        private static PyTuple CreateArgs()
        {
            PyTuple result = new PyTuple();

            result.Items.Add(new PyTuple());

            return result;
        }
    }
}
