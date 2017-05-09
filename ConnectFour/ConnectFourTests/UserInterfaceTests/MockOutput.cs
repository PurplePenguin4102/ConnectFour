using ConnectFour.InputOutput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFourTests.UserInterfaceTests
{
    public class MockOutput : IOutputSender
    {
        public string Send(string msg, bool newline)
        {
            return msg;
        }
    }
}
