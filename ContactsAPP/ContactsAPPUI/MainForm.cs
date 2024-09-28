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
using ContactsAPP;
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
            var project = new Project();

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //Contact firstContact = new Contact();
            //firstContact.Name = "Alex";
            //firstContact.Birth = DateTime.Today;
            //firstContact.Sername = "Ivanov";
            //firstContact.Email = "some@email.ru";
            //firstContact.IdVk = "123456789";


            //ProjectManager.SaveToFile( ProjectManager.DocumentsPath);
            //JsonSerializer serializer = new JsonSerializer();

            ////Открываем поток для записи в файл с указанием пути
            //using (StreamWriter sw = new StreamWriter(@"C:\Users\Денис\json.txt"))
            //using (JsonWriter writer = new JsonTextWriter(sw))
            //{
            //    //Вызываем сериализацию и передаем объект, который хотим сериализовать
            //    serializer.Serialize(writer, firstContact);
            //}

            Contact secondContact = null;
            //Создаём экземпляр сериализатора
            JsonSerializer serializer = new JsonSerializer();
            //Открываем поток для чтения из файла с указанием пути
            using (StreamReader sr = new StreamReader(@"C:\Users\Денис\json.txt"))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                //Вызываем десериализацию и явно преобразуем результат в целевой тип данных
                secondContact = (Contact)serializer.Deserialize<Contact>(reader);
            }

            Console.WriteLine(secondContact.Name);
            Console.WriteLine(secondContact.Sername);
            Console.WriteLine(secondContact.Birth);
            Console.WriteLine(secondContact.Email);
            //Console.WriteLine(secondContact.Phone);





        }
    }
}
