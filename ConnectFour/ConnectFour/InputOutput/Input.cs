using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour.InputOutput
{
    public class Input : IInputRetriever
    {
        /// <summary>
        /// returns what is retrieved from user
        /// </summary>
        public string Get()
        {
            return Console.ReadLine();
        }
    }
}
