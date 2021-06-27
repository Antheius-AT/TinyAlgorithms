//-----------------------------------------------------------------------
// <copyright file="ListDataPoint.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace CoolSkipList
{
    using System;

    /// <summary>
    /// Represents a single data node found in the skip list, containing a value
    /// of the specified type T.
    /// </summary>
    /// <typeparam name="T">The type desired to be stored in this data node.</typeparam>
    public class ListDataPoint<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListDataPoint{T}"/> class.
        /// </summary>
        /// <param name="data">The data represented by this instance.</param>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if <paramref name="data"/> is a null reference.
        /// </exception>
        public ListDataPoint(T data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data), "Data must not be null.");

            this.Data = data;
        }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        public T Data
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the next data point.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if the next data point is null.
        /// </exception>
        public ListDataPoint<T> Next
        {
            get;
            set;
        }
    }
}
