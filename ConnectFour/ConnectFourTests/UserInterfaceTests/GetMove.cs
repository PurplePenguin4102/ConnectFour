using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConnectFour;
using ConnectFour.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConnectFourTests.UserInterfaceTests
{
    [TestClass]
    public class GetMove
    {
        [TestMethod]
        public void ValidMove()
        {
            var ui = new UserInterface()
            {
                Input = new MockInput()
                {
                    WhatUserSaid = "\t1  "
                },
                Output = new MockOutput()
            };
            Assert.AreEqual(1, ui.GetMove(Players.Yellow));
        }

        [TestMethod]
        public void ValidMove_Big()
        {
            var ui = new UserInterface()
            {
                Input = new MockInput()
                {
                    WhatUserSaid = "345345"
                },
                Output = new MockOutput()
            };
            Assert.AreEqual(345345, ui.GetMove(Players.Yellow));
        }

        [TestMethod]
        public async Task InvalidMove_Zero()
        {
            var ui = new UserInterface()
            {
                Input = new MockInput()
                {
                    WhatUserSaid = "0"
                },
                Output = new MockOutput()
            };
            await Task.WhenAny(new Task(() =>
            {
                ui.PromptDimensions();
                Assert.Fail();
            }), Task.Delay(200));
        }

        [TestMethod]
        public async Task InvalidMove_Negative()
        {
            var ui = new UserInterface()
            {
                Input = new MockInput()
                {
                    WhatUserSaid = "-10"
                },
                Output = new MockOutput()
            };
            await Task.WhenAny(new Task(() =>
            {
                ui.PromptDimensions();
                Assert.Fail();
            }), Task.Delay(200));
        }

        [TestMethod]
        public async Task InvalidMove_Float()
        {
            var ui = new UserInterface()
            {
                Input = new MockInput()
                {
                    WhatUserSaid = "0.163"
                },
                Output = new MockOutput()
            };
            await Task.WhenAny(new Task(() =>
            {
                ui.PromptDimensions();
                Assert.Fail();
            }), Task.Delay(200));
        }
    }
}
