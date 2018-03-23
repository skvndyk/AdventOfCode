using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Day8.Models
{
    public class Instruction
    {
        public string RegisterToModifyName { get; set; }
        public Register RegisterToModify { get; set; }
        public string Modification { get; set; }
        public int Amount { get; set; }
        public string Condition { get; set; }
        public string LHRegisterName { get; set; }
        public Register LHRegister { get; set; }
        public int ConditionRH { get; set; }

        public void PerformInstruction(ref List<Register> registers)
        {
            LHRegister = FindOrCreateRegister(LHRegisterName, ref registers);
            if (CheckCondition(LHRegister))
            {
                ModifyRegister(RegisterToModify);
            }
        }

        public Register FindOrCreateRegister(string regToCheck, ref List<Register> registers)
        {
            Register reg;
            List<Register> foundRegs = registers.Where(r => r.Name == regToCheck).ToList();
            if (foundRegs.Count > 1)
            {
                throw new Exception($@"Duplicate of Register {foundRegs.First().Name} found. ");
            }
            if (foundRegs.Count == 0)
            {
                reg = new Register() {Name = regToCheck, Value = 0};
                registers.Add(reg);
            }
            else
            {
                reg = foundRegs.First();
            }
            return reg;
        }

        public bool CheckCondition(Register regToCheck)
        {
            switch (Condition)
            {
                case ">":
                    return regToCheck.Value > ConditionRH;
                case "<":
                    return regToCheck.Value < ConditionRH;
                case ">=":
                    return regToCheck.Value >= ConditionRH;
                case "<=":
                    return regToCheck.Value <= ConditionRH;
                case "==":
                    return regToCheck.Value == ConditionRH;
                case "!=":
                    return regToCheck.Value != ConditionRH;
                default:
                    throw new Exception($@"Invalid Condition of {Condition}");
            }
        }

        private void ModifyRegister(Register reg)
        {
            switch (Modification)
            {
                case "inc":
                    reg.Value += Amount;
                    break;
                case "dec":
                    reg.Value -= Amount;
                    break;
                default:
                    throw new Exception($@"Invalid Modification value of {Modification}");
            }
        }
    }
}
