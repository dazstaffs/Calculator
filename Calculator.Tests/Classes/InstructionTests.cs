using Calculator.Domain.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Calculator.Tests
{
    [TestClass]
    public class InstructionTests
    {
        [TestMethod]
        [DataRow(new string[] { "apply 2" })]
        [DataRow(new string[] { })]
        public void EnsureInstructionLengthValid_ThrowsExceptions(string[] instructions)
        {
            try
            {
                Assert.ThrowsException<ApplicationException>(() => Instruction.CheckInstructionsLengthValid(instructions));
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [TestMethod]
        [DataRow(new string[] { "add 2", "multiply 3", "apply 3", "subtract 4" })]
        public void EnsureLastInstructionIsApply_ThrowsExceptions(string[] instructions)
        {
            try
            {
                Assert.ThrowsException<ApplicationException>(() => Instruction.CheckLastInstructionIsApply(instructions));
            }
            catch (System.Exception)
            {
                throw;
            }

        }

        [TestMethod]
        [DataRow(new string[] { "add 2", "multiply3", "apply 3" })]
        public void EnsureAllInstructionContainSpacesBetweenInstructionAndNumber_ThrowsExceptions(string[] instructions)
        {
            try
            {
                Assert.ThrowsException<ApplicationException>(() => Instruction.CheckAllInstructionsContainSpaces(instructions));
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [TestMethod]
        [DataRow(new string[] { "add 2", "multiply 3", "apply 3" })]
        public void SeparateInstructionAndNumber_ValidInstruction(string[] instructions)
        {
            try
            {
                Instruction instruction = new Instruction(instructions[0]);
                Assert.IsNotNull(instruction.Number);
                Assert.IsNotNull(instruction.Operator);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [TestMethod]
        [DataRow(new string[] { "plus 2" })]
        [DataRow(new string[] { "Add 2" })]
        public void EnsureOperatorIsValid_ThrowsExceptions(string[] instructions)
        {
            try
            {
                Instruction instruction = new Instruction(instructions[0]);
                Assert.ThrowsException<ApplicationException>(() => instruction.CheckOperatorValid());
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [TestMethod]
        [DataRow(new string[] { "apply 2" }, 2)]
        public void ExtractApplyFromInstructions_ReturnsIntApplyNumber(string[] instructions, int expectedResult)
        {
            try
            {
                int applyNumber = Instruction.GetApplyNumber(instructions);
                Assert.AreEqual(expectedResult, applyNumber);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
