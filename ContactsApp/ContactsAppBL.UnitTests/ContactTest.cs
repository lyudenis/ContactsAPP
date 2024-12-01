﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ContactsApp;

namespace ContactsAppBL.UnitTests
{
    [TestFixture]
    class ContactTest
    {
        private Contact _contact;

        [SetUp]
        public void InitContact()
        {
            _contact = new Contact();
        }

        // Тесты свойства Surname.
        //
        [TestCase("", "Должно возникать исключение, если фамилия - пустая строка",
            TestName = "Присвоение пустой строки в качестве фамилии")]
        [TestCase("И", "Должно возникать исключение, если фамилия - менее 2 символов",
            TestName = "Присвоение строки из менее 2 символов в качестве фамилии")]
        [TestCase("Смирнов-Смирнов-Смирнов-Смирнов-Смирнов-Смирнов-Смирнов",
            "Должно возникать исключение, если фамилия длиннее 50 символов",
            TestName = "Присвоение неправильной фамилии, больше 50 символов")]
        public void TestSurnameSet_ArgumentException(string wrongSurname, string message)
        {
            Assert.Throws<ArgumentException>(
                () => { _contact.Surname = wrongSurname; }, message);
        }

        [TestCase("Смирнов", "Тест не пройден, фамилия присвоена неверно",
            TestName = "Присвоение правильной фамилии")]
        public void TestSurnameSet_CorrectArgument(string correctSurname, string message)
        {
            Assert.DoesNotThrow(
                () => { _contact.Surname = correctSurname; }, message);
        }

        [TestCase("Смирнов", "Геттер surname возвращает неверную фамилию",
            TestName = "Возвращение геттером фамилии")]
        public void TestSurnameGet_CorrectArgument(string correctSurname, string message)
        {
            _contact.Surname = correctSurname;
            Assert.AreEqual(correctSurname, _contact.Surname, message);
        }

        // Тесты свойства Name.
        //
        [TestCase("", "Должно возникать исключение, если поле имя - пустая строка",
            TestName = "Присвоение пустой строки в качестве имени")]
        [TestCase("И", "Должно возникать исключение, если поле имя - менее 2 символов",
            TestName = "Присвоение строки менее 2 симовлов в качестве имени")]
        [TestCase("Николай-Николай-Николай-Николай-Николай-Николай-Николай",
            "Должно возникать исключение, если имя длиннее 50 символов",
            TestName = "Присвоение неправильного имени, больше 50 символов")]
        public void TestNameSet_ArgumentException(string wrongName, string message)
        {
            Assert.Throws<ArgumentException>(
                () => { _contact.Name = wrongName; },
                message);
        }

        [TestCase("Николай", "Тест не пройден, имя  присвоено неверно",
            TestName = "Присвоение правильного имени")]
        public void TestNameSet_CorrectArgument(string correctName, string message)
        {
            Assert.DoesNotThrow(
                () => { _contact.Name = correctName; }, message);
        }

        [TestCase("Николай", "Геттер name возвращает неверное имя",
            TestName = "Возвращение геттером имени")]
        public void TestNameGet_CorrectArgument(string correctName, string message)
        {
            _contact.Name = correctName;
            Assert.AreEqual(correctName, _contact.Name, message);
        }

        // Тесты свойства Email.
        //
        [TestCase("", "Должно возникать исключение, если поле е-мейл - пустая строка",
            TestName = "Присвоение пустой строки в качестве е-мейла")]
        [TestCase("И", "Должно возникать исключение, если поле е-мейл - менее 2 символов",
            TestName = "Присвоение строки из менее 2 символов в качестве е-мейла")]
        [TestCase("smirnov.nikolay@gmail.com-smirnov.nikolay@gmail.com-",
            "Должно возникать исключение, если е-мейл длиннее 50 символов",
            TestName = "Присвоение неправильного е-мейла, больше 50 символов")]
        public void TestEmailSet_ArgumentException(string wrongEmail, string message)
        {
            Assert.Throws<ArgumentException>(
                () => { _contact.Email = wrongEmail; },
                message);
        }

