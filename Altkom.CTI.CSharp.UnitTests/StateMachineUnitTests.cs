using Altkom.CTI.CSharp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Altkom.CTI.CSharp.UnitTests
{
    [TestClass]
    public class StateMachineUnitTests
    {

        [TestMethod]
        public void StateTest()
        {
            var lamp = new Lamp();

            Assert.AreEqual(LampState.Off, lamp.LampState);

            lamp.SwitchOn();

            Assert.AreEqual(LampState.On, lamp.LampState);

            lamp.SwitchOn();

            Assert.AreEqual(LampState.Blink, lamp.LampState);

            lamp.SwitchOff();

            Assert.AreEqual(LampState.Off, lamp.LampState);



        }
    }
}
