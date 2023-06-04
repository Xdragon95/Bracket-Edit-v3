using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bracket_Edit_v3.Properties;

namespace Bracket_Edit_v3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string Old_Name = ""; //Edit button placeholder for playerlist
        string filePath = "";
        int SBP1Score = 0; //scoreboard score placeholders
        int SBP2Score = 0;
        int SBPlaceholder = 0; //scoreboard switch placeholder
        string SBPlaceholderName = "";
        string SBPlayer1N = "";
        string SBPlayer2N = "";
        int EventNo = 1;

        private void SetSBLocationBtn_Click(object sender, EventArgs e)
        {
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    ScoreboardLocation.Text = dialog.SelectedPath;
                System.IO.File.WriteAllText(ScoreboardLocation.Text + "\\" + "Player 1 Name.txt", "");
                System.IO.File.WriteAllText(ScoreboardLocation.Text + "\\" + "Player 2 Name.txt", "");
                System.IO.File.WriteAllText(ScoreboardLocation.Text + "\\" + "Player 1 Score.txt", "");
                System.IO.File.WriteAllText(ScoreboardLocation.Text + "\\" + "Player 2 Score.txt", "");
                System.IO.File.WriteAllText(ScoreboardLocation.Text + "\\" + "Bracket Location.txt", "");
                Settings.Default.SBLocation = dialog.SelectedPath;
                }
        }
        private void SetGroups0Rdo_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            groupBox6.Location = new Point(10, 237);
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
            groupBox3.Visible = true;
            groupBox4.Visible = true;
            groupBox5.Visible = true;
            groupBox6.Location = new Point(10, 550);
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
            groupBox3.Visible = true;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            groupBox6.Location = new Point(10, 394);

        }
        private void AddtoPlayerlistBTN_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(PlayerListAddBox.Text))
                return;
            G1P1NAME.AutoCompleteCustomSource.Add(PlayerListAddBox.Text);
            G1P2NAME.AutoCompleteCustomSource.Add(PlayerListAddBox.Text);
            G2P1NAME.AutoCompleteCustomSource.Add(PlayerListAddBox.Text);
            G2P2NAME.AutoCompleteCustomSource.Add(PlayerListAddBox.Text);
            G3P1NAME.AutoCompleteCustomSource.Add(PlayerListAddBox.Text);
            G3P2NAME.AutoCompleteCustomSource.Add(PlayerListAddBox.Text);
            G4P1NAME.AutoCompleteCustomSource.Add(PlayerListAddBox.Text);
            G4P2NAME.AutoCompleteCustomSource.Add(PlayerListAddBox.Text);
            SBPlayer1Name.AutoCompleteCustomSource.Add(PlayerListAddBox.Text);
            SBPlayer2Name.AutoCompleteCustomSource.Add(PlayerListAddBox.Text);
            PlayerList.Items.Add(PlayerListAddBox.Text);
            PlayerListAddBox.Text = "";
        }
        private void button12_Click(object sender, EventArgs e)
        {
            if (PlayerList.SelectedItem == null)
            {
                MessageBox.Show("No player name selected.");
                return;
            };
            Old_Name = (PlayerList.SelectedItem.ToString());
            G1P1NAME.AutoCompleteCustomSource.Remove(PlayerList.SelectedItem.ToString());
            G1P2NAME.AutoCompleteCustomSource.Remove(PlayerList.SelectedItem.ToString());
            G2P1NAME.AutoCompleteCustomSource.Remove(PlayerList.SelectedItem.ToString());
            G2P2NAME.AutoCompleteCustomSource.Remove(PlayerList.SelectedItem.ToString());
            G3P1NAME.AutoCompleteCustomSource.Remove(PlayerList.SelectedItem.ToString());
            G3P2NAME.AutoCompleteCustomSource.Remove(PlayerList.SelectedItem.ToString());
            G4P1NAME.AutoCompleteCustomSource.Remove(PlayerList.SelectedItem.ToString());
            G4P2NAME.AutoCompleteCustomSource.Remove(PlayerList.SelectedItem.ToString());
            SBPlayer1Name.AutoCompleteCustomSource.Remove(PlayerList.SelectedItem.ToString());
            SBPlayer2Name.AutoCompleteCustomSource.Remove(PlayerList.SelectedItem.ToString());
            PlayerList.Items.Remove(PlayerList.SelectedItem.ToString());
            PlayerListAddBox.Text = Old_Name;
            Old_Name = "";
            PlayerListAddBox.Select();

        }
        private void ClearPlayersBTN_Click(object sender, EventArgs e)
        {
            PlayerList.Items.Clear();
            G1P1NAME.AutoCompleteCustomSource.Clear();
            G1P2NAME.AutoCompleteCustomSource.Clear();
            G2P1NAME.AutoCompleteCustomSource.Clear();
            G2P2NAME.AutoCompleteCustomSource.Clear();
            G3P1NAME.AutoCompleteCustomSource.Clear();
            G3P2NAME.AutoCompleteCustomSource.Clear();
            G4P1NAME.AutoCompleteCustomSource.Clear();
            G4P2NAME.AutoCompleteCustomSource.Clear();
            SBPlayer1Name.AutoCompleteCustomSource.Clear();
            SBPlayer2Name.AutoCompleteCustomSource.Clear();
            G1P1NAME.Text = "";
            G1P2NAME.Text = "";
            G2P1NAME.Text = "";
            G2P2NAME.Text = "";
            G3P1NAME.Text = "";
            G3P2NAME.Text = "";
            G4P1NAME.Text = "";
            G4P2NAME.Text = "";
        }
        private void RemovePlayerBTN_Click(object sender, EventArgs e)
        {
            if (PlayerList.SelectedItem == null)
            {
                MessageBox.Show("No player name selected.");
                return;
            };
            G1P1NAME.AutoCompleteCustomSource.Remove(PlayerList.SelectedItem.ToString());
            G1P2NAME.AutoCompleteCustomSource.Remove(PlayerList.SelectedItem.ToString());
            G2P1NAME.AutoCompleteCustomSource.Remove(PlayerList.SelectedItem.ToString());
            G2P2NAME.AutoCompleteCustomSource.Remove(PlayerList.SelectedItem.ToString());
            G3P1NAME.AutoCompleteCustomSource.Remove(PlayerList.SelectedItem.ToString());
            G3P2NAME.AutoCompleteCustomSource.Remove(PlayerList.SelectedItem.ToString());
            G4P1NAME.AutoCompleteCustomSource.Remove(PlayerList.SelectedItem.ToString());
            G4P2NAME.AutoCompleteCustomSource.Remove(PlayerList.SelectedItem.ToString());
            SBPlayer1Name.AutoCompleteCustomSource.Remove(PlayerList.SelectedItem.ToString());
            SBPlayer2Name.AutoCompleteCustomSource.Remove(PlayerList.SelectedItem.ToString());
            PlayerList.Items.Remove(PlayerList.SelectedItem.ToString());
        }
        private void button11_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "csv files (*.csv)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //for (int i = 0; i < 5; i++) For loop for later
                    //{
                    //    Console.WriteLine(i);
                    //}
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                    string[] csvLines = System.IO.File.ReadAllLines(filePath);
                    var gamename1 = new List<string>();
                    var gamename2 = new List<string>();
                    var gamename3 = new List<string>();

                    var csvlines = csvLines;

                    for (int i = 0; i < EventNo; i++)
                    {
                        string[] rowData = csvLines[i].Split(',');

                        gamename1.Add(rowData[32]);
                        gamename2.Add(rowData[33]);
                        gamename3.Add(rowData[34]);
                    }
                    //for (int i = 0; i < csvLines.Length; i++)
                    //{
                    //string[] rowData = csvLines[i].Split(',');
                    //
                    // gamename1.Add(rowData[32]);
                    // gamename2.Add(rowData[33]);
                    // gamename3.Add(rowData[34]);
                    //}
                     comboBox1.Items.Add(gamename1[0]);
                     comboBox1.Items.Add(gamename2[0]);
                     comboBox1.Items.Add(gamename3[0]);
                }
            }
        }
        private void G1StartMatchBTN_Click(object sender, EventArgs e)
        {
            SBBracketArea.Text = G1BracketAreaBox.Text;
            SBPlayer1N = G1P1NAME.Text;
            SBPlayer2N = G1P2NAME.Text;
            SBPlayer1Name.Text = SBPlayer1N;
            SBPlayer2Name.Text = SBPlayer2N;
            SBP1Score = 0;
            SBP2Score = 0;
            SBPlayer1Score.Text = "0";
            SBPlayer2Score.Text = "0";
        }

        private void G2StartMatchBTN_Click(object sender, EventArgs e)
        {
            SBBracketArea.Text = G2BracketAreaBox.Text;
            SBPlayer1N = G2P1NAME.Text;
            SBPlayer2N = G2P2NAME.Text;
            SBP1Score = 0;
            SBP2Score = 0;
            SBPlayer1Name.Text = G2P1NAME.Text;
            SBPlayer2Name.Text = G2P2NAME.Text;
            SBPlayer1Score.Text = "0";
            SBPlayer2Score.Text = "0";
        }

        private void G3StartMatchBTN_Click(object sender, EventArgs e)
        {
            SBBracketArea.Text = G3BracketAreaBox.Text;
            SBPlayer1N = G3P1NAME.Text;
            SBPlayer2N = G3P2NAME.Text;
            SBP1Score = 0;
            SBP2Score = 0;
            SBPlayer1Name.Text = G3P1NAME.Text;
            SBPlayer2Name.Text = G3P2NAME.Text;
            SBPlayer1Score.Text = "0";
            SBPlayer2Score.Text = "0";
        }

        private void G4StartMatchBTN_Click(object sender, EventArgs e)
        {
            SBBracketArea.Text = G4BracketAreaBox.Text;
            SBPlayer1N = G4P1NAME.Text;
            SBPlayer2N = G4P2NAME.Text;
            SBP1Score = 0;
            SBP2Score = 0;
            SBPlayer1Name.Text = G4P1NAME.Text;
            SBPlayer2Name.Text = G4P2NAME.Text;
            SBPlayer1Score.Text = "0";
            SBPlayer2Score.Text = "0";
        }

        private void SBSaveBTN_Click(object sender, EventArgs e)
        {
            {
                if
                    (ScoreboardLocation.Text == "")
                {
                    MessageBox.Show("Specify the location of your scoreboard folder.");
                    return;
                }
                if
                    (ScoreboardLocation.Text != "")
                {
                    File.WriteAllText(ScoreboardLocation.Text + "\\Player 1 Name.txt", SBPlayer1Name.Text);
                    File.WriteAllText(ScoreboardLocation.Text + "\\Player 1 Score.txt", SBPlayer1Score.Text);
                    File.WriteAllText(ScoreboardLocation.Text + "\\Player 2 Name.txt", SBPlayer2Name.Text);
                    File.WriteAllText(ScoreboardLocation.Text + "\\Player 2 Score.txt", SBPlayer2Score.Text);
                    File.WriteAllText(ScoreboardLocation.Text + "\\Bracket Location.txt", SBBracketArea.Text);
                }
                else
                {
                    MessageBox.Show("Specify locations for all of your files.");
                }
            }
        }

        private void SBSwitchBTN_Click(object sender, EventArgs e)
        {
            SBPlaceholder = SBP1Score;
            SBPlaceholderName = SBPlayer1Name.Text; //Placeholders get P1 Name and Score
            SBPlayer1N = SBPlayer2Name.Text;
            SBP1Score = SBP2Score; //P1 gets P2 Name and Score
            SBPlayer2N = SBPlaceholderName;
            SBP2Score = SBPlaceholder; //P2 gets Placeholder Name and Score
            SBPlayer1Name.Text = SBPlayer1N;
            SBPlayer2Name.Text = SBPlayer2N;
            SBPlayer1Score.Text = SBP1Score.ToString();
            SBPlayer2Score.Text = SBP2Score.ToString();
        }

        private void SBResetBTN_Click(object sender, EventArgs e)
        {
            SBBracketArea.Text = "";
            SBPlayer1Score.Text = "0";
            SBPlayer2Score.Text = "0";
            SBPlayer1Name.Text = "";
            SBPlayer2Name.Text = "";
            SBP1Score = 0;
            SBP2Score = 0;
        }

        private void SBPlayer1Decrement_Click(object sender, EventArgs e)
        {
            SBP1Score--;
            SBPlayer1Score.Text = SBP1Score.ToString();
            if (SBP1Score < 0)
            {
                SBP1Score = 0;
                SBPlayer1Score.Text = "0";
            }
        }

        private void SBPlayer2Increment_Click(object sender, EventArgs e)
        {
            SBP1Score++;
            SBPlayer1Score.Text = SBP1Score.ToString();
        }

        private void SBPlayer2Decrement_Click(object sender, EventArgs e)
        {
            SBP2Score--;
            SBPlayer2Score.Text = SBP2Score.ToString();
            if (SBP2Score < 0)
            {
                SBP2Score = 0;
                SBPlayer2Score.Text = "0";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SBP2Score++;
            SBPlayer2Score.Text = SBP2Score.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                G1P1NAME.AutoCompleteCustomSource.Clear();
                G1P2NAME.AutoCompleteCustomSource.Clear();
                G2P1NAME.AutoCompleteCustomSource.Clear();
                G2P2NAME.AutoCompleteCustomSource.Clear();
                G3P1NAME.AutoCompleteCustomSource.Clear();
                G3P2NAME.AutoCompleteCustomSource.Clear();
                G4P1NAME.AutoCompleteCustomSource.Clear();
                G4P2NAME.AutoCompleteCustomSource.Clear();
                SBPlayer1Name.AutoCompleteCustomSource.Clear();
                SBPlayer2Name.AutoCompleteCustomSource.Clear();
                PlayerList.Items.Clear();
                string[] csvLines = System.IO.File.ReadAllLines(filePath);
                var gamerTag = new List<string>();
                var game1 = new List<string>();
                for (int i = 1; i < csvLines.Length; i++)
                {
                    string[] rowData = csvLines[i].Split(',');

                    gamerTag.Add(rowData[6]);
                    game1.Add(rowData[31]);
                }
                for (int i = 0; i < gamerTag.Count; i++)
                {
                    if (game1[i] != "")
                    {
                        string Old = "";
                        Old = gamerTag[i];
                        string middle = Old.Remove(Old.Length - 1);
                        string end = middle.Remove(0, 1);
                        PlayerList.Items.Add(end);
                        G1P1NAME.AutoCompleteCustomSource.Add(end);
                        G1P2NAME.AutoCompleteCustomSource.Add(end);
                        G2P1NAME.AutoCompleteCustomSource.Add(end);
                        G2P2NAME.AutoCompleteCustomSource.Add(end);
                        G3P1NAME.AutoCompleteCustomSource.Add(end);
                        G3P2NAME.AutoCompleteCustomSource.Add(end);
                        G4P1NAME.AutoCompleteCustomSource.Add(end);
                        G4P2NAME.AutoCompleteCustomSource.Add(end);
                        SBPlayer1Name.AutoCompleteCustomSource.Add(end);
                        SBPlayer2Name.AutoCompleteCustomSource.Add(end);
                    }
                }
            }
            if (comboBox1.SelectedIndex == 1)
            {
                G1P1NAME.AutoCompleteCustomSource.Clear();
                G1P2NAME.AutoCompleteCustomSource.Clear();
                G2P1NAME.AutoCompleteCustomSource.Clear();
                G2P2NAME.AutoCompleteCustomSource.Clear();
                G3P1NAME.AutoCompleteCustomSource.Clear();
                G3P2NAME.AutoCompleteCustomSource.Clear();
                G4P1NAME.AutoCompleteCustomSource.Clear();
                G4P2NAME.AutoCompleteCustomSource.Clear();
                SBPlayer1Name.AutoCompleteCustomSource.Clear();
                SBPlayer2Name.AutoCompleteCustomSource.Clear();
                PlayerList.Items.Clear();
                string[] csvLines = System.IO.File.ReadAllLines(filePath);
                var gamerTag = new List<string>();
                var game2 = new List<string>();
                for (int i = 1; i < csvLines.Length; i++)
                {
                    string[] rowData = csvLines[i].Split(',');

                    gamerTag.Add(rowData[6]);
                    game2.Add(rowData[32]);
                }
                for (int i = 0; i < gamerTag.Count; i++)
                {
                    if (game2[i] != "")
                    {
                        string Old = "";
                        Old = gamerTag[i];
                        string middle = Old.Remove(Old.Length - 1);
                        string end = middle.Remove(0, 1);
                        PlayerList.Items.Add(end);
                        G1P1NAME.AutoCompleteCustomSource.Add(end);
                        G1P2NAME.AutoCompleteCustomSource.Add(end);
                        G2P1NAME.AutoCompleteCustomSource.Add(end);
                        G2P2NAME.AutoCompleteCustomSource.Add(end);
                        G3P1NAME.AutoCompleteCustomSource.Add(end);
                        G3P2NAME.AutoCompleteCustomSource.Add(end);
                        G4P1NAME.AutoCompleteCustomSource.Add(end);
                        G4P2NAME.AutoCompleteCustomSource.Add(end);
                        SBPlayer1Name.AutoCompleteCustomSource.Add(end);
                        SBPlayer2Name.AutoCompleteCustomSource.Add(end);
                    }
                }
            }
            if (comboBox1.SelectedIndex == 2)
            {
                G1P1NAME.AutoCompleteCustomSource.Clear();
                G1P2NAME.AutoCompleteCustomSource.Clear();
                G2P1NAME.AutoCompleteCustomSource.Clear();
                G2P2NAME.AutoCompleteCustomSource.Clear();
                G3P1NAME.AutoCompleteCustomSource.Clear();
                G3P2NAME.AutoCompleteCustomSource.Clear();
                G4P1NAME.AutoCompleteCustomSource.Clear();
                G4P2NAME.AutoCompleteCustomSource.Clear();
                SBPlayer1Name.AutoCompleteCustomSource.Clear();
                SBPlayer2Name.AutoCompleteCustomSource.Clear();
                PlayerList.Items.Clear();
                string[] csvLines = System.IO.File.ReadAllLines(filePath);
                var gamerTag = new List<string>();
                var game3 = new List<string>();
                for (int i = 1; i < csvLines.Length; i++)
                {
                    string[] rowData = csvLines[i].Split(',');

                    gamerTag.Add(rowData[6]);
                    game3.Add(rowData[33]);
                }
                for (int i = 0; i < gamerTag.Count; i++)
                {
                    if (game3[i] != "")
                    {
                        string Old = "";
                        Old = gamerTag[i];
                        string middle = Old.Remove(Old.Length - 1);
                        string end = middle.Remove(0, 1);
                        PlayerList.Items.Add(end);
                        G1P1NAME.AutoCompleteCustomSource.Add(end);
                        G1P2NAME.AutoCompleteCustomSource.Add(end);
                        G2P1NAME.AutoCompleteCustomSource.Add(end);
                        G2P2NAME.AutoCompleteCustomSource.Add(end);
                        G3P1NAME.AutoCompleteCustomSource.Add(end);
                        G3P2NAME.AutoCompleteCustomSource.Add(end);
                        G4P1NAME.AutoCompleteCustomSource.Add(end);
                        G4P2NAME.AutoCompleteCustomSource.Add(end);
                        SBPlayer1Name.AutoCompleteCustomSource.Add(end);
                        SBPlayer2Name.AutoCompleteCustomSource.Add(end);
                    }
                }
            }
           // label13.Text = PlayerList.Items.Count.ToString() + " players";

        }

        private void HowtouseBTN_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Starting off, head to the event you wish to use this program for on Start.gg and head to the" +
                " Event Settings Menu > Attendees and click the export button in the top right.\n\nThen click the " +
                "'Import From CSV' button and find the file that you just downloaded.\n\nAfter that just select which" +
                " game you are running from the drop down and this program will add all the players registered for the event" +
                " (maybe some extras too, unknown bug) which you can then autofill any of the textboxes below the Player list." +
                "\n\nThe Scoreboard must first be directed to where to save files by clicking the '...' button. This will generate 5" +
                "text files for each player, their score and the bracket location of the match. \n\nYou can either manually add players" +
                " to the scoreboard or use the staging areas to add players to the scoreboard section. \n\nThe '+' and '-' buttons will" +
                " change the scores appropriately.\n\nThe 'Switch' button will swap both players and their current scores. \n\nThe 'Reset'" +
                " button will clear the player boxes, scoreboxes and bracket location of the scoreboard area. \n\nFinally the 'Save' button" +
                "will save over the 5 files in the Scoreboard Location folder.");
        }

        private void PlayerListAddBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (PlayerListAddBox.Text != "")
                    AddtoPlayerlistBTN.PerformClick();
                else
                    return;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ScoreboardLocation.Text = Settings.Default.SBLocation;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.SBLocation = ScoreboardLocation.Text;
            Settings.Default.Save();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EventNo--;
            textBox1.Text = EventNo.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EventNo++;
            textBox1.Text = EventNo.ToString();
        }
    }
}
