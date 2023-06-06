using System;
using System.Collections.Generic;

namespace HeistPartTwo
{
    // Class representing the Bank
    public class Bank
    {
        // Property to store the amount of cash the bank has
        public int CashOnHand { get; set; }

        // Property representing the security alarm score
        public int AlarmScore { get; set; }

        // Property representing the vault security score
        public int VaultScore { get; set; }

        // Property representing the security guard score
        public int SecurityGuardScore { get; set; }

        // Computed property to check if the bank is secure
        public bool IsSecure
        {
            get
            {
                // If all scores are less than or equal to 0, the bank is not secure
                return (AlarmScore <= 0 && VaultScore <= 0 && SecurityGuardScore <= 0);
            }
        }
    }
}
