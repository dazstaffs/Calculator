using Calculator.Domain.Interfaces;

namespace Calculator.Domain.Classes
{
    public class Calculate
    {
        private int currentValue;
        private readonly Instruction instruction;
        public Calculate(Instruction instruction, int currentValue)
        {
            this.currentValue = currentValue;
            this.instruction = instruction;
        }

        public int GetResult()
        {
            return this.currentValue;
        }

        public void DoCalculation()
        {
            if (this.instruction.Operator == "add")
            {
                IOperatorCalculation add = new Add(this.currentValue, this.instruction); //TODO: Setup Dependency Injection
                this.currentValue = add.DoCalculation();
            }
            if (this.instruction.Operator == "subtract")
            {
                IOperatorCalculation subtract = new Subtract(this.currentValue, this.instruction);
                this.currentValue = subtract.DoCalculation();
            }
            if (this.instruction.Operator == "divide")
            {
                IOperatorCalculation divide = new Divide(this.currentValue, this.instruction);
                this.currentValue = divide.DoCalculation();
            }
            if (this.instruction.Operator == "multiply")
            {
                IOperatorCalculation multiply = new Multiply(this.currentValue, this.instruction);
                this.currentValue = multiply.DoCalculation();
            }
        }
    }
}
