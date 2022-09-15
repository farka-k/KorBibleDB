using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Reflection;
using System.Data.SQLite;
using System.Diagnostics;
namespace KorBibleDB
{
    public partial class Form1 : Form
    {
		private List<string> books = new List<string>();
		private List<string> abbr = new List<string>();
		private List<int> numOfChapters = new List<int>();
		private SQLiteConnection conn = null;
		private SQLiteCommand command = null;
		private SQLiteDataReader rdr = null;
		public Form1()
        {
            InitializeComponent();
			GetBibleBooks();
			InitObjectValues();
        }

        private void BtnCreateDB_Click(object sender, EventArgs e)
        {
			int tables = 0;
			int passages = 0;
			Stopwatch stopwatch = new Stopwatch();
			if (!File.Exists("RevisedKorBible.db"))
				SQLiteConnection.CreateFile("RevisedKorBible.db");
			conn = new SQLiteConnection("Data Source=RevisedKorBible.db;Verseion=3");
			conn.Open();


			SQLiteCommand command = conn.CreateCommand();
			command.CommandText = "drop table if exists Books";
			command.ExecuteNonQuery();

			string sql = "create table if not exists Books (Name varchar(10), Abbr varchar(2), Testament varchar(2), Chapters int)";
			command.CommandText = sql;
			tables += command.ExecuteNonQuery();
            
			for (int i=0; i<66; i++)
            {
				string testament = i < 39 ? "구약" : "신약";
				
				command.CommandText = 
					String.Format("insert into Books values ('{0}', '{1}', '{2}', {3})", 
					books[i], abbr[i], testament, numOfChapters[i]);
				command.ExecuteNonQuery();

				command.CommandText = String.Format("drop table if exists {0}", books[i]);
				command.ExecuteNonQuery();
				command.CommandText =
					String.Format("create table if not exists {0} (Chapter int, Passage int, Text TEXT, PRIMARY KEY (Chapter, Passage))", books[i]);
				tables += command.ExecuteNonQuery();
			}

			conn.Close();
			stopwatch.Start();
			passages = InsertAllBiblePassages();
			stopwatch.Stop();
			MessageBox.Show(String.Format("Created {0} tables, inserted {1} rows successfully in {2} ms", tables, passages, stopwatch.ElapsedMilliseconds));
        }

        private void BtnExtract_Click(object sender, EventArgs e)
        {
			if (!File.Exists("RevisedKorBible.db"))
				MessageBox.Show("Create DB First");
			conn = new SQLiteConnection("Data Source=RevisedKorBible.db;Verseion=3");
			conn.Open();
			SQLiteCommand command = conn.CreateCommand();
			command.CommandText = String.Format("select * from {0} where rowid between ",CmbStartBook.Text) +
				String.Format("(select rowid from {0} where Chapter={1} and Passage={2}) and (select rowid from {0} where Chapter={3} and Passage={4})", 
				CmbStartBook.Text, NumStartChapter.Value, NumStartPassage.Value, NumEndChapter.Value, NumEndPassage.Value);
			SQLiteDataReader rdr = command.ExecuteReader();

			txtOutput.Text = "";
            while (rdr.Read())
            {
				txtOutput.Text += CmbStartBook.Text + rdr["Chapter"] + ":" + rdr["Passage"] + " " + rdr["Text"] +"\n";
            }
			rdr.Close();

			conn.Close();
		}

		private void GetBibleBooks()
		{
			Assembly _assembly;
			StreamReader _textStreamReader = null;
			try
			{
				_assembly = Assembly.GetExecutingAssembly();
				_textStreamReader = new StreamReader(_assembly.GetManifestResourceStream(this.GetType().Namespace + ".BibleBooks.txt"));
			}
			catch
			{
				MessageBox.Show("Error accessing resources!");
				Close();
			}
			finally
			{
				string line;
				while ((line = _textStreamReader.ReadLine()) != null)
				{
					string[] s = line.Split();
					books.Add(s[0]);
					abbr.Add(s[1]);
					numOfChapters.Add(int.Parse(s[2]));
				}
			}
		}

