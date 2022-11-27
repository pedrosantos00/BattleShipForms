using BattleShipForms.Properties;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;
namespace BattleShipForms
{


    public partial class GamePanel : Form
    {
        List<Boat> PlayerBoats;
        List<Boat> BotBoats;
        Board PlayerBoard;
        Board BotBoard;
        public List<Button> PlayerButtons = new List<Button>();
        public List<Button> PCButtons = new List<Button>();
        public GamePanel()
        {
            InitializeComponent();
            PlayerBoats = LoadBoats();
            BotBoats = LoadBoats();
            PlayerBoard = new Board(PlayerBoats, label49,panel2);
            BotBoard = new Board(BotBoats, label49, panel4);
            LoadButtons();
            PlayerBoard.Panel.Cursor = new Cursor(Properties.Resources.Boat2.GetHicon());
            panel4.Cursor = new Cursor(Properties.Resources.Hit.GetHicon());
            BotBoard.GenerateRandomShipPositions();
            panel4.Visible = false;
        }

        public void LoadButtons()
        {
            int counter = 99;
            //Load Player Buttons
            foreach (Control c in ((Control)panel2).Controls)
            {

                if (c is Button)

                {
                    Button button = (Button)c;
                    PlayerBoard.Buttons.Add(button);
                    int index = PlayerBoard.Buttons.IndexOf(button);
                    PlayerBoard.Buttons[index].Click += BoardGame;
                  //  PlayerBoard.Buttons[index].Text = counter.ToString();
                     button.FlatAppearance.MouseOverBackColor= Color.Blue;
                    counter--;
                }
            }
            PlayerBoard.Buttons.Reverse();

            //Load Bot Buttons
            foreach (Control c in ((Control)panel4).Controls)
            {
                if (c is Button)
                {
                    Button button = (Button)c;
                    BotBoard.Buttons.Add(button);
                    int index = BotBoard.Buttons.IndexOf(button);
                    BotBoard.Buttons[index].Click += Attack;
                    button.FlatAppearance.MouseOverBackColor = Color.Red;
                }
            }
            BotBoard.Buttons.Reverse();
        }


        public List<Boat> LoadBoats()
        {
            Boat smallShip = new Boat("smallShip", 2, 0);
            Boat smallShip2 = new Boat("smallShip2", 2, 0);
            Boat destroyer = new Boat("destroyer", 3, 1);
            Boat battleShip = new Boat("battleShip", 4, 2);
            Boat cruiser = new Boat("cruiser", 5, 3);
            List<Boat> setupBoatsHelpder = new List<Boat>() { smallShip, smallShip2, destroyer, battleShip, cruiser };
            return setupBoatsHelpder;
        }

        public void BoardGame(object sender, EventArgs e)
        {
            int index = PlayerBoard.Buttons.IndexOf((Button)sender);
            Button button = (Button)sender;
            if (PlayerBoard.IndexBoat < 5)
            {
                if (PlayerBoard.IndexBoat == 4 && PlayerBoard.Boats[4].BoatCounterPos == 1)
                {
                    PlayerBoard.AddBoats(button, index);
                    ChangeBoatlogo(PlayerBoard.IndexBoat);
                    if (PlayerBoard.Boats[4].BoatCounterPos == 0)
                    {
                        foreach (Button btn in PlayerBoard.Buttons)
                        {
                            btn.Click -= BoardGame;
                        }
                        pictureBox5.Enabled = false;
                        pictureBox5.Visible = false;
                        PlayerBoard.Full = true;
                        label51.Visible = false;
                        panel4.Visible = true;
                        button101.Visible = false;
                    }
                }
                else
                {
                    PlayerBoard.AddBoats(button, index);
                    ChangeBoatlogo(PlayerBoard.IndexBoat);
                }
            }
            
        }

        public void Attack(object sender, EventArgs e)
        {
            int index = BotBoard.Buttons.IndexOf((Button)sender);
            Button button = (Button)sender;
            if(button.Tag != "BOAT")
            {
                button.BackgroundImage = Properties.Resources.water;
                button.BackgroundImage.Tag = "WATER";
                button.Enabled = false;
                BotAttack();
            }
            else
            {
                button.BackgroundImage = Properties.Resources.Hit;
                button.BackgroundImage.Tag = "HIT";
                button.Enabled = false;
                BotBoard.Life--;
                BotAttack();
            }
            if (BotBoard.Life == 0)
            {
                MessageBox.Show("You Win!");
                this.Close();
            }
        }

        public void BotAttack()
        {
            Random random = new Random();
            int posAttack = random.Next(0, 99);

            while (true)
            {
                if(PlayerBoard.Buttons[posAttack].Enabled == true)
                {
                    if (PlayerBoard.Buttons[posAttack].Tag != "BOAT" || PlayerBoard.Buttons[posAttack].Tag == "WATER" || PlayerBoard.Buttons[posAttack].Tag == "HIT")
                    {
                        PlayerBoard.Buttons[posAttack].BackgroundImage = Properties.Resources.water;
                        PlayerBoard.Buttons[posAttack].BackgroundImage.Tag = "WATER";
                        PlayerBoard.Buttons[posAttack].Enabled = false;
                    }
                    else
                    {
                        PlayerBoard.Buttons[posAttack].BackgroundImage = Properties.Resources.Hit;
                        PlayerBoard.Buttons[posAttack].BackgroundImage.Tag = "HIT";
                        PlayerBoard.Buttons[posAttack].Enabled = false;
                        PlayerBoard.Life--;
                    }
                    if (PlayerBoard.Life == 0)
                    {
                        MessageBox.Show("You Lose!");
                        this.Close();
                    }
                    break;
                }
                else
                {
                    posAttack = random.Next(0, 99);
                }
                
            }

        }

        public void ChangeBoatlogo(int number)
        {
            switch (number)
            {
                case 0:
                    pictureBox5.Image = Properties.Resources.Boat2Big;
                    break;
                case 1:
                    pictureBox5.Image = Properties.Resources.Boat2Big;
                    break;
                case 2:
                    pictureBox5.Image = Properties.Resources.Boat3Big;

                    break;
                case 3:
                    pictureBox5.Image = Properties.Resources.Boat4Big;
                    break;
                case 4:
                    pictureBox5.Image = Properties.Resources.Boat5Big;
                    break;
            }


            /*PlayerButtons[0].BackgroundImage = Properties.Resources.Boat2;
            PlayerButtons[0].FlatAppearance.BorderColor= Color.Black;
                PlayerButtons[1].BackgroundImage = Properties.Resources.Boat3;
                PlayerButtons[2].BackgroundImage = Properties.Resources.Boat4;
            PlayerButtons[3].BackgroundImage = Properties.Resources.Boat5;*/
        }

        private void button101_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Working on that");
        }
    }
}
