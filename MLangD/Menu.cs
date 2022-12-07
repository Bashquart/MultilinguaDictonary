using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Application = Microsoft.Office.Interop.Excel.Application;
using Excel = Microsoft.Office.Interop.Excel;
using SD = System.Data;

namespace MLangD
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }
        public MySqlConnection myconnection;
        public MySqlCommand mycommand;
        public string connect = "Database=mlangdb;Data Source=localhost;User Id=root; Old Guids=true";
        public SD.DataSet ds;

        private void button1_Click_1(object sender, EventArgs e)
        {
            //LogIn newForm = new LogIn();
            //newForm.Show();
            //this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Menu_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "mlangdbDataSet.tt_lang". При необходимости она может быть перемещена или удалена.
            this.tt_langTableAdapter1.Fill(this.mlangdbDataSet.tt_lang);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "mlangdbDataSet.ru_lang". При необходимости она может быть перемещена или удалена.
            this.ru_langTableAdapter.Fill(this.mlangdbDataSet.ru_lang);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "mlangdbDataSet.en_lang". При необходимости она может быть перемещена или удалена.
            this.en_langTableAdapter1.Fill(this.mlangdbDataSet.en_lang);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "mlangdbDataSet.bayu_lang". При необходимости она может быть перемещена или удалена.
            this.bayu_langTableAdapter.Fill(this.mlangdbDataSet.bayu_lang);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "mlangdbDataSet.ba_lang". При необходимости она может быть перемещена или удалена.
            this.ba_langTableAdapter.Fill(this.mlangdbDataSet.ba_lang);

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            string QueryOfCtegory = null;
            string WhereParam = null;
            int LangSelectedIndex = checkedListBox1.SelectedIndex;
            int CatSelectedIndex = listBox1.SelectedIndex;
            switch (CatSelectedIndex)
            {
                case 50:
                    WhereParam = "Minecraft Translators Words";
                    break;
                case 49:
                    WhereParam = "Список слов Сводеша";
                    break;
                case 48:
                    WhereParam = "Юриспруденция";
                    break;
                case 47:
                    WhereParam = "Экономика";
                    break;
                case 46:
                    WhereParam = "Экология";
                    break;
                case 45:
                    WhereParam = "Числа";
                    break;
                case 44:
                    WhereParam = "Цветы";
                    break;
                case 43:
                    WhereParam = "Цвета";
                    break;
                case 42:
                    WhereParam = "Хобби";
                    break;
                case 41:
                    WhereParam = "Характер";
                    break;
                case 40:
                    WhereParam = "Фотография";
                    break;
                case 39:
                    WhereParam = "Транспорт";
                    break;
                case 38:
                    WhereParam = "Строительство";
                    break;
                case 37:
                    WhereParam = "Спорт";
                    break;
                case 36:
                    WhereParam = "Социальные сети";
                    break;
                case 35:
                    WhereParam = "СМИ";
                    break;
                case 34:
                    WhereParam = "Семья";
                    break;
                case 33:
                    WhereParam = "Рыбы";
                    break;
                case 32:
                    WhereParam = "Путешествия";
                    break;
                case 31:
                    WhereParam = "Психология";
                    break;
                case 30:
                    WhereParam = "Политика";
                    break;
                case 29:
                    WhereParam = "Одежда";
                    break;
                case 28:
                    WhereParam = "Музыка";
                    break;
                case 27:
                    WhereParam = "Мебель";
                    break;
                case 26:
                    WhereParam = "Математика";
                    break;
                case 25:
                    WhereParam = "Маркетинг";
                    break;
                case 24:
                    WhereParam = "Магазины";
                    break;
                case 23:
                    WhereParam = "Литература";
                    break;
                case 22:
                    WhereParam = "Космос";
                    break;
                case 21:
                    WhereParam = "Компьютер";
                    break;
                case 20:
                    WhereParam = "Кино";
                    break;
                case 19:
                    WhereParam = "Карьера";
                    break;
                case 18:
                    WhereParam = "Искусство";
                    break;
                case 17:
                    WhereParam = "Знаки зодиака";
                    break;
                case 16:
                    WhereParam = "Здоровье";
                    break;
                case 15:
                    WhereParam = "Животные";
                    break;
                case 14:
                    WhereParam = "Еда";
                    break;
                case 13:
                    WhereParam = "Дом";
                    break;
                case 12:
                    WhereParam = "Деревья, кустарники";
                    break;
                case 11:
                    WhereParam = "Деньги";
                    break;
                case 10:
                    WhereParam = "Город";
                    break;
                case 9:
                    WhereParam = "География";
                    break;
                case 8:
                    WhereParam = "Вещи";
                    break;
                case 7:
                    WhereParam = "Время года, календарь";
                    break;
                case 6:
                    WhereParam = "Военное дело, оружие";
                    break;
                case 5:
                    WhereParam = "Внешность";
                    break;
                case 4:
                    WhereParam = "Бизнес";
                    break;
                case 3:
                    WhereParam = "Базовые глаголы";
                    break;
                case 2:
                    WhereParam = "Архитектура";
                    break;
                case 1:
                    WhereParam = "Археология";
                    break;
                case 0:
                    WhereParam = "Анатомия";
                    break;
            }
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = myconnection;
            cmd.CommandText = QueryOfCtegory;

            switch (LangSelectedIndex)
            {
                case 0:
                    QueryOfCtegory = "select en_lang.EnglishWords as 'Английский', ba_lang.BashkirWords as 'Башкирский', categories.catname as 'Категория', PartOfSpeech.name_part_speech as 'Часть речи' from Bash_Eng inner join en_lang on Bash_Eng.en_us = en_lang.englang_id inner join ba_lang on Bash_Eng.ba_ru = ba_lang.bashlang_id inner join categories on Bash_Eng.category = categories.catnum inner join PartOfSpeech on PartOfSpeech.part_speech_num = Bash_Eng.part_speech  where categories.catname='" + WhereParam + "'";
                    break;
                case 1:
                    QueryOfCtegory = "select en_lang.EnglishWords as 'Английский', ru_lang.RussianWords as 'Русский', categories.catname as 'Категория', PartOfSpeech.name_part_speech as 'Часть речи' from Eng_Rus inner join en_lang on Eng_Rus.en_us = en_lang.englang_id inner join ru_lang on Eng_Rus.ru_ru = ru_lang.rulang_id inner join categories on Eng_Rus.category = categories.catnum inner join PartOfSpeech on PartOfSpeech.part_speech_num = Eng_Rus.part_speech  where categories.catname='" + WhereParam + "'";
                    break;
                case 2:
                    QueryOfCtegory = "select en_lang.EnglishWords as 'Английский', tt_lang.TatarWords as 'Татарский', categories.catname as 'Категория', PartOfSpeech.name_part_speech as 'Часть речи' from Eng_Tat inner join en_lang on Eng_Tat.en_us = en_lang.englang_id inner join tt_lang on Eng_Tat.tt_ru = tt_lang.tatlang_id inner join categories on Eng_Tat.category = categories.catnum inner join PartOfSpeech on PartOfSpeech.part_speech_num = Eng_Tat.part_speech  where categories.catname='" + WhereParam + "'";
                    break;
                case 3:
                    QueryOfCtegory = "select en_lang.EnglishWords as 'Английский', bayu_lang.YurmatinWords as 'Южный диалект башкирского', categories.catname as 'Категория', PartOfSpeech.name_part_speech as 'Часть речи' from SouthBash_Eng inner join en_lang on SouthBash_Eng.en_us = en_lang.englang_id inner join bayu_lang on SouthBash_Eng.bayu_ru = bayu_lang.southbashlang_id inner join categories on SouthBash_Eng.category = categories.catnum inner join PartOfSpeech on PartOfSpeech.part_speech_num = SouthBash_Eng.part_speech where categories.catname='" + WhereParam + "' group by en_lang.EnglishWords";
                    break;
                case 4:
                    QueryOfCtegory = "select ba_lang.BashkirWords as 'Башкирский', ru_lang.RussianWords as 'Русский', categories.catname as 'Категория', PartOfSpeech.name_part_speech as 'Часть речи' from Bash_Rus inner join ru_lang on Bash_Rus.ru_ru = ru_lang.rulang_id inner join ba_lang on Bash_Rus.ba_ru = ba_lang.bashlang_id inner join categories on Bash_Rus.category = categories.catnum inner join PartOfSpeech on PartOfSpeech.part_speech_num = Bash_Rus.part_speech  where categories.catname='" + WhereParam + "'";
                    break;
                case 5:
                    QueryOfCtegory = "select ba_lang.BashkirWords as 'Башкирский', tt_lang.TatarWords as 'Татарский', categories.catname as 'Категория', PartOfSpeech.name_part_speech as 'Часть речи' from Bash_Tat inner join tt_lang on Bash_Tat.tt_ru = tt_lang.tatlang_id inner join ba_lang on Bash_Tat.ba_ru = ba_lang.bashlang_id inner join categories on Bash_Tat.category = categories.catnum inner join PartOfSpeech on PartOfSpeech.part_speech_num = Bash_Tat.part_speech  where categories.catname='" + WhereParam + "'";
                    break;
                case 6:
                    QueryOfCtegory = "select ba_lang.BashkirWords as 'Башкирский', bayu_lang.YurmatinWords as 'Южный диалект', categories.catname as 'Категория', PartOfSpeech.name_part_speech as 'Часть речи' from SouthBash_Bash inner join bayu_lang on SouthBash_Bash.bayu_ru = bayu_lang.southbashlang_id inner join ba_lang on SouthBash_Bash.ba_ru = ba_lang.bashlang_id inner join categories on SouthBash_Bash.category = categories.catnum inner join PartOfSpeech on PartOfSpeech.part_speech_num = SouthBash_Bash.part_speech  where categories.catname='" + WhereParam + "' group by ba_lang.BashkirWords";
                    break;
                case 7:
                    QueryOfCtegory = "select ru_lang.RussianWords as 'Русский', tt_lang.TatarWords as 'Татарский', categories.catname as 'Категория', PartOfSpeech.name_part_speech as 'Часть речи' from Rus_Tat inner join ru_lang on Rus_Tat.ru_ru = ru_lang.rulang_id inner join tt_lang on Rus_Tat.tt_ru = tt_lang.tatlang_id inner join categories on Rus_Tat.category = categories.catnum inner join PartOfSpeech on PartOfSpeech.part_speech_num = Rus_Tat.part_speech  where categories.catname='" + WhereParam + "'";
                    break;
                case 8:
                    QueryOfCtegory = "select ru_lang.RussianWords as 'Русский', bayu_lang.YurmatinWords as 'Южный диалект башкирского', categories.catname as 'Категория', PartOfSpeech.name_part_speech as 'Часть речи' from SouthBash_Rus inner join ru_lang on SouthBash_Rus.ru_ru = ru_lang.rulang_id inner join bayu_lang on SouthBash_Rus.bayu_ru = bayu_lang.southbashlang_id inner join categories on SouthBash_Rus.category = categories.catnum inner join PartOfSpeech on PartOfSpeech.part_speech_num = SouthBash_Rus.part_speech where categories.catname='" + WhereParam + "' group by ru_lang.RussianWords";
                    break;
                case 9:
                    QueryOfCtegory = "select bayu_lang.YurmatinWords  as 'Южный диалект', tt_lang.TatarWords as 'Татарский', categories.catname as 'Категория', PartOfSpeech.name_part_speech as 'Часть речи' from SouthBash_Tat inner join bayu_lang on SouthBash_Tat.bayu_ru = bayu_lang.southbashlang_id inner join tt_lang on SouthBash_Tat.tt_ru = tt_lang.tatlang_id inner join categories on SouthBash_Tat.category = categories.catnum inner join PartOfSpeech on PartOfSpeech.part_speech_num = SouthBash_Tat.part_speech where categories.catname='" + WhereParam + "' group by bayu_lang.YurmatinWords";
                    break;
            }
            try
            {
                myconnection = new MySqlConnection(connect);
                myconnection.Open();
                MySqlDataAdapter grid_data = new MySqlDataAdapter(QueryOfCtegory, connect);
                SD.DataTable table = new SD.DataTable();
                grid_data.Fill(table);
                dgv.DataSource = table;
                myconnection.Close();
            }
            catch
            {

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 0)
            {
                int i, j = 0;
                Excel.Application xcelApp = new Excel.Application();
                xcelApp.Application.Workbooks.Add(Type.Missing);

                for (i = 0; i <= dgv.Rows.Count - 2; i++)
                {
                    for (j = 0; j <= dgv.Columns.Count - 1; j++)
                    {
                        xcelApp.Cells[i + 1, j + 1] = dgv.Rows[i].Cells[j].Value.ToString();
                    }
                }
                xcelApp.Columns.AutoFit();
                xcelApp.Visible = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int Item = 0;
            string Item1 = null;
            Item = comboBox1.SelectedIndex;
            Item1 = richTextBox1.Text;
            comboBox1.SelectedIndex = comboBox2.SelectedIndex;
            richTextBox1.Text = richTextBox2.Text;
            comboBox2.SelectedIndex = Item;
            richTextBox2.Text = Item1;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string СтрокаВхода = "Database=mlangdb;Data Source=localhost;User Id=root;Password=20022015220; Old Guids=true";
            MySqlConnection Вход = new MySqlConnection(СтрокаВхода);

            string TranslateQuery = null;
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    switch (comboBox2.SelectedIndex)
                    {
                        case 0:
                            TranslateQuery = "select count(en_lang.EnglishWords) from en_lang where EnglishWords='" + richTextBox1.Text + "'";
                            break;
                        case 1:
                            TranslateQuery = "select ba_lang.BashkirWords as 'Башкирский' from Bash_Eng inner join ba_lang on Bash_Eng.ba_ru = ba_lang.bashlang_id inner join en_lang on Bash_Eng.en_us = en_lang.englang_id where en_lang.EnglishWords ='" + richTextBox1.Text + "'";
                            break;
                        case 2:
                            TranslateQuery = "select ru_lang.RussianWords as 'Русский' from Eng_Rus inner join ru_lang on Eng_Rus.ru_ru = ru_lang.rulang_id inner join en_lang on Eng_Rus.en_us = en_lang.englang_id where en_lang.EnglishWords ='" + richTextBox1.Text + "'";
                            break;
                        case 3:
                            TranslateQuery = "select tt_lang.TatarWords as 'Татарский' from Eng_Tat inner join tt_lang on Eng_Tat.tt_ru = tt_lang.tatlang_id inner join en_lang on Eng_Tat.en_us = en_lang.englang_id where en_lang.EnglishWords ='" + richTextBox1.Text + "'";
                            break;
                        case 4:
                            TranslateQuery = "select bayu_lang.YurmatinWords as 'Южный диалект башкирского' from SouthBash_Eng inner join en_lang on SouthBash_Eng.en_us = en_lang.englang_id inner join bayu_lang on SouthBash_Eng.bayu_ru = bayu_lang.southbashlang_id where en_lang.EnglishWords ='" + richTextBox1.Text + "' group by en_lang.EnglishWords";
                            break;
                    }
                    break;
                case 1:
                    switch (comboBox2.SelectedIndex)
                    {
                        case 0:
                            TranslateQuery = "select en_lang.EnglishWords as 'Английский' from Bash_Eng inner join en_lang on Bash_Eng.en_us = en_lang.englang_id inner join ba_lang on Bash_Eng.ba_ru = ba_lang.bashlang_id where ba_lang.BashkirWords  ='" + richTextBox1.Text + "'";
                            break;
                        case 1:
                            TranslateQuery = "select count(ba_lang.BashkirWords) from ba_lang where BashkirWords='" + richTextBox1.Text + "'";
                            break;
                        case 2:
                            TranslateQuery = "select ru_lang.RussianWords as 'Русский' from Bash_Rus inner join ru_lang on Bash_Rus.ru_ru = ru_lang.rulang_id inner join ba_lang on Bash_Rus.ba_ru = ba_lang.bashlang_id where ba_lang.BashkirWords = '" + richTextBox1.Text + "'";
                            break;
                        case 3:
                            TranslateQuery = "select tt_lang.TatarWords as 'Татарский' from Bash_Tat inner join tt_lang on Bash_Tat.tt_ru = tt_lang.tatlang_id inner join ba_lang on Bash_Tat.ba_ru = ba_lang.bashlang_id where ba_lang.BashkirWords = '" + richTextBox1.Text + "'";
                            break;
                        case 4:
                            TranslateQuery = "select bayu_lang.YurmatinWords as 'Южный диалект башкирского' from SouthBash_Bash inner join bayu_lang on SouthBash_Bash.bayu_ru = bayu_lang.southbashlang_id inner join ba_lang on SouthBash_Bash.ba_ru = ba_lang.bashlang_id where bayu_lang.YurmatinWords = '" + richTextBox1.Text + "' group by ba_lang.BashkirWords";
                            break;
                    }
                    break;

                case 2:
                    switch (comboBox2.SelectedIndex)
                    {
                        case 0:
                            TranslateQuery = "select en_lang.EnglishWords as 'Английский' from Eng_Rus inner join en_lang on Eng_Rus.en_us = en_lang.englang_id inner join ru_lang on Eng_Rus.ru_ru = ru_lang.rulang_id where ru_lang.RussianWords ='" + richTextBox1.Text + "'";
                            break;
                        case 1:
                            TranslateQuery = "select ba_lang.BashkirWords as 'Башкирский' from Bash_Rus inner join ba_lang on Bash_Rus.ba_ru = ba_lang.bashlang_id inner join ru_lang on Bash_Rus.ru_ru = ru_lang.rulang_id where ru_lang.RussianWords = '" + richTextBox1.Text + "'";
                            break;
                        case 2:
                            TranslateQuery = "select count(ru_lang.RussianWords) from ru_lang where RussianWords='" + richTextBox1.Text + "'";
                            break;
                        case 3:
                            TranslateQuery = "select tt_lang.TatarWords as 'Татарский' from Rus_Tat inner join tt_lang on Rus_Tat.tt_ru = tt_lang.tatlang_id inner join ru_lang on Rus_Tat.ru_ru = ru_lang.rulang_id where ru_lang.RussianWords = '" + richTextBox1.Text + "'";
                            break;
                        case 4:
                            TranslateQuery = "select bayu_lang.YurmatinWords as 'Южный диалект башкирского' from SouthBash_Rus inner join bayu_lang on SouthBash_Rus.bayu_ru = bayu_lang.southbashlang_id inner join ru_lang on SouthBash_Rus.ru_ru = ru_lang.rulang_id where ru_lang.RussianWords = '" + richTextBox1.Text + "' group by ru_lang.RussianWords";
                            break;
                    }
                    break;
                case 3:
                    switch (comboBox2.SelectedIndex)
                    {
                        case 0:
                            TranslateQuery = "select en_lang.EnglishWords as 'Английский' from Eng_Tat inner join en_lang on Eng_Tat.en_us = en_lang.englang_id inner join tt_lang on Eng_Tat.tt_ru = tt_lang.tatlang_id where tt_lang.TatarWords ='" + richTextBox1.Text + "'";
                            break;
                        case 1:
                            TranslateQuery = "select ba_lang.BashkirWords as 'Башкирский' from Bash_Tat inner join ba_lang on Bash_Tat.ba_ru = ba_lang.bashlang_id inner join tt_lang on Bash_Tat.tt_ru = tt_lang.tatlang_id where tt_lang.TatarWords = '" + richTextBox1.Text + "'";
                            break;
                        case 2:
                            TranslateQuery = "select ru_lang.RussianWords as 'Русский' from Rus_Tat inner join ru_lang on Rus_Tat.ru_ru = ru_lang.rulang_id inner join tt_lang on Rus_Tat.tt_ru = tt_lang.tatlang_id where tt_lang.TatarWords = '" + richTextBox1.Text + "'";
                            break;
                        case 3:
                            TranslateQuery = "select count(tt_lang.TatarWords) from tt_lang where TatarWords='" + richTextBox1.Text + "'";
                            break;
                        case 4:
                            TranslateQuery = "select bayu_lang.YurmatinWords as 'Южный диалект башкирского' from SouthBash_Tat inner join bayu_lang on SouthBash_Tat.bayu_ru = bayu_lang.southbashlang_id inner join tt_lang on SouthBash_Tat.tt_ru = tt_lang.tatlang_id where tt_lang.TatarWords = '" + richTextBox1.Text + "' group by bayu_lang.YurmatinWords";
                            break;
                    }
                    break;
                case 4:
                    switch (comboBox2.SelectedIndex)
                    {
                        case 0:
                            TranslateQuery = "select en_lang.EnglishWords as 'Английский' from SouthBash_Eng inner join en_lang on SouthBash_Eng.en_us = en_lang.englang_id inner join bayu_lang on SouthBash_Eng.bayu_ru = bayu_lang.southbashlang_id where bayu_lang.YurmatinWords ='" + richTextBox1.Text + "' group by en_lang.EnglishWords";
                            break;
                        case 1:
                            TranslateQuery = "select ba_lang.BashkirWords as 'Башкирский' from SouthBash_Bash inner join ba_lang on SouthBash_Bash.ba_ru = ba_lang.bashlang_id inner join bayu_lang on SouthBash_Bash.bayu_ru = bayu_lang.southbashlang_id where bayu_lang.YurmatinWords = '" + richTextBox1.Text + "' group by ba_lang.BashkirWords";
                            break;
                        case 2:
                            TranslateQuery = "select ru_lang.RussianWords as 'Русский' from SouthBash_Rus inner join ru_lang on SouthBash_Rus.ru_ru = ru_lang.rulang_id inner join bayu_lang on SouthBash_Rus.bayu_ru = bayu_lang.southbashlang_id where bayu_lang.YurmatinWords = '" + richTextBox1.Text + "' group by ru_lang.RussianWords ";
                            break;
                        case 3:
                            TranslateQuery = "select tt_lang.TatarWords as 'Татарский' from SouthBash_Tat inner join tt_lang on SouthBash_Tat.tt_ru = tt_lang.tatlang_id inner join bayu_lang on SouthBash_Tat.bayu_ru = bayu_lang.southbashlang_id where bayu_lang.YurmatinWords = '" + richTextBox1.Text + "' group by bayu_lang.YurmatinWords";
                            break;
                        case 4:
                            TranslateQuery = "select count(bayu_lang.YurmatinWords) from bayu_lang where YurmatinWords='" + richTextBox1.Text + "'";
                            break;
                    }
                    break;
            }
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                MySqlDataReader reader = null;
                Вход.Open();
                MySqlCommand TranslatedWordCommand = new MySqlCommand(TranslateQuery, Вход);
                string TranslatedWord = TranslatedWordCommand.ExecuteScalar().ToString();
                switch (TranslatedWord)
                {
                    case "0":
                        richTextBox2.Text = " ";
                        break;
                    default:
                        richTextBox2.Text = TranslatedWord;
                        break;
                }
            }
            catch
            {
                richTextBox2.Text = "Для данной фразы пока нет перевода, но мы работаем над этим...";
            }
            Вход.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //LogIn newForm = new LogIn();
            //newForm.Show();
            //this.Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            string Lang1 = textBox1.Text;
            string Lang2 = textBox3.Text;
            string Lang3 = textBox4.Text;
            string Lang4 = textBox5.Text;
            string Lang5 = textBox2.Text;
            string Category = comboBox3.Text;
            string PartOfSpeech = comboBox4.Text;
            const string Connect = "Database=mlangdb;Data Source=localhost;User Id=root;Password=20022015220; Old Guids=true";
            MySqlConnection conn = new MySqlConnection(Connect);
            conn.Open(); //Устанавливаем соединение с базой данных.
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                cmd.Connection = conn;
                cmd.CommandText = @"INSERT INTO `en_lang`(`EnglishWords`) VALUES (@Lang1); INSERT INTO `ru_lang`(`RussianWords`) VALUES(@Lang2); INSERT INTO `ba_lang`(`BashkirWords`) VALUES(@Lang3); INSERT INTO `tt_lang`(`TatarWords`) VALUES(@Lang4); INSERT INTO `bayu_lang`(`YurmatinWords`) VALUES(@Lang5); INSERT INTO `Bash_Eng`(`ba_ru`, `en_us`, `category`, `part_speech`) VALUES((select bashlang_id from ba_lang where BashkirWords = @Lang3), (select englang_id from en_lang where EnglishWords = @Lang1), (SELECT `catnum` from categories where catname = @Category), (SELECT `part_speech_num` from PartOfSpeech where name_part_speech = @PartOfSpeech)); 
