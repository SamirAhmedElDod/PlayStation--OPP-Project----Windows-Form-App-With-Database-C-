using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Playstation
{
    public partial class AddNewGameForm : Form
    {
        private GamesForm RecievedForm;
        static int GameID;
        static string GameName;
        static OpenFileDialog dialog;
        DialogResult result;
        public AddNewGameForm(GamesForm recivedForm)
        {
            InitializeComponent();
            RecievedForm = recivedForm;
            this.MaximizeBox = false;
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            GameID = int.Parse(guna2TextBox1.Text);
            GameName = guna2TextBox2.Text;
            RecievedForm.GetGameIDAndName(GameID, GameName);
            InsertnewGame();
            this.Close();
        }
        static public void InsertnewGame()
        {
            int RowsAffected = 0;
            string ConnectionString = "Server=.;Database=PlayStaionDB;User Id=sa; Password= samir123456;";
            SqlConnection connection = new SqlConnection(ConnectionString);

            string Insert_Query = @"insert into Game Values (@ID , @GameName, @ImagePath);";

            SqlCommand Insert_Command = new SqlCommand(Insert_Query, connection);
            Insert_Command.Parameters.AddWithValue("@ID", GameID);
            Insert_Command.Parameters.AddWithValue("@GameName", GameName);
            Insert_Command.Parameters.AddWithValue("@ImagePath", dialog.FileName);

            try
            {
                connection.Open();
                RowsAffected = Insert_Command.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    MessageBox.Show("New Game Added Successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed New Game", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               
            }
            catch (Exception Error)
            {
                MessageBox.Show(Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            dialog = new OpenFileDialog();
            result = dialog.ShowDialog();
            dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif|All Files|*.*";
            dialog.Title = "Select an Image File";

            if (result == DialogResult.OK)
            {
                MessageBox.Show("Image Uploaded Successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
