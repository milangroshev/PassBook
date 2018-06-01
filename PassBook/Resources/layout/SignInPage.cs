using Diagnostics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace PassBook
{
   public class SignInPage
   {
        private bool flag = true;

        private User user = new User();
        

        public SignInPage()
        {
            LoadPage();

        }

        



        private void LoadPage()
        {

            PrintHeader();

            InsertNameAndLastName();
            InsertUsername();
            InsertPassword();

            Console.ReadLine();
            

            
        }

        private void PrintHeader()
        {
            Console.WriteLine();
            Console.Write("1. Name: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(user.Name);
            Console.ResetColor();
            Console.Write("2. Last Name: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(user.LastName);
            Console.ResetColor();
            Console.Write("3. Username: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(user.UserName);
            Console.ResetColor();
            Console.Write("4. Password: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(user.Password);
            Console.ResetColor();
            Console.WriteLine();
        }

        private void InsertNameAndLastName()
        {
            List<string> list = new List<string>(new string[] {"Name","Last Name"});

            foreach (var item in list)
            {
                while (flag)
                {
                    ClearCurrentConsoleLine();
                    Console.Write("~$ Insert "+item+": ");
                    string input = Console.ReadLine();
                    if (Regex.IsMatch(input, @"^[a-zA-Z]+$"))
                    {
                        if (item == "Name")
                            user.Name = input;
                        else
                            user.LastName = input;

                        Console.Clear();
                        PrintHeader();
                        
                        break;

                    }
                    Console.SetCursorPosition(0, 5);
                    DefaultMessages.PrintErrorMessage("Wrong input !!! Please insert name that contains only letters.:");
                }
            }    
        }

        private void InsertUsername()
        {

        }
        private void InsertPassword()
        {

        }

        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
    }
}
