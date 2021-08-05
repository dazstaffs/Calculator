using Calculator.Domain.Classes;
using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string filePath = @".\..\..\..\Instructions.txt";
                FileLoader.CheckFileExists(filePath);
                string[] instructions = FileLoader.GetInstructions(filePath);

                Instruction.CheckInstructionsLengthValid(instructions);
                Instruction.CheckLastInstructionIsApply(instructions);
                Instruction.CheckAllInstructionsContainSpaces(instructions);

                int currentValue = Instruction.GetApplyNumber(instructions);
                for (int i = 0; i < instructions.Length; i++)
                {
                    Instruction instruction = new Instruction(instructions[i]);
                    instruction.CheckOperatorValid();

                    Calculate calculator = new Calculate(instruction, currentValue);
                    calculator.DoCalculation();
                    currentValue = calculator.GetResult();
                }
                Console.WriteLine("The result is {0}", currentValue);
                Console.ReadLine();
            }
            catch (Exception) //TODO: Log to external database or log file.
            {
                throw;
            }
        }
    }
}
