using Calculator.Domain.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Calculator.Tests
{
    [TestClass]
    public class CalculatorTests
    {

        [TestMethod]
        [DataRow("add 2", 2, 4)]
        [DataRow("subtract 2", 4, 2)]
        [DataRow("multiply 2", 2, 4)]
        [DataRow("divide 2", 4, 2)]
        public void DoCalculation(string instructionString, int currentValue, int ExpectedResult)
        {
            try
            {
                Instruction instruction = new Instruction(instructionString);
                Calculate calculate = new Calculate(instruction, currentValue);
                calculate.DoCalculation();
                Assert.AreEqual(ExpectedResult, calculate.GetResult());
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [TestMethod]
        public void DoCalculations()
        {
            try
            {
                List<Instruction> instructions = new List<Instruction>();
                instructions.Add(new Instruction("add 2"));
                instructions.Add(new Instruction("subtract 3"));
                int currentValue = 4;

                foreach (var instruction in instructions)
                {
                    Calculate calculate = new Calculate(instruction, currentValue);
                    calculate.DoCalculation();
                    currentValue = calculate.GetResult();
                }
                Assert.AreEqual(3, currentValue);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
