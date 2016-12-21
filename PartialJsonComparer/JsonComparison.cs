﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.Tests1
{
    public class JsonComparison
    {
        [Test]
        public void PartialExpectedJsonComparison_ReturnsTrue()
        {
            var expected = @"{ Key: ""Value"" }";
            var actual = @"{ Key: ""Value"", Key2: ""Value2"" }";

            var result = StringComparator.Compare(expected, actual);
            Assert.True(result);
        }

        [TestCase(@"{ Key: ""Value"" }")]
        [TestCase(@"{ Key: ""Value"", Key2: { NestedKey1: ""NestedValue1""} }")]
        [TestCase(@"{ Key: ""Value"", Key2: { NestedKey1: ""NestedValue1"", NestedKey2: ""NestedValue2""} }")]
        public void NestedJson_ReturnsTrue(string expected)
        {
            var actual = 
                @"{ 
                    Key: ""Value"", 
                    Key2: { 
                        NestedKey1: ""NestedValue1"", 
                        NestedKey2: ""NestedValue2""
                    } 
                }";

            var result = StringComparator.Compare(expected, actual);
            Assert.True(result);
        }

        [Test]
        public void RecursiveNestedJson_ReturnsTrue()
        {
            var expected = @"{ Key: ""Value"", Key2: { NestedKey1: ""NestedValue1""}}";
            var actual = @"{ Key: ""Value"", Key2: { NestedKey1: ""NestedValue1"", NestedKey2: {NestedNestedKey: ""NestedNestedValue""}} }";

            var result = StringComparator.Compare(expected, actual);
            Assert.True(result);
        }

        [TestCase(@"{key:""Value""}", @"{  key : ""Value""}", TestName = "Handles Spaces correctly")]
        [TestCase(@"{key:""Value""}", @"{ ""key"" : ""Value""}", TestName = "Handles Quotes correctly")]
        [TestCase(@"{key:Value}", @"{key:Value}", TestName = "Handles lack of quotes correctly")]
        [TestCase(@"{key:null}", @"{key:null}", TestName = "Handles null correctly")]
        [TestCase(@"{key:1}", @"{key:1}", TestName = "Handles integers correctly")]
        public void FormattingIssues_StillReturnTrue(string expected, string actual)
        {
            var result = StringComparator.Compare(expected, actual);
            Assert.True(result);
        }
    }
}
