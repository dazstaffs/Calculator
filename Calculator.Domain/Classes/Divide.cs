using Calculator.Domain.Interfaces;

namespace Calculator.Domain.Classes
{
    public class Divide : IOperatorCalculation
    {
        private readonly int currentValue;
        private readonly Instruction instruction;

        public Divide(int currentValue, Instruction instruction)
        {
            this.currentValue = currentValue;
            this.instruction = instruction;
        }

        public int DoCalculation()
        {
            return this.currentValue / instruction.Number;
        }

    }
}