		private void InitObjectValues()
		{ 
			CmbStartBook.DataSource = books;
			CmbEndBook.DataSource = books;
			NumStartChapter.Value = 1;
			NumEndChapter.Value = 1;
			NumStartPassage.Value = 1;
			NumEndPassage.Value = 1;
        }

		private int InsertAllBiblePassages()
		{
			int passages = 0;

			Assembly _assembly;
			StreamReader _textStreamReader = null;
			try
			{
				_assembly = Assembly.GetExecutingAssembly();
				_textStreamReader = new StreamReader(_assembly.GetManifestResourceStream(this.GetType().Namespace + ".RevisedKorBible.txt"));
			}
			catch
			{
				MessageBox.Show("Error accessing resources!");
				Close();
			}
			finally
			{
				string line;
				int currentBookIndex = 0;
				int currentChapter = 1;
				int currentPassage = 1;

				conn = new SQLiteConnection("Data Source=RevisedKorBible.db;Verseion=3");
				conn.Open();

				SQLiteCommand command = conn.CreateCommand();

				command.CommandText="Begin Transaction";
				command.ExecuteNonQuery();
				while ((line = _textStreamReader.ReadLine()) != null)
				{
					//창1:1 태초에 ... 창조하시니라
					string[] s = line.Split();
					string[] verseAbbr = s[0].Split(':');
					int verseAbbrLength = s[0].Length;

					if (!verseAbbr[0].StartsWith(abbr[currentBookIndex]))
                    {
						currentBookIndex++;
						currentChapter = 1;
						currentPassage = 1;

                    }
					else if (!verseAbbr[0].EndsWith(currentChapter.ToString()))
                    {
						currentChapter++;
						currentPassage = 1;
                    }
					
					string sql = String.Format("insert into {0} values ({1}, {2}, \'{3}\')",
						books[currentBookIndex], currentChapter, currentPassage++, line.Substring(line.IndexOf(" ")+1).Replace("'","''" ));
					command.CommandText = sql;
					passages += command.ExecuteNonQuery();
				}
				command.CommandText = "End Transaction";
				command.ExecuteNonQuery();
			}
			return passages;
		}

        private void CmbBook_SelectedIndexChanged(object sender, EventArgs e)
		{ 
			conn = new SQLiteConnection("Data Source=RevisedKorBible.db;Verseion=3");
			conn.Open();
			command = conn.CreateCommand();
			command.CommandText = String.Format("select Chapters from Books where Name='{0}'", ((ComboBox)sender).Text);
			rdr=command.ExecuteReader();
            while (rdr.Read())
            {
				int num = rdr.GetInt32(0);
				NumStartChapter.Maximum = num;
				NumEndChapter.Maximum = num;
            }
			rdr.Close();
        }

        private void NumStartChapter_ValueChanged(object sender, EventArgs e)
        {
			conn = new SQLiteConnection("Data Source=RevisedKorBible.db;Verseion=3");
			conn.Open();
			command = conn.CreateCommand();
			command.CommandText = String.Format("select count(*) from {0} where Chapter={1}", CmbStartBook.Text, ((NumericUpDown)sender).Value);
			rdr = command.ExecuteReader();
			while (rdr.Read())
			{
				int num = rdr.GetInt32(0);
				NumStartPassage.Maximum = num;
			}
			rdr.Close();

			NumEndChapter.Minimum = NumStartChapter.Value;
		}

        private void NumEndChapter_ValueChanged(object sender, EventArgs e)
        {
			conn = new SQLiteConnection("Data Source=RevisedKorBible.db;Verseion=3");
			conn.Open();
			command = conn.CreateCommand();
			command.CommandText = String.Format("select count(*) from {0} where Chapter={1}", CmbStartBook.Text, ((NumericUpDown)sender).Value);
			rdr = command.ExecuteReader();
			while (rdr.Read())
			{
				int num = rdr.GetInt32(0);
				NumEndPassage.Maximum = num;
			}
			rdr.Close();

			if (NumStartChapter.Value != NumEndChapter.Value)
				NumEndPassage.Minimum = 1;
		}

        private void NumStartPassage_ValueChanged(object sender, EventArgs e)
        {
            if (NumStartChapter.Value == NumEndChapter.Value)
				NumEndPassage.Minimum = NumStartPassage.Value;
        }
    }
}
