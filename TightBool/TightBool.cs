using System;
using System.Collections.Generic;
using System.Text;

namespace Naamloos
{
    /// <summary>
    /// A Struct that tries to store 4 true/false values in a single byte.
    /// </summary>
    public struct TightBool
    {
        private byte storage;

        /// <summary>
        /// Creates a new TightBool with preset values
        /// </summary>
        /// <param name="val0">Value for [0].</param>
        /// <param name="val1">Value for [1].</param>
        /// <param name="val2">Value for [2].</param>
        /// <param name="val3">Value for [3].</param>
        public TightBool(bool val0 = true, bool val1 = true, bool val2 = true, bool val3 = true)
        {
            storage = 0;

            if (val0)
                this[0] = true;
            if (val1)
                this[1] = true;
            if (val2)
                this[2] = true;
            if (val3)
                this[3] = true;
        }

        /// <summary>
        /// Creates a TightBool with preset storage.
        /// </summary>
        /// <param name="other">Preset storage.</param>
        public TightBool(byte other)
        {
            this.storage = other;
        }

        /// <summary>
        /// Creates a TightBool with another TightBool's storage.
        /// </summary>
        /// <param name="other">The other TightBool to copy from.</param>
        public TightBool(TightBool other)
        {
            this.storage = other.storage;
        }

        /// <summary>
        /// Gets a value from this TightBool
        /// </summary>
        /// <param name="index">index to get value for.</param>
        /// <returns>Boolean value.</returns>
        public bool this[int index]
        {
            // Simple bit check
            get => (storage & (1 << index)) != 0;
            set
            {
                // Make bit mask
                byte mask = (byte)(1 << index);
                // Disable/Enable bit based on bit mask and value of setter
                storage = (byte)(value? (storage | mask) : (storage & (~mask)));
            }
        }

        /// <summary>
        /// Sets the current storage.
        /// </summary>
        /// <param name="storage">New storage.</param>
        public void SetStorage(byte storage) => this.storage = storage;

        /// <summary>
        /// Gets the current storage.
        /// </summary>
        /// <returns>Current storage.</returns>
        public byte GetStorage() => this.storage;

        /// <summary>
        /// Gets a value at an index.
        /// </summary>
        /// <param name="index">Index to get value for.</param>
        /// <returns>The value at the given index.</returns>
        public bool GetValue(int index) => this[index];

        /// <summary>
        /// Sets a value at an index.
        /// </summary>
        /// <param name="value">Value to set.</param>
        /// <param name="index">Index to set value for.</param>
        public void SetValue(bool value, int index) => this[index] = value;

        public override string ToString()
        {
            return $"0:{this[0]},1:{this[1]},2:{this[2]},3:{this[3]}";
        }

        public override bool Equals(object obj)
        {
            // Equals should compare based on the underlying storage byte.
            return obj.Equals(storage);
        }
    }
}