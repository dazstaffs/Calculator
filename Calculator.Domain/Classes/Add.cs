using Calculator.Domain.Interfaces;

namespace Calculator.Domain.Classes
{
    public class Add : IOperatorCalculation
    {
        private readonly int currentValue;
        private readonly Instruction instruction;

        public Add(int currentValue, Instruction instruction)
        {
            this.currentValue = currentValue;
            this.instruction = instruction;
        }

        public int DoCalculation()
        {
            return this.currentValue + instruction.Number;
        }
    }
}