INSERT INTO `Eng_Rus`(`ru_ru`, `en_us`, `category`, `part_speech`) VALUES((select rulang_id from ru_lang where RussianWords = @Lang2), (select englang_id from en_lang where EnglishWords = @Lang1), (SELECT `catnum` from categories where catname = @Category), (SELECT `part_speech_num` from PartOfSpeech where name_part_speech = @PartOfSpeech));
INSERT INTO `Eng_Tat`(`tt_ru`, `en_us`, `category`, `part_speech`) VALUES((select tatlang_id from tt_lang where TatarWords = @Lang4), (select englang_id from en_lang where EnglishWords = @Lang1), (SELECT `catnum` from categories where catname = @Category), (SELECT `part_speech_num` from PartOfSpeech where name_part_speech = @PartOfSpeech)); 
INSERT INTO `SouthBash_Eng`(`bayu_ru`, `en_us`, `category`, `part_speech`) VALUES((select southbashlang_id from bayu_lang where YurmatinWords = @Lang5), (select englang_id from en_lang where EnglishWords = @Lang1), (SELECT `catnum` from categories where catname = @Category), (SELECT `part_speech_num` from PartOfSpeech where name_part_speech = @PartOfSpeech)); 
INSERT INTO `Bash_Rus`(`ru_ru`, `ba_ru`, `category`, `part_speech`) VALUES((select rulang_id from ru_lang where RussianWords = @Lang2), (select bashlang_id from ba_lang where BashkirWords = @Lang3), (SELECT `catnum` from categories where catname = @Category), (SELECT `part_speech_num` from PartOfSpeech where name_part_speech = @PartOfSpeech)); 
INSERT INTO `Bash_Tat`(`tt_ru`, `ba_ru`, `category`, `part_speech`) VALUES((select tatlang_id from tt_lang where TatarWords = @Lang4), (select bashlang_id from ba_lang where BashkirWords = @Lang3), (SELECT `catnum` from categories where catname = @Category), (SELECT `part_speech_num` from PartOfSpeech where name_part_speech = @PartOfSpeech)); 
INSERT INTO `SouthBash_Bash`(`bayu_ru`, `ba_ru`, `category`, `part_speech`) VALUES((select southbashlang_id from bayu_lang where YurmatinWords = @Lang5), (select bashlang_id from ba_lang where BashkirWords = @Lang3), (SELECT `catnum` from categories where catname = @Category), (SELECT `part_speech_num` from PartOfSpeech where name_part_speech = @PartOfSpeech)); 
INSERT INTO `Rus_Tat`(`tt_ru`, `ru_ru`, `category`, `part_speech`) VALUES((select tatlang_id from tt_lang where TatarWords = @Lang4), (select rulang_id from ru_lang where RussianWords = @Lang2), (SELECT `catnum` from categories where catname = @Category), (SELECT `part_speech_num` from PartOfSpeech where name_part_speech = @PartOfSpeech)); 
INSERT INTO `SouthBash_Rus`(`bayu_ru`, `ru_ru`, `category`, `part_speech`) VALUES((select southbashlang_id from bayu_lang where YurmatinWords = @Lang5), (select rulang_id from ru_lang where RussianWords = @Lang2), (SELECT `catnum` from categories where catname = @Category), (SELECT `part_speech_num` from PartOfSpeech where name_part_speech = @PartOfSpeech)); 
INSERT INTO `SouthBash_Tat`(`bayu_ru`, `tt_ru`, `category`, `part_speech`) VALUES((select southbashlang_id from bayu_lang where YurmatinWords = @Lang5), (select tatlang_id from tt_lang where TatarWords = @Lang4), (SELECT `catnum` from categories where catname = @Category), (SELECT `part_speech_num` from PartOfSpeech where name_part_speech = @PartOfSpeech))";

                cmd.Parameters.Add("@Lang1", MySqlDbType.VarChar);
                cmd.Parameters["@Lang1"].Value = Lang1;
                cmd.Parameters.Add("@Lang2", MySqlDbType.VarChar);
                cmd.Parameters["@Lang2"].Value = Lang2;
                cmd.Parameters.Add("@Lang3", MySqlDbType.VarChar);
                cmd.Parameters["@Lang3"].Value = Lang3;
                cmd.Parameters.Add("@Lang4", MySqlDbType.VarChar);
                cmd.Parameters["@Lang4"].Value = Lang4;
                cmd.Parameters.Add("@Lang5", MySqlDbType.VarChar);
                cmd.Parameters["@Lang5"].Value = Lang5;
                cmd.Parameters.Add("@Category", MySqlDbType.VarChar);
                cmd.Parameters["@Category"].Value = Category;
                cmd.Parameters.Add("@PartOfSpeech", MySqlDbType.VarChar);
                cmd.Parameters["@PartOfSpeech"].Value = PartOfSpeech;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Словарь был пополнен 5 новыми словоформами", "MLangD", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            catch (Exception)
            {
                MessageBox.Show("Подобная пара слов уже находится в словаре!", "MLangD", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string UdpdatedWord = textBox7.Text;
            string OriginalWord = comboBox5.Text;
            const string Connect = "Database=mlangdb;Data Source=localhost;User Id=root;Password=20022015220; Old Guids=true";
            MySqlConnection conn = new MySqlConnection(Connect);

            {
                conn.Open(); //Устанавливаем соединение с базой данных.
                MySqlCommand cmd = new MySqlCommand();
                try
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"UPDATE en_lang SET en_lang.EnglishWords=@Zamena where en_lang.EnglishWords = @WordInComboBox";
                    cmd.Parameters.Add("@Zamena", MySqlDbType.VarChar);
                    cmd.Parameters["@Zamena"].Value = UdpdatedWord;
                    cmd.Parameters.Add("@WordInComboBox", MySqlDbType.VarChar);
                    cmd.Parameters["@WordInComboBox"].Value = OriginalWord;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Одна запись в английском языке была заменена", "Исправление | MLangD", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                catch (Exception)
                {
                    MessageBox.Show("Не удалось исправить записи", "Исправление | MLangD", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                conn.Close(); 
            }
        }
    

        private void fillBy1ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void button13_Click(object sender, EventArgs e)
        {
            string UdpdatedWord = textBox6.Text;
            string OriginalWord = comboBox6.Text;
            const string Connect = "Database=mlangdb;Data Source=localhost;User Id=root;Password=20022015220; Old Guids=true";
            MySqlConnection conn = new MySqlConnection(Connect);

            {
                conn.Open(); //Устанавливаем соединение с базой данных.
                MySqlCommand cmd = new MySqlCommand();
                try
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"UPDATE ba_lang SET ba_lang.BashkirWords=@Zamena where ba_lang.BashkirWords = @WordInComboBox";
                    cmd.Parameters.Add("@Zamena", MySqlDbType.VarChar);
                    cmd.Parameters["@Zamena"].Value = UdpdatedWord;
                    cmd.Parameters.Add("@WordInComboBox", MySqlDbType.VarChar);
                    cmd.Parameters["@WordInComboBox"].Value = OriginalWord;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Одна запись в башкирском языке была заменена", "Исправление | MLangD", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                catch (Exception)
                {
                    MessageBox.Show("Не удалось исправить записи", "Исправление | MLangD", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                conn.Close(); 
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            string UdpdatedWord = textBox7.Text;
            string OriginalWord = comboBox5.Text;
            const string Connect = "Database=mlangdb;Data Source=localhost;User Id=root;Password=20022015220; Old Guids=true";
            MySqlConnection conn = new MySqlConnection(Connect);

            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                try
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"UPDATE ru_lang SET ru_lang.RussianWords=@Zamena where ru_lang.RussianWords = @WordInComboBox";
                    cmd.Parameters.Add("@Zamena", MySqlDbType.VarChar);
                    cmd.Parameters["@Zamena"].Value = UdpdatedWord;
                    cmd.Parameters.Add("@WordInComboBox", MySqlDbType.VarChar);
                    cmd.Parameters["@WordInComboBox"].Value = OriginalWord;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Одна запись в русском языке была заменена", "Исправление | MLangD", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                catch (Exception)
                {
                    MessageBox.Show("Не удалось исправить записи", "Исправление | MLangD", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                conn.Close(); 
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            string UdpdatedWord = textBox7.Text;
            string OriginalWord = comboBox5.Text;
            const string Connect = "Database=mlangdb;Data Source=localhost;User Id=root;Password=20022015220; Old Guids=true";
            MySqlConnection conn = new MySqlConnection(Connect);

            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                try
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"UPDATE tt_lang SET tt_lang.TatarWords=@Zamena where tt_lang.TatarWords = @WordInComboBox";
                    cmd.Parameters.Add("@Zamena", MySqlDbType.VarChar);
                    cmd.Parameters["@Zamena"].Value = UdpdatedWord;
                    cmd.Parameters.Add("@WordInComboBox", MySqlDbType.VarChar);
                    cmd.Parameters["@WordInComboBox"].Value = OriginalWord;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Одна запись в татарском языке была заменена", "Исправление | MLangD", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                catch (Exception)
                {
                    MessageBox.Show("Не удалось исправить записи", "Исправление | MLangD", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                conn.Close();
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            string UdpdatedWord = textBox7.Text;
            string OriginalWord = comboBox5.Text;
            const string Connect = "Database=mlangdb;Data Source=localhost;User Id=root;Password=20022015220; Old Guids=true";
            MySqlConnection conn = new MySqlConnection(Connect);

            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                try
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"UPDATE bayu_lang SET bayu_lang.YurmatinWords=@Zamena where bayu_lang.YurmatinWords = @WordInComboBox";
                    cmd.Parameters.Add("@Zamena", MySqlDbType.VarChar);
                    cmd.Parameters["@Zamena"].Value = UdpdatedWord;
                    cmd.Parameters.Add("@WordInComboBox", MySqlDbType.VarChar);
                    cmd.Parameters["@WordInComboBox"].Value = OriginalWord;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Одна запись в юрматинском диалекте была заменена", "Исправление | MLangD", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                catch (Exception)
                {
                    MessageBox.Show("Не удалось исправить записи", "Исправление | MLangD", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                conn.Close();
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            string z1 = comboBox11.Text;
            const string Connect = "Database=mlangdb;Data Source=localhost;User Id=root;Password=20022015220; Old Guids=true";
            using (MySqlConnection conn = new MySqlConnection(Connect))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();


                DialogResult result = MessageBox.Show("Вы точно хотите удалить запись?", "Сообщение!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (result == DialogResult.No)
                {
                    Menu newForm = new Menu();
                    newForm.Show();
                    this.Hide();
                }

                if (result == DialogResult.Yes)
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"delete from Bash_Eng WHERE (select en_lang.englang_id from en_lang where en_lang.EnglishWords =@EnglishWord group by en_lang.englang_id)= Bash_Eng.en_us;
delete from Eng_Rus WHERE (select en_lang.englang_id from en_lang where en_lang.EnglishWords =@EnglishWord group by en_lang.englang_id) = Eng_Rus.en_us;
delete from Eng_Tat WHERE (select en_lang.englang_id from en_lang where en_lang.EnglishWords =@EnglishWord group by en_lang.englang_id) = Eng_Tat.en_us;
delete from SouthBash_Eng WHERE (select en_lang.englang_id from en_lang where en_lang.EnglishWords =@EnglishWord group by en_lang.englang_id) = SouthBash_Eng.en_us;";
                    cmd.Parameters.Add("@EnglishWord", MySqlDbType.VarChar);
                    cmd.Parameters["@EnglishWord"].Value = z1;
                    cmd.ExecuteNonQuery();
                    try
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = @"delete from en_lang WHERE en_lang.englang_id = (select en_lang.englang_id from en_lang where en_lang.EnglishWords = @EnglishWord group by en_lang.englang_id);";
                        cmd.Parameters.Add("@EnglishWord", MySqlDbType.VarChar);
                        cmd.Parameters["@EnglishWord"].Value = z1;
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Запись удалена.", "| MLang", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Запись удалена.", "| MLang", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }

                    conn.Close();
                }
            }
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    } 
}