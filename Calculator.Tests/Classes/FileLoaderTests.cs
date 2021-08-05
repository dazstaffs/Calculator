using Calculator.Domain.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Calculator.Tests
{
    [TestClass]
    public class FileLoaderTests
    {

        [TestMethod]
        public void LoadFile_ReturnsInstructions()
        {
            try
            {
                string filePath = @".\..\..\..\Instructions.txt";
                string[] instructions = FileLoader.GetInstructions(filePath);
                Assert.IsNotNull(instructions[0]);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [TestMethod]
        public void CheckFileExists_ThrowsException()
        {
            try
            {
                string filePath = @".\..\..\Instructions.txt";
                Assert.ThrowsException<FileNotFoundException>(() => FileLoader.CheckFileExists(filePath));
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
