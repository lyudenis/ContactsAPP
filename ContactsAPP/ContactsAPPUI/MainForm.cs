using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContactsApp;

namespace ContactsApp
{
    public partial class MainForm : Form
    {
        // Создаем список контактов.
        //
        private Project _project;
        public MainForm()
        {
            InitializeComponent();

            // Загрузка файла с контактами
            //
            _project = ProjectManager.LoadFromFile(ProjectManager.stringMyDocumentsPath);

            _project.ContactsList.Sort();
            // Загрузка в listBox контактов из ContactList
            //
            listBox1.DataSource = _project.ContactsList;
            listBox1.DisplayMember = "Surname";
            listBox1.ValueMember = "Name";

            Project birthContact = Project.Birthday(_project, DateTime.Today);
            if (birthContact.ContactsList.Count != 0)
            {
                panel2.Visible = true;
                for (int i = 0; i < birthContact.ContactsList.Count; i++)
                {
                    label9.Text = label9.Text + birthContact.ContactsList[i].Surname + ", ";
                }
            }
            else panel2.Visible = false;
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Вывод выбранного элемента из ListBox
        /// </summary>
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBox1.SelectedItem != null)
            {
                Contact c = (Contact)listBox1.SelectedItem;
                textBoxSurename.Text = c.Surname;
                textBoxName.Text = c.Name;
                textBoxEmail.Text = c.Email;
                textBoxIdvkcom.Text = c.IDVkcom;
                textBoxPhone.Text = c.phoneNumber.Number;
                dateTimePicker1.Value = c.DateOfBirth;
            }
        }

        /// <summary>
        /// Функция добавления контакта.
        /// </summary>
        private void AddContact()
        {
            var newForm = new AddEditForm();

            //Создаем переменную, в которую помещаем результат взаимодействия пользователя с формой.
            var resultOfDialog = newForm.ShowDialog();

            //Если пользователь нажал ОК, то вносим исправленные данные.
            if (resultOfDialog == DialogResult.OK)
            {
                var contact = newForm.Contact;
                _project.ContactsList.Add(contact);
                _project.ContactsList.Sort();
                ProjectManager.SaveToFile(_project, ProjectManager.stringMyDocumentsPath);

                listBox1.DataSource = null;
                listBox1.DataSource = _project.ContactsList;
                listBox1.DisplayMember = "Surname";
            }
        }

        /// <summary>
        /// Функция, выполняющая редактирование данных.
        /// </summary>
        private void EditContact()
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Choose the contact to edit.", "Edit");
            }

            // Открытие окна, загрузка выбранного контакта
            //
            Contact selectedContact = (Contact)listBox1.SelectedItem;
            var newForm = new AddEditForm();
            newForm.Contact = selectedContact;

            var resultOfDialog = newForm.ShowDialog();

            if(resultOfDialog == DialogResult.OK)
            {
                _project.ContactsList[listBox1.SelectedIndex] = newForm.Contact;
                ProjectManager.SaveToFile(_project, ProjectManager.stringMyDocumentsPath);
                UpdateListBox();
            }

        }

        /// <summary>
        /// Функция удаления контакта.
        /// </summary>
        private void RemoveContact()
        {
            int index = listBox1.SelectedIndex;
            if (index == -1)
            {
                MessageBox.Show("Choose the contact to remove.", "Remove");
            }

            // Если список не пуст.
            //
            if (_project.ContactsList.Count > 0)
            {
                string removeThisContact = "Do you really want to remove this contact: " + textBoxSurename.Text + "?";

                var result = MessageBox.Show(removeThisContact, "Remove", MessageBoxButtons.OKCancel);

                if (result == DialogResult.OK)
                {
                    _project.ContactsList.RemoveAt(index);
                    ProjectManager.SaveToFile(_project, ProjectManager.stringMyDocumentsPath);
                    UpdateListBox();
                }
                
            }
        }


        /// <summary>
        /// Обновление ListBox
        /// </summary>
        private void UpdateListBox()
        {
            listBox1.DataSource = null;
            if(_project != null)
            {
                listBox1.DataSource = _project.ContactsList;
                listBox1.DisplayMember = "Surname";
            }
        }

        /// <summary>
        /// Вызов окна добавления контакта
        /// </summary>
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddContact();
        }

        /// <summary>
        /// Вызов окна добавления контакта из выпадающего меню
        /// </summary>
        private void menuItem4_Click(object sender, EventArgs e)
        {
            AddContact();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            EditContact();
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            RemoveContact();
        }

        private void menuItem5_Click(object sender, EventArgs e)
        {
            EditContact();
        }

        private void menuItem6_Click(object sender, EventArgs e)
        {
            RemoveContact();
        }

        private void menuItem8_Click(object sender, EventArgs e)
        {
            var newForm = new AboutForm();
            newForm.Show();
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
            {
                _project = Project.Sort(_project, textBox1.Text);
                UpdateListBox();

                _project = ProjectManager.LoadFromFile(ProjectManager.stringMyDocumentsPath);
            }
            else
            {
                _project = ProjectManager.LoadFromFile(ProjectManager.stringMyDocumentsPath);
                UpdateListBox();
            }
        }

        /// <summary>
        /// Удаление контакта по нажатию клавиши Delete.
        /// </summary>
        private void ContactsListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                RemoveContact();
            }
        }
    }
}
