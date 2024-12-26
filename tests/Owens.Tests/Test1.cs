// <copyright file="Test1.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

namespace Owens.Tests
{
    /// <summary>
    /// Test class.
    /// </summary>
    [TestClass]
    public sealed class Test1
    {
        /// <summary>
        /// Test method.
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            const string name = "Mike";

            var value = "Mi" + "ke";

            Assert.AreEqual(name, value);
        }
    }
}
