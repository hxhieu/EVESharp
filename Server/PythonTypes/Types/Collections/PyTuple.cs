using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using PythonTypes.Types.Database;
using PythonTypes.Types.Primitives;

namespace PythonTypes.Types.Collections
{
    public class PyTuple : PyDataType, IEnumerable<PyDataType>
    {
        private readonly PyDataType[] mList;

        public PyTuple(int size)
        {
            this.mList = new PyDataType[size];
        }

        public PyDataType this[int index]
        {
            get => this.mList[index];
            set => this.mList[index] = value;
        }

        public int Count => this.mList.Length;

        public IEnumerator<PyDataType> GetEnumerator()
        {
            return ((IEnumerable<PyDataType>) this.mList).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool TryGetValue<T>(int key, out T value) where T : PyDataType
        {
            if (key < this.mList.Length)
            {
                value = this.mList[key] as T;
                return true;
            }

            value = null;
            return false;
        }

        public void CopyTo(PyTuple destination, int sourceIndex, int destinationIndex, int count)
        {
            // perform some boundaries checks to ensure the data fits
            if (
                (count + destinationIndex - sourceIndex) > destination.Count ||
                sourceIndex > this.Count ||
                sourceIndex + count > this.Count ||
                sourceIndex < 0 ||
                destinationIndex < 0)
                throw new IndexOutOfRangeException("Trying to copy tuple items that would be out of range");

            // copy data over
            Array.Copy(
                this.mList, sourceIndex,
                destination.mList, destinationIndex, count
            );
        }
    }
}