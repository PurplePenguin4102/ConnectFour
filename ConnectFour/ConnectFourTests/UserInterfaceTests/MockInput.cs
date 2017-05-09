using ConnectFour.InputOutput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFourTests.UserInterfaceTests
{
    public class MockInput : IInputRetriever
    {
        public List<string> WhatUserSaid { get; set; }
        private int index = -1;
        public string Get()
        {
            index++;
            return WhatUserSaid[index];
        }
    }
}
