using System;
using Xunit;
using RomanNumConv;

namespace RomanNumTest
{
    public class RNTest
    {
        [Fact]
        public void ConvertItoRTest()
        {
            string r = RNConvert.ConvertItoR(4);
            Assert.Equal("IV", r);
        }

        [Fact]
        public void ConvertRtoITest()
        {
            int i = RNConvert.ConvertRtoI("IV");
            Assert.Equal(4, i);
        }
    }
}
