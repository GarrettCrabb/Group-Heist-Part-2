namespace HeistPartTwo
{
    // Interface representing a robber
    public interface IRobber
    {
        // Name of the robber
        string Name { get; }

        // Skill level of the robber
        int SkillLevel { get; }

        // Percentage cut the robber demands
        int PercentageCut { get; }

        // Method to perform the robber's skill on the bank
        void PerformSkill(Bank bank);
    }
}
