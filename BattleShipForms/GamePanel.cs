using BattleShipForms.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        static List<Boat> boats;
        Board PlayerBoard;
        Board BotBoard;
        public List<Button> PlayerButtons = new List<Button>();
        public List<Button> PCButtons = new List<Button>();
        public GamePanel()
        {
            InitializeComponent();
            boats = LoadBoats();
            PlayerBoard = new Board(boats);
            BotBoard = new Board(boats);
            LoadButtons();
        }


        public void LoadButtons()
        {
            int colloms = 9;
            int lines = 9;
            int counter = 99;

            //Load Player Buttons
            foreach (Control c in ((Control)panel2).Controls)
            {
                if (c is Button)
                {
                    Button button = (Button)c;
                    PlayerButtons.Add(button);
                    if(lines >= 0)
                    {
                        PlayerBoard.Map[colloms, lines] = button;
                        PlayerBoard.Map[colloms, lines].Tag = counter;
                        PlayerBoard.Map[colloms, lines].Text = counter.ToString();
                        PlayerBoard.Map[colloms, lines].Click += BoardGame;
                        lines--;
                    }
                    else
                    {
                        lines = 9;
                        colloms--;
                        PlayerBoard.Map[colloms, lines] = button;
                        PlayerBoard.Map[colloms, lines].Click += BoardGame;
                        PlayerBoard.Map[colloms, lines].Tag = counter;
                        PlayerBoard.Map[colloms, lines].Text = counter.ToString();
                        lines--;
                    }
                    counter--;
                }
            }
            colloms = 9;
            lines = 9;
            counter = 99;

            //Load Bot Buttons
            foreach (Control c in ((Control)panel4).Controls)
            {
                if (c is Button)
                {
                    Button button = (Button)c;
                    PCButtons.Add(button);
                    if (lines > 0)
                    {
                        BotBoard.Map[colloms, lines] = button;
                        BotBoard.Map[colloms, lines].Tag = counter;

                         BotBoard.Map[colloms, lines].Text = counter.ToString();
                        lines--;
                    }
                    else
                    {
                        lines = 9;
                        BotBoard.Map[colloms, lines] = button;
                        BotBoard.Map[colloms, lines].Tag = counter;

                        BotBoard.Map[colloms, lines].Text = counter.ToString();
                        lines--;
                    }
                    counter--;
                }
            }
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
            Button button = (Button)sender;

            if (PlayerBoard.IndexBoat < 5)
            {
                    PlayerBoard.AddBoats(button);
                    ChangeBoatlogo(PlayerBoard.IndexBoat);
            }
            else
            {
                MessageBox.Show("Jogo ");
                pictureBox5.Enabled= false;
                pictureBox5.Visible= false;
                PlayerBoard.Full = true;
                label51.Visible= false;
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
    }
}
