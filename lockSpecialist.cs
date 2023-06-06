using System;

namespace HeistPartTwo
{
class LockSpecialist : IRobber
    {
        public string Name { get; }
        public int SkillLevel { get; }
        public int PercentageCut { get; }

        public LockSpecialist(string name, int skillLevel, int percentageCut)
        {
            Name = name;
            SkillLevel = skillLevel;
            PercentageCut = percentageCut;
        }

        public void PerformSkill(Bank bank)
        {
            bank.SecurityGuardScore -= SkillLevel;

            Console.WriteLine($"{Name} is disarming the security guards. Decreased security by {SkillLevel} points.");

            if (bank.SecurityGuardScore <= 0)
            {
                Console.WriteLine($"{Name} has taken care of the security guards!");
            }
        }
    }
}