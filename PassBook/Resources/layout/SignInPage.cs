using Diagnostics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Diagnostics;


namespace PassBook
{
   public class SignInPage
   {
        private bool flag = true;
        private static Regex sUserNameAllowedRegEx = new Regex(@"^(?=[a-zA-Z])[-\w.]{0,23}([a-zA-Z\d]|(?<![-.])_)$");

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
            while (true)
            {
                ClearCurrentConsoleLine();
                DefaultMessages.PrintUsernameConditionsMessage();
                Console.Write("~$ Insert username: ");
                string input = Console.ReadLine();
                if (IsUserNameAllowed(input))
                {
                    
                        user.UserName = input;
                    

                    Console.Clear();
                    PrintHeader();

                    break;

                }
                Console.Clear();
                PrintHeader();
                DefaultMessages.PrintErrorMessage("Wrong username !!! Please insert username following this conditions :");
            }
        }
        private void InsertPassword()
        {
            string pass1 = "";
            string pass2 = "";

            PasswordAdvisor.PasswordScore pwdScore;


            while (true)
            {
                for (int i = 0; i < 2; i++)
                {
                    while (true)
                    {
                        string pass = "";
                        ConsoleKeyInfo key;
                        ClearCurrentConsoleLine();
                        if (i == 0)
                            Console.Write("~$ Insert password: ");
                        else
                        {
                            Console.Clear();
                            PrintHeader();
                            Console.Write("~$ Confirm password: ");
                        }
                            
                        do
                        {

                            key = Console.ReadKey(true);

                            // Backspace Should Not Work
                            if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                            {
                                pass += key.KeyChar;
                                Console.Write("*");
                            }
                            else
                            {
                                if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
                                {
                                    pass = pass.Substring(0, (pass.Length - 1));
                                    Console.Write("\b \b");
                                }
                            }
                        }
                        // Stops Receving Keys Once Enter is Pressed
                        while (key.Key != ConsoleKey.Enter);

                        pwdScore = PasswordAdvisor.CheckStrength(pass);

                        if (pwdScore == PasswordAdvisor.PasswordScore.Blank)
                        {
                            Console.Clear();
                            PrintHeader();
                            DefaultMessages.PrintErrorMessage("Password can not be blank!!! Please insert password.");
                        }
                        else
                        {
                            if (i == 0)
                                pass1 = pass;
                            else
                                pass2 = pass;


                            break;
                        }

                    }
                }

                if (pass1 != pass2)
                {
                    Console.Clear();
                    PrintHeader();
                    DefaultMessages.PrintErrorMessage("Password and confirmation do not match!!!");
                }
                else
                {
                    user.Password = "**********";
                    pwdScore = PasswordAdvisor.CheckStrength(pass1);

                    if (pwdScore == PasswordAdvisor.PasswordScore.VeryWeak)
                    {
                        Console.Clear();
                        PrintHeader();
                        DefaultMessages.PrintWarningMessage("Inserted password is weak");
                        if (WantToContinue())
                        {
                            Console.Clear();
                            PrintHeader();
                            break;
                        }
                        else
                        {
                            user.Password = "";
                            Console.Clear();
                            PrintHeader();
                        }
                        
                        
                    }
                    
                }
                

                
            }

            

           
            
        }

        private bool WantToContinue()
        {
            while (true)
            {
                Console.WriteLine("Do you want to continue? [Y/n]");
                string input = Console.ReadLine();
                if (input=="Y"||input=="y")
                {
                    return true;
                }
                else if (input=="N" || input=="n")
                {
                    return false;
                }
                {

                }
            }
        }

        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }

        public static bool IsUserNameAllowed(string userName)
        {
            if (string.IsNullOrEmpty(userName) || !sUserNameAllowedRegEx.IsMatch(userName))
                return false;            
            return true;
        }

        
    }
}
