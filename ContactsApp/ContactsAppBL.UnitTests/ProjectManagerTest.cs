using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NUnit.Framework;
using ContactsApp;
using Newtonsoft;

namespace ContactsAppBL.UnitTests
{
    [TestFixture]
    class ProjectManagerTest
    {
        private Contact _contact;
        private Project _project;

        [SetUp]
        public void InitComponent()
        {
            _project = new Project();

            _contact = new Contact();
            _contact.Name = "Maxim";
            _contact.Surname = "Petrov";
            _contact.DateOfBirth = new DateTime(1975, 01, 05);
            _contact.Email = "maxim.petrov@gmail.com";
            _contact.IDVkcom = "petrov75";
            _contact.phoneNumber.Number = "76665554433";
        }
    }
}
