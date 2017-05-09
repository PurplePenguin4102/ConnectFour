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
        public string Send(string msg)
        {
            Console.WriteLine(msg);
            return msg;
        }

        /// <summary>
        /// Returns what is sent, doesn't add new line at user request
        /// </summary>
        public string Send(string msg, bool noLineEnd)
        {
            if (noLineEnd)
            {
                Console.Write(msg);
            }
            else
            {
                return Send(msg);
            }
            return msg;
        }
    }
}
