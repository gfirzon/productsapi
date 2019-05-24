using Products.Utilites;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ProductTests.UtilitiesTests
{
    public class SHA1EncoderTests
    {
        [Fact]
        public void Encode_Returns_Proper_Value()
        {
            //Arrange
            string expectedValue = "a9993e364706816aba3e25717850c26c9cd0d89d";

            // Act
            string actualValue = SHA1Encoder.Encode("abc");

            // Assert

            Assert.Equal(expectedValue, actualValue);
        }
        
        [Fact]
        public void Encode_Returns_Proper_Value_When_Empty()
        {
            //Arrange
            string expectedValue = "da39a3ee5e6b4b0d3255bfef95601890afd80709";

            // Act
            string actualValue = SHA1Encoder.Encode(null);

            // Assert

            Assert.Equal(expectedValue, actualValue);
        }
    }
}
