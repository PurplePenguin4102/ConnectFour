using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour.InputOutput
{
    public class Output : IOutputSender
    {
        /// <summary>
        /// Returns what is sent, adds a new line to msg
        /// </summary>
        public string Send(string msg, bool newline)
        {
            if (newline)
            {
                Console.WriteLine(msg);
            }
            else
            {
                Console.Write(msg);
            }
            return msg;
        }
    }
}
