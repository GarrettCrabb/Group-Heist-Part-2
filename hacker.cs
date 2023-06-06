using System;

namespace HeistPartTwo
{
    // Hacker class implementing IRobber interface
    class Hacker : IRobber
    {
        // Properties from IRobber interface
        public string Name { get; }
        public int SkillLevel { get; }
        public int PercentageCut { get; }

        // Constructor
        public Hacker(string name, int skillLevel, int percentageCut)
        {
            Name = name;
            SkillLevel = skillLevel;
            PercentageCut = percentageCut;
        }

        // Implementation of PerformSkill method
        public void PerformSkill(Bank bank)
        {
            // Decrease the bank's alarm score by the hacker's skill level
            bank.AlarmScore = bank.AlarmScore - SkillLevel;

            // Print the action being performed by the hacker
            Console.WriteLine($"{Name} is hacking the alarm system. Decreased security by {SkillLevel} points.");

            // Check if the alarm score is now <= 0
            if (bank.AlarmScore <= 0)
            {
                Console.WriteLine($"{Name} has disabled the alarm system!");
            }
        }
    }
}
