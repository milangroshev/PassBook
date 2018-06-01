using System;
using System.Text;

namespace Diagnostics
{
    public static class DefaultMessages
    {
        public static void PrintHeader()
        {
            Console.Clear();

            StringBuilder _sb = new StringBuilder();
            _sb.AppendLine();
            _sb.AppendLine("===================================================================");
            _sb.AppendLine(string.Format("=                      Name:    PassBook                          ="));
            _sb.AppendLine(string.Format("=                      Version: 1.0                               ="));
            _sb.AppendLine(string.Format("=                      Creator: Milan Groshev                     ="));
            _sb.AppendLine(string.Format("=                      Year:    2018                              ="));
            _sb.AppendLine("===================================================================");

            Console.WriteLine(_sb);
        }

        public static void PrintErrorMessage(string msg)
        {
            StringBuilder _sb = new StringBuilder();

            Console.ForegroundColor = ConsoleColor.Red;
            _sb.AppendLine();
            _sb.AppendLine(msg);
            _sb.AppendLine("===================================================================");

            Console.WriteLine(_sb);

            Console.ResetColor();

        }
    }
}
