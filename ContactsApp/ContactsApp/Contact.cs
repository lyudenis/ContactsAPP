using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
    /// <summary>
    /// Информация о контакте
    /// </summary>
    public class Contact: ICloneable, IComparable<Contact>
    {
        // Фамилия
        //
        private string _surname;

        // Имя
        //
        private string _name;

        /// <summary>
        /// Номер телефона
        /// </summary>
        public PhoneNumber phoneNumber = new PhoneNumber();

        // E-mail
        //
        private string _email;

        // ID Вконтакте
        //
        private string _idVkcom;

        // Дата Рождения
        //
        private DateTime _dateOfBirth;

        /// <summary>
        /// Конструктор Contact
        /// </summary>
        /// <param name="phoneNumber">Номер телефона</param> 
        /// <param name="name">Имя</param>
        /// <param name="surname">Фамилия</param>
        /// <param name="email">E-mail</param>
        /// <param name="dateOfBirth">Дата рождения</param>
        /// <param name="idVkcom">ID Вконтакте</param>
        public Contact(string phoneNumber, string name, string surname, string email, DateTime dateOfBirth,
            string idVkcom)
        {
            this.phoneNumber.Number = phoneNumber;
            Name = name;
            Surname = surname;
            Email = email;
            DateOfBirth = dateOfBirth;
            IDVkcom = idVkcom;
        }

        public Contact()
        { }

        public int CompareTo(Contact other)
        {
            return string.Compare(this.Surname, other.Surname);
        }

        /// <summary>
        /// Возвращает или устанавливает Фамилию
        /// </summary>
        public string Surname
        {
            get => _surname;
            set
            {
                // При некорректной длинне Фамилии, выводим сообщение об ошибке
                //
                if (value.Length > 50 || value.Length < 2)
                {
                    throw new ArgumentException(
                        "Фамилия состоит из менее 2 или более 50 символов.");
                }

                // При наличии пустой строки, выводим сообщение
                // 
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Имеются незаполненные поля.");
                }
                else
                {
                    // Перевод строки на строку с Заглавной буквы
                    // И присвоение переменной
                    //
                    value = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value);
                    _surname = value;
                }
            }
        }

        /// <summary>
        /// Возварщает или устанавливает Имя
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                // При некорректной длинне Имени, выводим сообщение об ошибке
                //
                if (value.Length > 50 || value.Length < 2)
                {
                    throw new ArgumentException(
                        "Имя состоит из менее 2 или более 50 символов.");
                }

                // При наличии пустой строки, выводим сообщение
                // 
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Имеются незаполненные поля.");
                }

                else
                {
                    // Перевод строки на строку с Заглавной буквы
                    // И присвоение переменной
                    //
                    value = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value);
                    _name = value;
                }
            }
        }

        /// <summary>
        /// Возвращает или устанавливает Дату Рождения
        /// </summary>
        public DateTime DateOfBirth
        {
            get => _dateOfBirth;
            set
            {
                // Установка минимального значения Даты
                //
                DateTime dateMinimum = new DateTime(1900, 01, 01);

                // При некорректно введённой дате выводим сообщение
                //
                if (value < dateMinimum || value > DateTime.Now)
                {
                    throw new ArgumentException("Некорректно введённая Дата Рождения.");
                }

                else
                    _dateOfBirth = value;
            }
        }

        /// <summary>
        /// Возвращает или устанавливает E-mail
        /// </summary>
        public string Email
        {
            get => _email;
            set
            {
                // При некорректной длинне E-mail, выводим сообщение об ошибке
                //
                if (value.Length > 50 || value.Length < 2)
                {
                    throw new ArgumentException("E-mail состоит из менее 2 или более 50 символов.");
                }
                // При наличии пустой строки, выводим сообщение
                //
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Имеются незаполненные поля.");
                }
                else
                    _email = value;
            }
        }

        /// <summary>
        /// Метод, устанавливающий и возвращающий ID Vk контакта.
        /// </summary>
        public string IDVkcom
        {
            get => _idVkcom;
            set
            {
                // При некорректной длинне ID Вконтакте, выводим сообщение
                //
                if (value.Length > 15 || value.Length < 2)
                {
                    throw new ArgumentException("ID Вконтакте состоит из менее 2 или более 50 символов.");
                }
                // При наличии пустой строки выводим сообщение
                //
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Имеются незаполненные поля.");
                }
                else
                    _idVkcom = value;
            }
        }

        /// <summary>
        /// Клонирование объекта
        /// </summary>
        /// <returns>Возвращает клон объекта Contact</returns>
        public object Clone()
        {
            return new Contact(phoneNumber.Number, Name, Surname, Email, DateOfBirth, IDVkcom);
        }

    }
}
