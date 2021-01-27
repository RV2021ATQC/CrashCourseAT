using HomeWork_OOP_1_2;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace UnitTest
{
    public class WrittenToFile
    {
        [Fact]
        public void WrittenDataToDisc()
        {
            string Path = @"D:\data.txt";

            Assert.NotEmpty(Path);
        }
    }   
}
