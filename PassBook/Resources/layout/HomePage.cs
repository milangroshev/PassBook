using System;
using System.Collections.Generic;
using System.Text;
using Diagnostics;

namespace PassBook
{
    public class HomePage
    {
        private bool flag = true;

        public HomePage()
        {
          
            DefaultMessages.PrintHeader();
            LoadPage();
        }


        public void LoadPage()
        {

            while (flag)
            {
                Console.WriteLine();
                Console.WriteLine("1. Sign In");
                Console.WriteLine("2. Sign Up");
                Console.WriteLine("3. Exit");
                Console.WriteLine();
                Console.Write("~$");
                string input = Console.ReadLine();

                if (Redirect(input) == 3)
                    flag = false;
            
            }
            


        }

        public int Redirect(string input)
        {
            switch (input)
            {
                case "1":
                    Console.Clear();
                    SignInPage signIn = new SignInPage();
                    DefaultMessages.PrintHeader();
                    return 1;
                case "2":
                    //Console.WriteLine("TWO");
                    DefaultMessages.PrintHeader();
                    return 2;
                case "3":
                    //Console.WriteLine("THREE");
                    return 3;
                default:
                    DefaultMessages.PrintHeader();
                    DefaultMessages.PrintErrorMessage("Wrong input !!! Please select one of the following options:");
                    return 0;
            }
        }

    }
}
