using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContactsApp;
using Newtonsoft.Json;

namespace ContactsAPPUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.Text = "Главное окно программы";
            this.Size = new Size(400, 250);
            this.Location = new Point(150, 150);
            ColorComboBox.Items.Add(Color.Red);
            ColorComboBox.Items.Add(Color.Green);
            ColorComboBox.Items.Add(Color.Blue);
            ColorComboBox.Items.Add(Color.White);
            ColorComboBox.SelectedIndex = 1;

            /*//Создаем кнопку
            var button = new Button();
            button.Text = "Сменить заголовок окна";
            button.Size = new Size(150, 25);
            button.Location = new Point(150, 150);

            //Подписываем кнопку на обработчик
            button.Click += Button_Click;
            //Помещаем кнопку на форму
            this.Controls.Add(button);*/
        }
        
        //Обработчик события нажатия кнопки
        private void Button_Click(object sender, EventArgs e)
        {
            //Здесь пишем код, который должен выполняться
            //Каждый раз при нажатии на кнопку.
            this.Text = "Новый заголовок";
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void NumberTextBox_TextChanged(object sender, EventArgs e)
        {
            //Получаем текст из текстового поля
            // в переменную типа string
            string text = NumberTextBox.Text;
            int number;
            if (int.TryParse(text, out number))
            {
                if (number >= 0 && number <= 100)
                {
                    NumberTextBox.BackColor = Color.White;
                    this.Text = number.ToString();
                }
                else
                {
                    NumberTextBox.BackColor = Color.LightSalmon;
                }
            }
            else
            {
                NumberTextBox.BackColor = Color.LightSalmon;
            }
        }

        private void ColorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ColorComboBox.SelectedIndex == -1)
            {
                //Если ничего не выбрано, завершаем обработчик
                return;
            }
            Color selectedColor;
            selectedColor = (Color)ColorComboBox.SelectedItem;
            this.BackColor = selectedColor;
        }

        private void VisibilityCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = VisibilityCheckBox.Checked;
            ColorComboBox.Visible = isChecked;
        }
    }

}