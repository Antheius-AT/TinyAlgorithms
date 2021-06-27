//-----------------------------------------------------------------------
// <copyright file="SkipListTests.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace AlgorithmsTests
{
    using CoolSkipList;
    using NUnit.Framework;

    /// <summary>
    /// Represents test cases for the <see cref="CoolSkipList.SkipList{T}"/> class.
    /// </summary>
    public class SkipListTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("hallo", "yoyo", "duda")]
        [TestCase(5, 6, -2, 3)]
        public void Does_Instantiating_SkipList_With_Pre_Defined_Values_Correctly_Create_Base_Layer_Based_On_Those_Values(object[] values)
        {
            var skipList = new SkipList<object>(values);

            var current = skipList.Head;

            for (int i = 0; i < values.Length; i++)
            {
                if (current.Data == values[i])
                    current = current.Next;
                else
                    Assert.Fail();
            }

            Assert.Pass();
        }
    }
}