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
        public string WhatUserSaid { get; set; }
        public string Get()
        {
            return WhatUserSaid;
        }
    }
}
