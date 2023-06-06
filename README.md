HeistPartTwo
HeistPartTwo is a command-line application that simulates a heist planning and execution scenario. The program allows users to create a crew of specialized operatives, scout a bank's security systems, assemble a crew, and attempt a heist.

Features
Pre-populated list of robbers: The program starts with a pre-populated list of robbers, each with a name, skill level, and percentage cut.

Add new crew members: Users can add new crew members to the list by selecting their specialty, skill level, and percentage cut.

Recon Report: After creating a new bank object with random property values, the program generates a Recon Report that identifies the most secure and least secure systems of the bank.

Crew selection: Users can select crew members from the rolodex to include in the heist. The program validates if the crew members' percentage cuts can be afforded based on the bank's cash on hand.

Heist execution: Each crew member performs their skill on the bank. The program evaluates if the bank's security systems are successfully compromised or if the heist fails.

Heist outcome: If the heist is successful, the program displays a report of each crew member's cut and the total amount stolen. If the heist fails, a failure message is shown.

Usage
Run the program: Open the program in a C# development environment or compile and run the Program.cs file.

Follow the on-screen instructions: The program will prompt you for various inputs, such as the name of a new crew member, their specialty, skill level, and percentage cut.

Select crew members: Choose crew members from the rolodex by entering their corresponding index. The program will verify if their percentage cuts can be afforded and add them to the crew list.

Perform the heist: The crew members will perform their skills on the bank. The program will evaluate the outcome of the heist and display the result.

Review the heist report: If the heist is successful, the program will show each crew member's cut and the remaining cash for yourself. If the heist fails, a failure message will be displayed.

Dependencies
This project does not have any external dependencies. It is built using the C# programming language and relies on the .NET framework.

Contributing
Contributions to this project are currently not accepted as it is for educational purposes.

License
This project is licensed under the MIT License.

Feel free to update the README file with any additional information or sections that you deem necessary for your project.
