using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Altkom.CTI.CSharp.UnitTests
{
    [TestClass]
    public class SingletonUnitTests
    {
        [TestMethod]
        public void SingletonTest()
        {
            ApplicationContext context = new ApplicationContext();

            // ...

            ApplicationContext context2;

            if (context == null)
            {
                context2 = new ApplicationContext();
            }else
            {
                context2 = context;
            }


        }

        [TestMethod]
        public void SingletonTest2()
        {
            Singleton context = Singleton.Instance;

            // ...

            Singleton context2 = Singleton.Instance;


            Assert.AreSame(context, context2);
        }
    }

    public class ApplicationContext
    {
        public string Username { get; set; }

        public DateTime LoginDate { get; set; }

        public ApplicationContext()
        {
            LoginDate = DateTime.Now;
            Username = "Marcin Sulecki";
        }

    }


    public class Singleton
    {
        protected Singleton()
        {

        } 

        private static Singleton instance;

        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }

                return instance;
            }
        }
    }
}
