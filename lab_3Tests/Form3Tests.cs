using Microsoft.VisualStudio.TestTools.UnitTesting;
using lab_3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3.Tests
{
    [TestClass()]
    public class Form3Tests
    {
        [TestMethod()]
        public void checkTestTrue()
        {
            string login = "login";
            string password = "password";
        
            var form = new Form3();
            
            Assert.IsTrue(form.check(login,password));
        }

        [TestMethod()]
        public void checkTestFalsePassword()
        {
            string login = "login";
            string password = "wrbbz";
        
            var form = new Form3();
            
            Assert.IsFalse(form.check(login,password));
        }

        [TestMethod()]
        public void checkTestFalseLogin()
        {
            string login = "srcsaets";
            string password = "password";

            var form = new Form3();

            Assert.IsFalse(form.check(login, password));
        }
        [TestMethod()]
        public void payTestTrue()
        {
            int grn = 10;
            int price = 20;
            int difference ;
            var form = new Form1();
            difference = form.calculate(price,grn);
            Assert.AreEqual(difference , 10);
        }
        [TestMethod()]
        public void payTestFalse()
        {
            int grn = 10;
            int price = 10;
            int difference;
            var form = new Form1();
            difference = form.calculate(price, grn);
            Assert.AreNotEqual(difference,10);
        }

    }
}