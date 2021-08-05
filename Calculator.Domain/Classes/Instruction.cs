using System;
using System.Text;

namespace Calculator.Domain.Classes
{
    public class Instruction
    {
        public string Operator { get; set; }
        public int Number { get; set; }
        public Instruction(string instruction)
        {
            string[] instructions = instruction.Split(" ");
            this.Operator = instructions[0];
            this.Number = Convert.ToInt32(instructions[1]);
        }

        public static void CheckLastInstructionIsApply(string[] instructions)
        {
            if (instructions[instructions.Length - 1].Contains("apply"))
            {
                return;
            }
            throw new ApplicationException("Instructions do not contain an apply command.");
        }

        public static void CheckAllInstructionsContainSpaces(string[] instructions)
        {
            for (int i = 0; i < instructions.Length; i++)
            {
                if (!instructions[i].Contains(" "))
                {
                    throw new ApplicationException(String.Format("Instruction {0} does not contain a space.", instructions[i]));
                }
            }
            return;
        }

        public static void CheckInstructionsLengthValid(string[] instructions)
        {
            if (instructions.Length >= 2)
            {
                return;
            }
            throw new ApplicationException("Instructions must contain two or more instructions.");
        }

        public void CheckOperatorValid()
        {
            string[] validOperators = { "add", "substract", "multiply", "divide", "apply" };
            for (int i = 0; i < validOperators.Length; i++)
            {
                if (validOperators[i] == this.Operator)
                {
                    return;
                }
            }
            throw new ApplicationException("Operator can only be add, subtract, multiply, divide or apply.");
        }

        public static int GetApplyNumber(string[] instructions)
        {
            StringBuilder stringBuilder = new StringBuilder(instructions[instructions.Length - 1]);
            stringBuilder.Replace("apply", "");
            stringBuilder.Replace(" ", "");
            return Convert.ToInt32(stringBuilder.ToString());
        }
    }
}
