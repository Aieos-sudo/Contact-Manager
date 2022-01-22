using System;
using System.Collections.Generic;

namespace Contact_Manager
{
    internal class Program
    {
        /// <summary>
        /// Allows entry, storage, and removal of contact information
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            List<List<string>> Contacts = new List<List<string>>();
            List<string> Info = new List<string> { "Name: ", "Email: ", "Phone: " };
            string enteredcommand = null;
            Title();
            Console.WriteLine();
            CommandMenu();
            do
            {  
                enteredcommand = CommandEntry();
                CaseList(Contacts, Info, enteredcommand);
            }
            while (enteredcommand != "exit");
        }
        /// <summary>
        /// Displays title for the program
        /// </summary>
        static void Title()
        {
            Console.WriteLine("Contact Manager");
        }
        /// <summary>
        /// Lists available commands
        /// </summary>
        static void CommandMenu()
        {
            Console.WriteLine("COMMAND MENU");
            Console.WriteLine("commands - List available commands");
            Console.WriteLine("list - Dispay all contacts");
            Console.WriteLine("view - View a contact");
            Console.WriteLine("add - Add a contact");
            Console.WriteLine("del - Delete a contact");
            Console.WriteLine("exit - Exit program\n");
        }
        /// <summary>
        /// Allows user to enter a command from the CommandMenu()
        /// </summary>
        /// <returns></returns>
        static string CommandEntry()
        {
            Console.Write("Command: ");
            string enteredcommand = Console.ReadLine();
            return enteredcommand;
        }
        /// <summary>
        /// Lists all available contacts
        /// </summary>
        /// <param name="Contacts">Holds list of contacts</param>
        static void CommandList(List<List<string>> Contacts)
        {
            if (Contacts.Count != 0)
            {
                for (int i = 0; i < Contacts.Count; i++)
                {
                    Console.WriteLine(i + 1 + ". " + Contacts[i][0]);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("No contacts available.\n");
            }
        }
        /// <summary>
        /// Views data stored for a specified user
        /// </summary>
        /// <param name="Contacts">Holds list of contacts</param>
        /// <param name="Info">Gives info about each contacts stored data</param>
        static void CommandView(List<List<string>> Contacts, List<string> Info)
        {
            if (Contacts.Count != 0)
            {
                Console.Write("Number: ");
                int SelectedNumber = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < Contacts[SelectedNumber - 1].Count; i++)
                {
                    Console.WriteLine(Info[i] + Contacts[SelectedNumber - 1][i]);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("No contacts available.\n");
            }
        }
        /// <summary>
        /// Adds a new user
        /// </summary>
        /// <param name="Contacts">Holds a list of contacts</param>
        /// <param name="Info">Gives info about each contacts stored data</param>
        static void CommandAdd(List<List<string>> Contacts, List<string> Info)
        {
            List<string> ContactInfo = new List<string> { };
            for (int i = 0; i < Info.Count; i++)
            {
                Console.Write(Info[i]);
                ContactInfo.Add(Console.ReadLine());
            }
            Contacts.Add(ContactInfo);
            Console.WriteLine(ContactInfo[0] + " was added.\n");
        }
        /// <summary>
        /// Lets user delete specific contacts
        /// </summary>
        /// <param name="Contacts"></param>
        static void CommandDel(List<List<string>> Contacts)
        {
            if (Contacts.Count != 0)
            {
                Console.Write("Number: ");
                int SelectedNumber = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(Contacts[SelectedNumber - 1][0] + " was deleted.\n");
                Contacts.Remove(Contacts[SelectedNumber - 1]);
            }
            else
            {
                Console.WriteLine("No contacts available.\n");
            }
        }
        static void CommandCommands()
        {
            CommandMenu();
            Console.WriteLine();
        }
        /// <summary>
        /// Determines which command to run, and runs it. As well as handles exceptions.
        /// </summary>
        /// <param name="Contacts">Holds a list of contacts</param>
        /// <param name="Info">Gives info about each contacts stored data</param>
        /// <param name="enteredcommand">Stores the command entered from CommandEntry()</param>
        static void CaseList(List<List<string>> Contacts, List<string> Info, string enteredcommand)
        {
            try
            { 
                switch (enteredcommand)
                {
                    case "commands":
                        CommandCommands();
                        break;

                    case "list":
                        CommandList(Contacts);
                        break;

                    case "view":
                        CommandView(Contacts, Info);
                        break;

                    case "add":
                        CommandAdd(Contacts, Info);
                        break;

                    case "del":
                        CommandDel(Contacts);
                        break;

                    case "exit":
                        Console.WriteLine("Bye!");
                        break;

                    default:
                        Console.WriteLine("Please enter a valid command\n");
                        break;
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Entered value must be a number");
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("Entered number is too large");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("User doesn't exist. Use command list to view available contacts.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occured");
            }
        } 
    }
}
