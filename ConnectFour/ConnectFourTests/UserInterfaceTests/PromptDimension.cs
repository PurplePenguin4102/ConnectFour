using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConnectFour;
using ConnectFour.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConnectFourTests.UserInterfaceTests
{
    [TestClass]
    public class PromptDimension
    {
        [TestMethod]
        public void ValidDimensions()
        {
            var ui = new UserInterface()
            {
                Input = new MockInput()
                {
                    WhatUserSaid = "5 5"
                },
                Output = new MockOutput()
            };
            Assert.AreEqual(new Tuple<int, int>(5, 5), ui.PromptDimensions());
        }

        [TestMethod]
        public void ValidDimensions_Big()
        {
            var ui = new UserInterface()
            {
                Input = new MockInput()
                {
                    WhatUserSaid = "1235 55345"
                },
                Output = new MockOutput()
            };
            Assert.AreEqual(new Tuple<int, int>(1235, 55345), ui.PromptDimensions());
        }

        [TestMethod]
        public async Task InvalidDimensions_Gibberish()
        {
            var ui = new UserInterface()
            {
                Input = new MockInput()
                {
                    WhatUserSaid = "qlewrnk.a,smfzxcv8 5"
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
        public async Task InvalidDimensions_Negative()
        {
            var ui = new UserInterface()
            {
                Input = new MockInput()
                {
                    WhatUserSaid = "-5 5"
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
        public async Task InvalidDimensions_TooMany()
        {
            var ui = new UserInterface()
            {
                Input = new MockInput()
                {
                    WhatUserSaid = "3 4 5"
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
        public async Task InvalidDimensions_Float()
        {
            var ui = new UserInterface()
            {
                Input = new MockInput()
                {
                    WhatUserSaid = "8 5.5"
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
        public async Task InvalidDimensions_Zero()
        {
            var ui = new UserInterface()
            {
                Input = new MockInput()
                {
                    WhatUserSaid = "0 5"
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
