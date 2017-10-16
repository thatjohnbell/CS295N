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
            RNConvert rn = new RNConvert();
            string r = rn.ConvertItoR(4);
            Assert.Equal("IV", r);
        }

        [Fact]
        public void ConvertRtoITest()
        {
            RNConvert rn = new RNConvert();
            int i = rn.ConvertRtoI("IV");
            Assert.Equal(4, i);
        }
    }
}
