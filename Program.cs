using System;
using System.Collections.Generic;

namespace HeistPartTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create the list of robbers
            List<IRobber> rolodex = new List<IRobber>();

            // Pre-populate the list with robbers
            rolodex.Add(new Hacker("Mr. Robot", 80, 20));
            rolodex.Add(new LockSpecialist("Lucky Lockpicker", 60, 15));
            rolodex.Add(new Muscle("Bulldozer", 90, 25));
            rolodex.Add(new Hacker("Tech Genius", 70, 18));
            rolodex.Add(new LockSpecialist("Keymaster", 50, 12));

            // Display the initial list of robbers
            Console.WriteLine("Pre-populated Robbers:");
            foreach (IRobber robber in rolodex)
            {
                Console.WriteLine($"Name: {robber.Name}, Skill Level: {robber.SkillLevel}, Percentage Cut: {robber.PercentageCut}");
            }

            // Display the number of current operatives in the rolodex
            Console.WriteLine();
            Console.WriteLine($"Number of current operatives in the rolodex: {rolodex.Count}");

            // prompt the user to enter the name of a new possible crew member
            Console.WriteLine();
            Console.WriteLine("Enter the name of a new possible crew member: ");
            string newName = Console.ReadLine();

            // Display the list of possible specialties
            Console.WriteLine("Select the specialty of the new operative:");
            Console.WriteLine("1. Hacker (Disables alarms)");
            Console.WriteLine("2. Muscle (Disarms guards)");
            Console.WriteLine("3. Lock Specialist (Cracks vault)");

            // Prompt the user to select the specialty
            Console.WriteLine();
            Console.WriteLine("Enter the number corresponding to the specialty: ");
            int specialtyChoice = Convert.ToInt32(Console.ReadLine());

            // Prompt the user to select the Skill Level
            Console.WriteLine();
            Console.WriteLine("Enter the Skill Level of Robber (1-100): ");
            int newSkillLevel = Convert.ToInt32(Console.ReadLine());

            // Prompt the user to select the Percentage Cut
            Console.WriteLine();
            Console.WriteLine("Enter the Percentage Cut for Robber (1-100): ");
            int newPercentageCut = Convert.ToInt32(Console.ReadLine());

            // Create a new operative based on the selected specialty
            IRobber newOperative;

            // Switch statement based on the user's specialty choice
            switch (specialtyChoice)
            {
                // If the user chooses specialty 1 (Hacker)
                case 1:
                    // Create a new Hacker instance with the provided name and skill level
                    newOperative = new Hacker(newName, newSkillLevel, newPercentageCut);
                    break;

                // If the user chooses specialty 2 (Muscle)
                case 2:
                    // Create a new Muscle instance with the provided name and skill level
                    newOperative = new Muscle(newName, newSkillLevel, newPercentageCut);
                    break;

                // If the user chooses specialty 3 (Lock Specialist)
                case 3:
                    // Create a new LockSpecialist instance with the provided name and skill level
                    newOperative = new LockSpecialist(newName, newSkillLevel, newPercentageCut);
                    break;

                // If the user chooses an invalid specialty choice
                default:
                    // Display an error message and exit the program
                    Console.WriteLine("Invalid specialty choice. Exiting program.");
                    return;
            }

            // Add the new operative to the rolodex
            rolodex.Add(newOperative);

            // Create a new bank object with random property values
            Bank bank = new Bank
            {
                AlarmScore = new Random().Next(0, 151),
                VaultScore = new Random().Next(0, 151),
                SecurityGuardScore = new Random().Next(0, 151),
                CashOnHand = new Random().Next(250000, 3000001)
            };

            // Display the Recon Report
            Console.WriteLine();
            Console.WriteLine("Recon Report:");
            Console.WriteLine($"Most Secure: {GetMostSecureSystem(bank)}");
            Console.WriteLine($"Least Secure: {GetLeastSecureSystem(bank)}");

            // Print out the report of the rolodex
            Console.WriteLine();
            Console.WriteLine("Rolodex Report:");
            PrintRobberReport(rolodex);

            // Create a new list for the crew
            List<IRobber> crew = new List<IRobber>();

            // Prompt the user to select crew members
            Console.WriteLine();
            Console.WriteLine("Select crew members to include in the heist (enter the index):");

            while (true)
            {
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    // User entered a blank value, exit the loop
                    break;
                }

                if (int.TryParse(input, out int index) && index >= 0 && index < rolodex.Count)
                {
                    IRobber selectedRobber = rolodex[index];

                    if (selectedRobber.PercentageCut <= bank.CashOnHand)
                    {
                        // Add the selected robber to the crew
                        crew.Add(selectedRobber);
                        Console.WriteLine($"Added {selectedRobber.Name} to the crew.");
                        bank.CashOnHand -= selectedRobber.PercentageCut;
                    }
                    else
                    {
                        Console.WriteLine("Cannot add robber. Insufficient funds for their percentage cut.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid index. Try again.");
                }
            }

            // Perform the skills of each crew member on the bank
            foreach (IRobber crewMember in crew)
            {
                crewMember.PerformSkill(bank);
            }

            // Evaluate if the bank is secure
            if (bank.IsSecure)
            {
                Console.WriteLine("Heist failed. The bank's security system is still active.");
            }
            else
            {
                Console.WriteLine("Heist successful!");

                // Calculate the total cut for the crew members
                int totalCut = 0;
                foreach (IRobber crewMember in crew)
                {
                    int memberCut = (int)(crewMember.PercentageCut * bank.CashOnHand / 100.0);
                    totalCut += memberCut; // compound assignment operator that adds the value on the right-hand side to the current value of the left-hand side and assigns the result back to the left-hand side
                    Console.WriteLine($"{crewMember.Name} received a cut of ${memberCut}.");
                }

                int remainingCash = bank.CashOnHand - totalCut;
                Console.WriteLine($"You received a cut of ${remainingCash}. Total amount stolen: ${totalCut}.");
            }
        }

        // Helper method to print the robber report
        static void PrintRobberReport(List<IRobber> robbers)
        {
            for (int i = 0; i < robbers.Count; i++)
            {
                IRobber robber = robbers[i];
                Console.WriteLine($"{i}. Name: {robber.Name}, Specialty: {robber.GetType().Name}, Skill Level: {robber.SkillLevel}, Percentage Cut: {robber.PercentageCut}");
            }
        }

        // Helper method to get the most secure system of the bank
        static string GetMostSecureSystem(Bank bank)
        {
            if (bank.AlarmScore >= bank.VaultScore && bank.AlarmScore >= bank.SecurityGuardScore)
            {
                return "Alarm";
            }
            else if (bank.VaultScore >= bank.AlarmScore && bank.VaultScore >= bank.SecurityGuardScore)
            {
                return "Vault";
            }
            else
            {
                return "Security Guard";
            }
        }

        // Helper method to get the least secure system of the bank
        static string GetLeastSecureSystem(Bank bank)
        {
            if (bank.AlarmScore <= bank.VaultScore && bank.AlarmScore <= bank.SecurityGuardScore)
            {
                return "Alarm";
            }
            else if (bank.VaultScore <= bank.AlarmScore && bank.VaultScore <= bank.SecurityGuardScore)
            {
                return "Vault";
            }
            else
            {
                return "Security Guard";
            }
        }
    }
}
