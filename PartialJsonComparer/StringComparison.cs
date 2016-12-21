using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.Tests1
{
    [TestFixture]
    public class StringComparison
    {
        [Test]
        public void TwoStrings_ReturnTrue()
        {
            var expected = "string";
            var actual = "string";

            var result = StringComparator.Compare(expected, actual);
            Assert.True(result);
        }

        [Test]
        public void CaseInsensitive_ReturnTrue()
        {
            var expected = "string";
            var actual = "String";

            var result = StringComparator.Compare(expected, actual);
            Assert.True(result);
        }

        [Test]
        public void TwoDifferentStrings_ReturnFalse()
        {
            var expected = "string";
            var actual = "not same string";

            var result = StringComparator.Compare(expected, actual);
            Assert.False(result);
        }

        [Test]
        public void SimpleJson_ReturnsTrue()
        {
            var expected = @"{ Key: ""Value"" }";
            var actual = @"{ Key: ""Value"" }";

            var result = StringComparator.Compare(expected, actual);
            Assert.True(result);
        }

        [Test]
        public void EmptyString_ReturnsTrue()
        {
            var expected = "";
            var actual = "";

            var result = StringComparator.Compare(expected, actual);
            Assert.True(result);
        }

        [Test]
        public void NullString_ReturnsTrue()
        {
            string expected = null;
            string actual = null;

            var result = StringComparator.Compare(expected, actual);
            Assert.True(result);
        }
    }
}
