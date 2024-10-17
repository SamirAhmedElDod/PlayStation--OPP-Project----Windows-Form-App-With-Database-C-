using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Playstation
{
    public partial class GamesForm : Form
    {
        int GameID = 0;
        string GameName = "";
        string GameImagePath = "";

        TabPage GameNameTab;
        Label GameID_Label;
        Label ID;
        Label GameName_Label;
        PictureBox GameImage;


        public GamesForm()
        {
            InitializeComponent();
            RetriveGamesFromDatabase();
        }

      
        // Devices Form Open
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            Form1 DevicesForm = new Form1();
            DevicesForm.BringToFront();
            this.Hide();
        }


        public void GetGameIDAndName(int Game_ID , string Game_string)
        {
            GameID = Game_ID;
            GameName = Game_string;
        }
        public void RetriveGamesFromDatabase()
        {
            guna2TabControl1.TabPages.Clear();
            int Game_ID = 0;
            string Game_NAME = "";

            string ConnectionString = "Server=.;Database=PlayStaionDB;User Id=sa; Password= samir123456;";
            SqlConnection connection = new SqlConnection(ConnectionString);

            string GetAll_Query = @"Select * From Game;";
            SqlCommand GetAll_Command = new SqlCommand(GetAll_Query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = GetAll_Command.ExecuteReader();
                while (reader.Read())
                {
                    Game_ID = (int)reader["GameID"];
                    Game_NAME = (string)reader["GameName"];
                    GameImagePath = (string)reader["ImagePath"];

                    // Create New Tab 
                    GameNameTab = new TabPage(Game_NAME);
                    

                    // Create New Label For Each Game
                    GameID_Label = new Label();
                    GameID_Label.Text = "Game ID : ";
                    GameID_Label.Location = new Point(1200, 200);
                    GameID_Label.Size = new Size(314, 73);
                    GameID_Label.ForeColor = Color.Black;
                    GameID_Label.Font = new Font("Times New Roman", 45);

                    // Create New ID 
                    ID = new Label();
                    ID.Text = Game_ID.ToString();
                    ID.Location = new Point(1500, 200);
                    ID.Size = new Size(314, 73);
                    ID.ForeColor = Color.Black;
                    ID.Font = new Font("Times New Roman", 45);

                    // Create New Game NAme
                    GameName_Label = new Label();
                    GameName_Label.Text = Game_NAME;

                    GameName_Label.Location = new Point(1200, 350);
                    GameName_Label.Size = new Size(314, 73);
                    GameName_Label.ForeColor = Color.Black;
                    GameName_Label.Font = new Font("Times New Roman", 45);
                    GameName_Label.AutoSize = true;

                    // Add Game Image
                    GameImage = new PictureBox();
                    GameImage.Image = Image.FromFile(GameImagePath);
                    GameImage.SizeMode = PictureBoxSizeMode.Zoom;
                    GameImage.Location = new Point(80, 30);
                    GameImage.Size = new Size(1000, 600);


                    // Add All To Tabs
                    GameNameTab.Controls.Add(GameID_Label);
                    GameNameTab.Controls.Add(ID);
                    GameNameTab.Controls.Add(GameName_Label);
                    GameNameTab.Controls.Add(GameImage);
                    guna2TabControl1.TabPages.Add(GameNameTab);
                }
                reader.Close();
            }
            catch (Exception Error)
            {
                MessageBox.Show(Error.Message, "Error Here", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }
        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            AddNewGameForm addNewGame = new AddNewGameForm(this);
            addNewGame.Show();

            addNewGame.FormClosed += (s, args) => RetriveGamesFromDatabase();

        }
    }
}