        [TestCase("smirnov.nikolay@gmail.com", "Тест не пройден, е-мейл присвоен неверно",
            TestName = "Присвоение правильного е-мейла")]
        public void TestEmailSet_CorrectArgument(string correctEmail, string message)
        {
            Assert.DoesNotThrow(
                () => { _contact.Email = correctEmail; }, message);
        }

        [TestCase("Николай", "Геттер е-мейл возвращает неверное имя",
            TestName = "Возвращение геттером е-мейла")]
        public void TestEmailGet_CorrectArgument(string correctEmail, string message)
        {
            _contact.Email = correctEmail;
            Assert.AreEqual(correctEmail, _contact.Email, message);
        }

        // Тесты свойства IDVkcom.
        //
        [TestCase("", "Должно возникать исключение, если поле id vk - пустая строка",
            TestName = "Присвоение пустой строки в качестве id vk")]
        [TestCase("И", "Должно возникать исключение, если поле id vk - менее 2 символов",
            TestName = "Присвоение строки из мнее 2 символов в качестве id vk")]
        [TestCase("nikolaysmirnov19803015", "Должно возникать исключение, если id vk длиннее 15 символов",
            TestName = "Присвоение неправильного id vk, больше 15 символов")]
        public void TestIdVkSet_ArgumentException(string wrongIdVk, string message)
        {
            Assert.Throws<ArgumentException>(
                () => { _contact.IDVkcom = wrongIdVk; }, message);
        }

        [TestCase("nikolay38", "Тест не пройден, id vk присваивается неверное значение.",
            TestName = "Присвоение правильного id vk")]
        public void TestIdVkSet_CorrectArgument(string correctIdVk, string message)
        {
            Assert.DoesNotThrow(
                () => { _contact.IDVkcom = correctIdVk; }, message);
        }

        [TestCase("nikolay38", "Геттер id vk возвращает неверное имя",
            TestName = "Возвращение геттером id vk")]
        public void TestIdVkGet_CorrectArgument(string correctIdVk, string message)
        {
            _contact.IDVkcom = correctIdVk;
            Assert.AreEqual(correctIdVk, _contact.IDVkcom, message);
        }

        // Тесты свойства DateOfBirth.
        //
        [TestCase("1899, 01, 01", "Должно возникать исключение, если дата dateOfBirth меньше, чем 1900,01,01",
            TestName = "Присвоение dateOfBirth меньшее, чем 1900,01,01")]
        [TestCase("3075, 01, 01", "Должно возникать исключение, если дата dateOfBirth больше нынешней",
            TestName = "Присвоение dateOfBirth большее, чем нынешняя даты")]
        public void TestDateOfBirthSet_ArgumentException(string wrongDateOfBirth, string message)
        {
            Assert.Throws<ArgumentException>(
                () => { _contact.DateOfBirth = DateTime.Parse(wrongDateOfBirth); },
                message);
        }

        [TestCase("1975, 01, 01", "Тест не пройден, dateOfBirth присваивается неверное значение",
            TestName = "Присвоение правильного dateOfBirth")]
        public void TestDateOfBirthSet_CorrectArgument(string correctDateOfBirth, string message)
        {
            Assert.DoesNotThrow(
                () => { _contact.DateOfBirth = DateTime.Parse(correctDateOfBirth); },
                message);
        }

        [TestCase("1980, 01, 01", "Геттер dateOfBirth возвращает неверное значение",
            TestName = "Возвращение геттером dateOfBirth")]
        public void TestDateOfBirthGet_CorrectArgument(string correctDateOfBirth, string message)
        {
            _contact.DateOfBirth = DateTime.Parse(correctDateOfBirth);
            Assert.AreEqual(DateTime.Parse(correctDateOfBirth), _contact.DateOfBirth,
                message);
        }
    }
}
