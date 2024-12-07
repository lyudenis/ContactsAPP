using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
    /// <summary>
    /// Отдкльный класс для Номер Телефона
    /// </summary>
    public class PhoneNumber
    {
        private string _number;

        /// <summary>
        /// Возвращает или задаёт значение номера телефона
        /// </summary>
        public string Number
        {
            get => _number;
            set
            {
                // При некорректной длине номера, выводим сообщение
                //
                if (value.Length != 11)
                {
                    throw new ArgumentException("Номер телефона должен состоять из 11 цифр. Например: 79991234567");
                }

                // При отсутствии цифры 7 в начале, выводим сообщение
                //
                if (value[0] != '7')
                {
                    throw new ArgumentException("Номер телефона должен начинатся с цифры 7. Например: 79991234567");
                }

                else
                {
                    _number = value;
                }
            }
        }
    }
}
