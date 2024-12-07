using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactsApp
{
    public partial class AddEditForm : Form
    {
        // Создаем новый контакт.
        //
        private Contact _сontact = new Contact();

        // Строка, в которую записывается текст ошибки.
        //
        private string _textException;

        // Флаг, в котором хранится верно ли заполнено поле Surname.
        //
        private bool buttonOKisAvailableToClick_Surname = false;
        private bool buttonOKisAvailableToClick_Name = false;
        private bool buttonOKisAvailableToClick_Birthday = false;
        private bool buttonOKisAvailableToClick_Phone = false;
        private bool buttonOKisAvailableToClick_Email = false;
        private bool buttonOKisAvailableToClick_IdVk = false;

        // Метод, устанавливающий и возвращающий данные о контакте.
        //
        public Contact Contact
        {
            get { return _сontact; }
            set
            {
                _сontact.Surname = value.Surname;
                _сontact.Name = value.Name;
                _сontact.phoneNumber.Number = value.phoneNumber.Number;
                _сontact.DateOfBirth = value.DateOfBirth;
                _сontact.Email = value.Email;
                _сontact.IDVkcom = value.IDVkcom;

            }
        }

        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public AddEditForm()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Запись в DialogResult "OK" при нажатии "ОК".
        /// </summary>
        private void buttonOk_Click(object sender, EventArgs e)
        {
            // Если все поля заполнены верно, то разрешаем нажатие кнопки ОК.
            //
            if (buttonOKisAvailableToClick_Surname && buttonOKisAvailableToClick_Name &&
                buttonOKisAvailableToClick_Birthday && buttonOKisAvailableToClick_Phone &&
                buttonOKisAvailableToClick_Email && buttonOKisAvailableToClick_IdVk == true)
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }

            // Иначе выводим сообщение об ошибке и кнопка не активна.
            //
            else
            {
                buttonOk.Enabled = false;
                ToolTip okToolTip = new ToolTip();

                okToolTip.Show("Form has incorrect values.", buttonOk,
                    (Point)(textBoxSurename.Size + new Size(-500, 10)), 1000);


                // Разрешаем кнопке реагировать на нажатия.
                //
                buttonOk.Enabled = true;
            }
        }

        /// <summary>
        /// Запись в DialogResult "Cancel" при нажатии "Cancel".
        /// </summary>
        private void buttonCancel_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Считывает фамилию контакта с TextBox
        /// </summary>
        private void textBoxSurename_TextChanged_1(object sender, EventArgs e)
        {
            int countException = 0;
            ToolTip surnameToolTip = new ToolTip();

            try
            {
                _сontact.Surname = textBoxSurename.Text;

                // Разрешаем нажатие кнопки Ок из TextBox surname.
                //
                buttonOKisAvailableToClick_Surname = true;
            }
            catch (Exception exception)
            {
                _textException = exception.Message;
                countException++;

                // Переключаем флаг в false и запрещаем нажимать кнопку ОК.
                //
                buttonOKisAvailableToClick_Surname = false;

            }

            // Если произошла ошибка.
            //
            if (countException != 0)
            {
                textBoxSurename.BackColor = Color.LightSalmon;
                surnameToolTip.Show(_textException, textBoxSurename,
                    (Point)(textBoxSurename.Size + new Size(-400, 10)), 1000);
            }
            else
            {
                textBoxSurename.BackColor = Color.White;
            }
        }

        /// <summary>
        /// Считывает имя контакта с TextBox
        /// </summary>
        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            int countException = 0;
            ToolTip nameToolTip = new ToolTip();

            try
            {
                _сontact.Name = textBoxName.Text;

                // Разрешаем нажатие кнопки Ок из TextBox name.
                //
                buttonOKisAvailableToClick_Name = true;
            }
            catch (Exception exception)
            {
                _textException = exception.Message;
                countException++;
                buttonOKisAvailableToClick_Name = false;
            }

            // Если произошла ошибка.
            //
            if (countException != 0)
            {
                textBoxName.BackColor = Color.LightSalmon;
                nameToolTip.Show(_textException, textBoxName,
                    (Point)(textBoxName.Size + new Size(-400, 10)), 1000);
            }
            else
            {
                textBoxName.BackColor = Color.White;
            }
        }

        /// <summary>
        /// Считывает дату рождения контакта с TextBox
        /// </summary>
        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {
            int countException = 0;
            ToolTip dateOfBirthToolTip = new ToolTip();

            try
            {
                _сontact.DateOfBirth = dateTimePicker1.Value;

                // Разрешаем нажатие кнопки Ок из TextBox BirthdaytimePicker.
                //
                buttonOKisAvailableToClick_Birthday = true;
            }
            catch (Exception exception)
            {
                _textException = exception.Message;
                countException++;

                // Переключаем флаг в false и запрещаем нажимать кнопку ОК.
                //
                buttonOKisAvailableToClick_Birthday = false;
            }

            // Если произошла ошибка.
            //
            if (countException != 0)
            {
                label3.ForeColor = Color.LightSalmon;
                //dateTimePicker1.BackColor = Color.LightSalmon;
                dateOfBirthToolTip.Show(_textException, dateTimePicker1,
                    (Point)(dateTimePicker1.Size + new Size(-163, 10)), 1000);
            }
            else
            {
                label3.ForeColor = Color.Black;
                //dateTimePicker1.BackColor = Color.White;
            }
        }

        /// <summary>
        /// Считывает номер телефона контакта с TextBox
        /// </summary>
        private void textBoxPhone_TextChanged(object sender, EventArgs e)
        {
            int countException = 0;
            ToolTip phoneToolTip = new ToolTip();

            try
            {
                // Заполняем данные из TextBox*а, если в строке есть символы.
                //
                if (textBoxPhone.Text.Length != 0)
                {
                    _сontact.phoneNumber.Number = textBoxPhone.Text;

                    // Разрешаем нажатие кнопки Ок из TextBox phone.
                    //
                    buttonOKisAvailableToClick_Phone = true;
                }
                else
                {
                    countException++;
                    phoneToolTip.Show("Filed is empty.", textBoxPhone,
                        (Point)(textBoxPhone.Size + new Size(-400, 10)), 1000);

                    // Переключаем флаг в false и запрещаем нажимать кнопку ОК.
                    //
                    buttonOKisAvailableToClick_Phone = false;
                }
            }

            catch (ArgumentException exception)
            {
                _textException = exception.Message;
                countException++;

                // Переключаем флаг в false и запрещаем нажимать кнопку ОК.
                //
                buttonOKisAvailableToClick_Phone = false;
            }

            // Если произошла ошибка.
            //
            if (countException != 0)
            {
                textBoxPhone.BackColor = Color.LightSalmon;
                phoneToolTip.Show(_textException, textBoxPhone,
                    (Point)(textBoxPhone.Size + new Size(-400, 10)), 1000);
            }
            else
            {
                textBoxPhone.BackColor = Color.White;
            }
        }

        /// <summary>
        /// Считывает e-mail контакта с TextBox
        /// </summary>
        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {
            int countException = 0;
            ToolTip emailToolTip = new ToolTip();

            try
            {
                _сontact.Email = textBoxEmail.Text;

                // Разрешаем нажатие кнопки Ок из TextBox email.
                //
                buttonOKisAvailableToClick_Email = true;
            }

            catch (Exception exception)
            {
                _textException = exception.Message;
                countException++;

                // Переключаем флаг в false и запрещаем нажимать кнопку ОК.
                //
                buttonOKisAvailableToClick_Email = false;
            }

            // Если произошла ошибка.
            //
            if (countException != 0)
            {
                textBoxEmail.BackColor = Color.LightSalmon;
                emailToolTip.Show(_textException, textBoxEmail,
                    (Point)(textBoxEmail.Size + new Size(-400, 10)), 1000);
            }
            else
            {
                textBoxEmail.BackColor = Color.White;
            }
        }

        /// <summary>
        /// Считывает Id vk контакта с TextBox
        /// </summary>
        private void textBoxIdvkcom_TextChanged(object sender, EventArgs e)
        {
            int countException = 0;
            ToolTip idVkToolTip = new ToolTip();

            try
            {
                _сontact.IDVkcom = textBoxIdvkcom.Text;

                // Разрешаем нажатие кнопки Ок из TextBox Id Vk.
                //
                buttonOKisAvailableToClick_IdVk = true;
            }

            catch (Exception exception)
            {
                _textException = exception.Message;
                countException++;

                // Переключаем флаг в false и запрещаем нажимать кнопку ОК.
                //
                buttonOKisAvailableToClick_IdVk = false;
            }

            // Если произошла ошибка.
            //
            if (countException != 0)
            {
                textBoxIdvkcom.BackColor = Color.LightSalmon;
                idVkToolTip.Show(_textException, textBoxIdvkcom,
                    (Point)(textBoxIdvkcom.Size + new Size(-400, 10)), 1000);
            }
            else
            {
                textBoxIdvkcom.BackColor = Color.White;
            }
        }

        /// <summary>
        /// Заполняет форму для дальнейшего редактирования данных.
        /// </summary>
        private void AddEditForm_Load(object sender, EventArgs e)
        {
            // Если выбран какой-либо контакт.
            //
            if (_сontact.Surname != null)
            {
                // Заполняем форму данными выбранного контакта.
                //
                textBoxSurename.Text = _сontact.Surname;
                textBoxName.Text = _сontact.Name;
                dateTimePicker1.Value = _сontact.DateOfBirth;
                textBoxPhone.Text = _сontact.phoneNumber.Number.ToString();
                textBoxEmail.Text = _сontact.Email;
                textBoxIdvkcom.Text = _сontact.IDVkcom;
            }
        }

        /// <summary>
        /// Защита ввода данных в Surname TextBox, формы AddEditContact.
        /// </summary>
        private void SurnameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Проверка на Backspace, позволяет очищать строку.
            //
            if (e.KeyChar == (char)Keys.Back)
                return;

            // Проверка на ввод, пропускающая только символы и дефис.
            //
            if (!char.IsLetter(e.KeyChar) && !(e.KeyChar == '-'))
                e.Handled = true;
        }

        /// <summary>
        /// Защита ввода данных в Name TextBox, формы AddEditContact.
        /// </summary>
        private void NameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Проверка на Backspace, позволяет очищать строку.
            //
            if (e.KeyChar == (char)Keys.Back)
                return;

            // Проверка на ввод, пропускающая только символы и дефис.
            //
            if (!char.IsLetter(e.KeyChar) && !(e.KeyChar == '-'))
                e.Handled = true;
        }

        /// <summary>
        /// Защита ввода данных в Phone TextBox, формы AddEditContact.
        /// </summary>
        private void PhoneTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            int i = 0;

            // Проверка на Backspace, позволяет очищать строку.
            //
            if (e.KeyChar == (char)Keys.Back)
                return;

            // Проверка на ввод, пропускающая только цифры.
            //
            if (!char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
                i++;
            }

            // Ограничение на ввод 11 символов.
            //
            textBoxPhone.MaxLength = 11;
        }
    }
}
