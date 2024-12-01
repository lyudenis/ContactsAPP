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

        [Test(Description = "Позитивный тест сериализации")]
        public void TestSerialization_CorrectValue()
        {
            _project.ContactsList.Add(_contact);

            var filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                "/ContactsApp" + "/ContactsAppTest" + "/ContactAppTestSerialize.notes";
            var fileReference = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                "/ContactsApp" + "/ContactsAppTest" + "/ContactAppTestSerializeReference.notes";

            ProjectManager.SaveToFile(_project, filePath);

            var referenceProjectString = File.ReadAllText(fileReference);
            var actualProjectString = File.ReadAllText(filePath);

            Assert.AreEqual(referenceProjectString, actualProjectString,
                "Тест сериализации не пройден.");
        }

        [Test(Description = "Позитивный тест десериализации")]
        public void TestDeserilization_CorrectValue()
        {
            Project project = new Project();
            _project.ContactsList.Add(_contact);

            var filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                "/ContactsApp" + "/ContactsAppTest" + "/ContactAppTestDeserialize.notes";
            var fileReference = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                "/ContactsApp" + "/ContactsAppTest" + "/ContactAppTestDeserializeReference.notes";

            project = ProjectManager.LoadFromFile(fileReference);

            Assert.AreEqual(_project.ContactsList.Count, project.ContactsList.Count,
                "Десериализация работает неправильно.");
            for (int index = 0; index < _project.ContactsList.Count; index++)
            {
                Assert.AreEqual(_project.ContactsList[index].Surname, project.ContactsList[index].Surname,
                    "Некорректная десериализация фамилии");
                Assert.AreEqual(_project.ContactsList[index].Name, project.ContactsList[index].Name,
                    "Некорректная десериализация имени");
                Assert.AreEqual(_project.ContactsList[index].Email, project.ContactsList[index].Email,
                    "Некорректная десериализация е-мейла");
                Assert.AreEqual(_project.ContactsList[index].IDVkcom, project.ContactsList[index].IDVkcom,
                    "Некорректная десериализация id vk");
                Assert.AreEqual(_project.ContactsList[index].phoneNumber.Number,
                    project.ContactsList[index].phoneNumber.Number,
                    "Некорректная десериализация номера телефона");
                Assert.AreEqual(_project.ContactsList[index].DateOfBirth,
                    project.ContactsList[index].DateOfBirth,
                    "Некорректная десериализация фамилии");
            }
        }
    }
}
