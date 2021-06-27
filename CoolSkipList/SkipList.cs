//-----------------------------------------------------------------------
// <copyright file="SkipList.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace CoolSkipList
{
    using System;
    using System.Linq;

    /// <summary>
    /// Represents a skip list. For more information about the 
    /// functionality and definition of a skip list, visit <seealso cref="https://brilliant.org/wiki/skip-lists/"/>
    /// </summary>
    public class SkipList<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SkipList{T}"/> class.
        /// </summary>
        /// <param name="elements">The element to insert into the list on instantiation.</param>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if <paramref name="elements"/> is is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Is thrown if <paramref name="elements"/> contains null references or is empty.
        /// </exception>
        public SkipList(params T[] elements)
        {
            if (elements == null)
                throw new ArgumentNullException(nameof(elements), "List elements must not be a null reference.");

            if (elements.Length < 1)
                throw new ArgumentException(nameof(elements), "If instantiated with elements, you need to provide at least one element.");

            if (!ValidateContentsNotNull(elements))
                throw new ArgumentException(nameof(elements), "Must not specify collection containing null references to instantiate list.");

            this.CreateBaseLayer(elements);
        }

        /// <summary>
        /// Gets or sets the head of this skip list.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if head is null.
        /// </exception>
        public ListDataPoint<T> Head
        {
            get;
            set;
        }

        /// <summary>
        /// Helper function called in the constructor to validate whether the specified array 
        /// does not contain null references.
        /// </summary>
        /// <param name="elements">The element specified as parameters for the skip list.</param>
        /// <returns>Whether the array containing the elements is valid and does not contain null references.</returns>
        private bool ValidateContentsNotNull(T[] elements)
        {
            foreach (var item in elements)
            {
                if (item == null)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Helper function creating the base layer of the skip list based on an initial list.
        /// </summary>
        /// <param name="elements">The element to create the base layer from.</param>
        private void CreateBaseLayer(T[] elements)
        {
            this.Head = new ListDataPoint<T>(elements.First());
            var current = this.Head;

            for (int i = 1; i < elements.Length; i++)
            {
                current.Next = new ListDataPoint<T>(elements[i]);
                current = current.Next;
            }
        }
    }
}
