using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleShipForms
{
    public class Board
    {

        public List<Boat> Boats { get; set; }
        public List<Button> Buttons { get; set; }
        public int IndexBoat { get; set; }
        public bool Full { get; set; }
        public System.Windows.Forms.Label Label { get; set; }
        public Panel Panel { get; set; }
        public int Life { get; set; }

        public Board()
        {
            IndexBoat = 0;
            this.Buttons = new List<Button>();
            Full = false;
            Life = 16;
        }



        public Board(List<Boat> boat, System.Windows.Forms.Label label, Panel panel)
        {
            this.Boats = boat;
            this.Buttons = new List<Button>();
            IndexBoat = 0;
            Full = false;
            Label = label;
            Panel = panel;
            Life = 16;
        }
        public void ChangeTopMessage(string mensagem, Color color)
        {
            Label.BackColor = color;
            Label.Text = mensagem;
        }
        public void GenerateRandomShipPositions()
        {
            GenerateMainPosRandom();
            this.IndexBoat = 0;
            while (this.IndexBoat != 5)
            {
                int indexBoat = this.IndexBoat;
                if (this.Boats[indexBoat].BoatCounterPos > 0)
            {
                int typeBoat = Boats[indexBoat].Id;
                int newpos = 0;
                switch (typeBoat)
                {

                    //BARCO TIPO 0
                    case 0:
                        switch (Boats[indexBoat].Vertical)
                        {
                            //VERTICAL
                            case true:
                                    newpos = this.Boats[indexBoat].MainPos + 1;
                                    try
                                    {
                                        if (this.Buttons[newpos].Tag != "BOAT" )
                                        {
                                            InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat2, "Boat2");
                                        }
                                        else
                                        {
                                            newpos = this.Boats[indexBoat].MainPos - 1;
                                            InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat2, "Boat2");

                                        }
                                    }
                                    catch
                                    {
                                        newpos = this.Boats[indexBoat].MainPos - 1;
                                        if (this.Buttons[newpos].Tag != "BOAT")
                                        {
                                            InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat2, "Boat2");

                                        }
                                        else
                                        {
                                            newpos = this.Boats[indexBoat].MainPos + 1;
                                            InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat2, "Boat2");
                                        }
                                    }
                                    break;
                            //HORIZONTAL
                            case false:
                                newpos = this.Boats[indexBoat].MainPos + 10;
                                    try
                                    {
                                        if (this.Buttons[newpos].Tag != "BOAT")
                                        {
                                            InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat2, "Boat2");
                                        }
                                        else
                                        {
                                            newpos = this.Boats[indexBoat].MainPos - 10;
                                            InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat2, "Boat2");

                                        }
                                    }
                                    catch
                                    {
                                        newpos = this.Boats[indexBoat].MainPos - 10;
                                        if (this.Buttons[newpos].Tag != "BOAT")
                                        {
                                            InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat2, "Boat2");

                                        }
                                        else
                                        {
                                            newpos = this.Boats[indexBoat].MainPos + 10;
                                            InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat2, "Boat2");
                                        }
                                    }
                                    break;
                        }
                        break;


                    // BARCO TIPO 1 
                    case 1:
                            switch (Boats[indexBoat].Vertical)
                            {
                                //VERTICAL
                                case true:
                                    switch (Boats[indexBoat].BoatCounterPos)
                                    {
                                        case 2:
                                            newpos = this.Boats[indexBoat].MainPos + 1;
                                            try
                                            {
                                                if (this.Buttons[newpos].Tag != "BOAT")
                                                {
                                                    InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat3, "Boat3");
                                                }
                                                else
                                                {
                                                    newpos = this.Boats[indexBoat].MainPos - 1;
                                                    InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat3, "Boat3");

                                                }
                                            }
                                            catch
                                            {
                                                newpos = this.Boats[indexBoat].MainPos - 1;
                                                if (this.Buttons[newpos].Tag != "BOAT")
                                                {
                                                    InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat3, "Boat3");

                                                }
                                                else
                                                {
                                                    newpos = this.Boats[indexBoat].MainPos + 1;
                                                    InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat3, "Boat3");
                                                }
                                            }
                                            break;
                                        case 1:
                                            newpos = this.Boats[indexBoat].MainPos + 2;
                                            try
                                            {
                                                if (this.Buttons[newpos].Tag != "BOAT")
                                                {
                                                    InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat3, "Boat3");
                                                }
                                                else
                                                {
                                                    newpos = this.Boats[indexBoat].MainPos - 2;
                                                    InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat3, "Boat3");

                                                }
                                            }
                                            catch
                                            {
                                                newpos = this.Boats[indexBoat].MainPos - 2;
                                                if (this.Buttons[newpos].Tag != "BOAT")
                                                {
                                                    InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat3, "Boat3");

                                                }
                                                else
                                                {
                                                    newpos = this.Boats[indexBoat].MainPos + 2;
                                                    InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat3, "Boat3");
                                                }
                                            }
                                            // sair do switch do barco
                                            break;
                                    }

                                    break;

                                //HORIZONTAL
                                case false:
                                    switch (Boats[indexBoat].BoatCounterPos)
                                    {
                                        case 2:
                                            newpos = this.Boats[indexBoat].MainPos + 10;
                                            try
                                            {
                                                if (this.Buttons[newpos].Tag != "BOAT")
                                                {
                                                    InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat3, "Boat3");
                                                }
                                                else
                                                {
                                                    newpos = this.Boats[indexBoat].MainPos - 10;
                                                    InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat3, "Boat3");

                                                }
                                            }
                                            catch
                                            {
                                                newpos = this.Boats[indexBoat].MainPos - 10;
                                                if (this.Buttons[newpos].Tag != "BOAT")
                                                {
                                                    InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat3, "Boat3");

                                                }
                                                else
                                                {
                                                    newpos = this.Boats[indexBoat].MainPos + 10;
                                                    InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat3, "Boat3");
                                                }
                                            }
                                            break;
                                        case 1:
                                            newpos = this.Boats[indexBoat].MainPos + 20;
                                            try
                                            {
                                                if (this.Buttons[newpos].Tag != "BOAT")
                                                {
                                                    InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat3, "Boat3");
                                                }
                                                else
                                                {
                                                    newpos = this.Boats[indexBoat].MainPos - 20;
                                                    InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat3, "Boat3");

                                                }
                                            }
                                            catch
                                            {
                                                newpos = this.Boats[indexBoat].MainPos - 20;
                                                if (this.Buttons[newpos].Tag != "BOAT")
                                                {
                                                    InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat3, "Boat3");

                                                }
                                                else
                                                {
                                                    newpos = this.Boats[indexBoat].MainPos + 20;
                                                    InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat3, "Boat3");
                                                }
                                            }
                                            // sair do switch do barco
                                            break;
                                    }
                                    break;
                            }
                            break;


                    // BARCO TIPO 2
                    case 2:
                            switch (Boats[indexBoat].Vertical)
                            {
                                //VERTICAL
                                case true:
                                    switch (Boats[indexBoat].BoatCounterPos)
                                    {
                                        case 3:
                                            newpos = this.Boats[indexBoat].MainPos + 1;
                                            try
                                            {
                                                if (this.Buttons[newpos].Tag != "BOAT")
                                                {
                                                    InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat4, "Boat4");
                                                }
                                                else
                                                {
                                                    newpos = this.Boats[indexBoat].MainPos - 1;
                                                    InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat4, "Boat4");
                                                }
                                            }
                                            catch
                                            {
                                                newpos = this.Boats[indexBoat].MainPos - 1;
                                                if (this.Buttons[newpos].Tag != "BOAT")
                                                {
                                                    InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat4, "Boat4");
                                                }
                                                else
                                                {
                                                    newpos = this.Boats[indexBoat].MainPos + 1;
                                                    InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat4, "Boat4");
                                                }
                                            }
                                            break;
                                        case 2:
                                            newpos = this.Boats[indexBoat].MainPos + 2;
                                            try
                                            {
                                                if (this.Buttons[newpos].Tag != "BOAT")
                                                {
                                                    InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat4, "Boat4");
                                                }
                                                else
                                                {
                                                    newpos = this.Boats[indexBoat].MainPos - 2;
                                                    InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat4, "Boat4");
                                                }
                                            }
                                            catch
                                            {
                                                newpos = this.Boats[indexBoat].MainPos - 2;
                                                if (this.Buttons[newpos].Tag != "BOAT")
                                                {
                                                    InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat4, "Boat4");
                                                }
                                                else
                                                {
                                                    newpos = this.Boats[indexBoat].MainPos + 2;
                                                    InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat4, "Boat4");
                                                }
                                            }
                                            break;
                                        case 1:
                                            newpos = this.Boats[indexBoat].MainPos + 3;
                                            try
                                            {
                                                if (this.Buttons[newpos].Tag != "BOAT")
                                                {
                                                    InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat4, "Boat4");
                                                }
                                                else
                                                {
                                                    newpos = this.Boats[indexBoat].MainPos - 3;
                                                    InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat4, "Boat4");
                                                }
                                            }
                                            catch
                                            {
                                                newpos = this.Boats[indexBoat].MainPos - 3;
                                                if (this.Buttons[newpos].Tag != "BOAT")
                                                {
                                                    InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat4, "Boat4");
                                                }
                                                else
                                                {
                                                    newpos = this.Boats[indexBoat].MainPos + 3;
                                                    InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat4, "Boat4");
                                                }
                                            }
                                            // sair do switch do barco
                                            break;
                                    }

                                    break;

                                //HORIZONTAL
                                case false:
                                    switch (Boats[indexBoat].BoatCounterPos)
                                    {
                                        case 3:
                                            newpos = this.Boats[indexBoat].MainPos + 10;
                                            try
                                            {
                                                if (this.Buttons[newpos].Tag != "BOAT")
                                                {
                                                    InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat4, "Boat4");
                                                }
                                                else
                                                {
                                                    newpos = this.Boats[indexBoat].MainPos - 10;
                                                    InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat4, "Boat4");
                                                }
                                            }
                                            catch
                                            {
                                                newpos = this.Boats[indexBoat].MainPos - 10;
                                                if (this.Buttons[newpos].Tag != "BOAT")
                                                {
                                                    InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat4, "Boat4");
                                                }
                                                else
                                                {
                                                    newpos = this.Boats[indexBoat].MainPos + 10;
                                                    InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat4, "Boat4");
                                                }
                                            }
                                            break;
                                        case 2:
                                            newpos = this.Boats[indexBoat].MainPos + 20;
                                            try
                                            {
                                                if (this.Buttons[newpos].Tag != "BOAT")
                                                {
                                                    InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat4, "Boat4");
                                                }
                                                else
                                                {
                                                    newpos = this.Boats[indexBoat].MainPos - 20;
                                                    InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat4, "Boat4");
                                                }
                                            }
                                            catch
                                            {
                                                newpos = this.Boats[indexBoat].MainPos - 20;
                                                if (this.Buttons[newpos].Tag != "BOAT")
                                                {
                                                    InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat4, "Boat4");
                                                }
                                                else
                                                {
                                                    newpos = this.Boats[indexBoat].MainPos + 20;
                                                    InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat4, "Boat4");
                                                }
                                            }
                                            break;
                                        case 1:
                                            newpos = this.Boats[indexBoat].MainPos + 30;
                                            try
                                            {
                                                if (this.Buttons[newpos].Tag != "BOAT")
                                                {
                                                    InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat4, "Boat4");
                                                }
                                                else
                                                {
                                                    newpos = this.Boats[indexBoat].MainPos - 30;
                                                    InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat4, "Boat4");
                                                }
                                            }
                                            catch
                                            {
                                                newpos = this.Boats[indexBoat].MainPos - 30;
                                                if (this.Buttons[newpos].Tag != "BOAT")
                                                {
                                                    InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat4, "Boat4");
                                                }
                                                else
                                                {
                                                    newpos = this.Boats[indexBoat].MainPos + 30;
                                                    InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat4, "Boat4");
                                                }
                                            }
                                            // sair do switch do barco
                                            break;
                                    }
                                    break;
                            }
                            break;

                    // BARCO TIPO 3
                    case 3:
                            switch (Boats[indexBoat].Vertical)
                            {
                                //VERTICAL
                                case true:
                                    switch (Boats[indexBoat].BoatCounterPos)
                                    {
                                        case 4:
                                            newpos = this.Boats[indexBoat].MainPos + 1;
                                            try
                                            {
                                                if (this.Buttons[newpos].Tag != "BOAT")
                                                {
                                                    InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat5, "Boat5");
                                                }
                                                else
                                                {
                                                    newpos = this.Boats[indexBoat].MainPos - 1;
                                                    InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat5, "Boat5");
                                                }
                                            }
                                            catch
                                            {
                                                newpos = this.Boats[indexBoat].MainPos - 1;
                                                if (this.Buttons[newpos].Tag != "BOAT")
                                                {
                                                    InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat5, "Boat5");
                                                }
                                                else
                                                {
                                                    newpos = this.Boats[indexBoat].MainPos + 1;
                                                    InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat5, "Boat5");
                                                }
                                            }
                                            break;
                                        case 3:
                                            newpos = this.Boats[indexBoat].MainPos + 2;
                                            try
                                            {
                                                if (this.Buttons[newpos].Tag != "BOAT")
                                                {
                                                    InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat5, "Boat5");
                                                }
                                                else
                                                {
                                                    newpos = this.Boats[indexBoat].MainPos - 2;
                                                    InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat5, "Boat5");
                                                }
                                            }
                                            catch
                                            {
                                                newpos = this.Boats[indexBoat].MainPos - 2;
                                                if (this.Buttons[newpos].Tag != "BOAT")
                                                {
                                                    InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat5, "Boat5");
                                                }
                                                else
                                                {
                                                    newpos = this.Boats[indexBoat].MainPos + 2;
                                                    InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat5, "Boat5");
                                                }
                                            }
                                            break;
                                        case 2:
                                            newpos = this.Boats[indexBoat].MainPos + 3;
                                            try
                                            {
                                                if (this.Buttons[newpos].Tag != "BOAT")
                                                {
                                                    InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat5, "Boat5");
                                                }
                                                else
                                                {
                                                    newpos = this.Boats[indexBoat].MainPos - 3;
                                                    InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat5, "Boat5");
                                                }
                                            }
                                            catch
                                            {
                                                newpos = this.Boats[indexBoat].MainPos - 3;
                                                if (this.Buttons[newpos].Tag != "BOAT")
                                                {
                                                    InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat5, "Boat5");
                                                }
                                                else
                                                {
                                                    newpos = this.Boats[indexBoat].MainPos + 3;
                                                    InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat5, "Boat5");
                                                }
                                            }
                                            break;
                                        case 1:
                                            newpos = this.Boats[indexBoat].MainPos + 4;
                                            try
                                            {
                                                if (this.Buttons[newpos].Tag != "BOAT")
                                                {
                                                    InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat5, "Boat5");
                                                }
                                                else
                                                {
                                                    newpos = this.Boats[indexBoat].MainPos - 4;
                                                    InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat5, "Boat5");
                                                }
                                            }
                                            catch
                                            {
                                                newpos = this.Boats[indexBoat].MainPos - 4;
                                                if (this.Buttons[newpos].Tag != "BOAT")
                                                {
                                                    InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat5, "Boat5");
                                                }
                                                else
                                                {
                                                    newpos = this.Boats[indexBoat].MainPos + 4;
                                                    InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat5, "Boat5");
                                                }
                                            }
                                            // sair do switch do barco
                                            break;
                                    }

                                    break;

                                //HORIZONTAL
                                case false:
                                    switch (Boats[indexBoat].BoatCounterPos)
                                    {
                                        case 4:
                                            newpos = this.Boats[indexBoat].MainPos + 10;
                                            try
                                            {
                                                if (this.Buttons[newpos].Tag != "BOAT")
                                                {
                                                    InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat5, "Boat5");
                                                }
                                                else
                                                {
                                                    newpos = this.Boats[indexBoat].MainPos -10;
                                                    InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat5, "Boat5");
                                                }
                                            }
                                            catch
                                            {
                                                newpos = this.Boats[indexBoat].MainPos - 10;
                                                if (this.Buttons[newpos].Tag != "BOAT")
                                                {
                                                    InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat5, "Boat5");
                                                }
                                                else
                                                {
                                                    newpos = this.Boats[indexBoat].MainPos + 10;
                                                    InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat5, "Boat5");
                                                }
                                            }
                                            break;
                                        case 3:
                                            newpos = this.Boats[indexBoat].MainPos + 20;
                                            try
                                            {
                                                if (this.Buttons[newpos].Tag != "BOAT")
                                                {
                                                    InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat5, "Boat5");
                                                }
                                                else
                                                {
                                                    newpos = this.Boats[indexBoat].MainPos - 20;
                                                    InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat5, "Boat5");
                                                }
                                            }
                                            catch
                                            {
                                                newpos = this.Boats[indexBoat].MainPos - 20;
                                                if (this.Buttons[newpos].Tag != "BOAT")
                                                {
                                                    InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat5, "Boat5");
                                                }
                                                else
                                                {
                                                    newpos = this.Boats[indexBoat].MainPos + 20;
                                                    InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat5, "Boat5");
                                                }
                                            }
                                            break;
                                        case 2:
                                            newpos = this.Boats[indexBoat].MainPos + 30;
                                            try
                                            {
                                                if (this.Buttons[newpos].Tag != "BOAT")
                                                {
                                                    InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat5, "Boat5");
                                                }
                                                else
                                                {
                                                    newpos = this.Boats[indexBoat].MainPos - 30;
                                                    InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat5, "Boat5");
                                                }
                                            }
                                            catch
                                            {
                                                newpos = this.Boats[indexBoat].MainPos - 30;
                                                if (this.Buttons[newpos].Tag != "BOAT")
                                                {
                                                    InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat5, "Boat5");
                                                }
                                                else
                                                {
                                                    newpos = this.Boats[indexBoat].MainPos + 30;
                                                    InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat5, "Boat5");
                                                }
                                            }
                                            break;
                                        case 1:
                                            newpos = this.Boats[indexBoat].MainPos + 40;
                                            try
                                            {
                                                if (this.Buttons[newpos].Tag != "BOAT")
                                                {
                                                    InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat5, "Boat5");
                                                }
                                                else
                                                {
                                                    newpos = this.Boats[indexBoat].MainPos - 40;
                                                    InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat5, "Boat5");
                                                }
                                            }
                                            catch
                                            {
                                                newpos = this.Boats[indexBoat].MainPos - 40;
                                                if (this.Buttons[newpos].Tag != "BOAT")
                                                {
                                                    InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat5, "Boat5");
                                                }
                                                else
                                                {
                                                    newpos = this.Boats[indexBoat].MainPos + 40;
                                                    InputBoatRandom(indexBoat, newpos, Properties.Resources.Boat5, "Boat5");
                                                }
                                            }
                                            // sair do switch do barco
                                            break;
                                    }
                                    break;
                            }
                            break;
                }
            }
            else
            {
                this.IndexBoat++;
            }
            }

        }

        private void InputBoatRandom(int indexBoat, int newpos, Bitmap img , string imagem)
        {
            try
            {
                // this.Buttons[newpos].BackgroundImage = img;
                // this.Buttons[newpos].BackgroundImage.Tag = imagem;

                this.Buttons[newpos].Tag = "BOAT";
                //this.Buttons[newpos].FlatAppearance.BorderSize = 1;
                //this.Buttons[newpos].FlatStyle = FlatStyle.Flat;
                //this.Buttons[newpos].FlatAppearance.BorderColor = Color.Black;
                this.Boats[indexBoat].BoatCounterPos--;
            }
            catch { }
                
        }

        private void GenerateMainPosRandom()
        {
            Random random = new Random();
            Random boolrandom = new Random();
            int mainBoard;
            for (int i = 0; i < 5; i++)
            {
                int indexBoat = this.IndexBoat;

                switch (Boats[indexBoat].Id)
                {
                    case 0:
                        mainBoard = random.Next(11, 18);
                        this.Boats[indexBoat].MainPos = mainBoard;
                      //  this.Buttons[mainBoard].BackgroundImage = Properties.Resources.Boat2;
                      //  this.Buttons[mainBoard].BackgroundImage.Tag = "Boat2";
                        this.Buttons[mainBoard].Tag = "BOAT";
                        //this.Buttons[mainBoard].FlatAppearance.BorderSize = 1;
                        // this.Buttons[mainBoard].FlatStyle = FlatStyle.Flat;
                        //this.Buttons[mainBoard].FlatAppearance.BorderColor = Color.Black;
                        //TRUE = VERTICAL
                        //FALSE = HORIZONTAL
                        this.Boats[indexBoat].Vertical = boolrandom.Next(0, 2) > 0 ? true : false;
                        this.Boats[indexBoat].BoatCounterPos--;
                        this.IndexBoat++;
                        break;
                    case 1:
                        mainBoard = random.Next(27, 28);
                        this.Boats[indexBoat].MainPos = mainBoard;
                        //  this.Buttons[mainBoard].BackgroundImage = Properties.Resources.Boat3;
                        // this.Buttons[mainBoard].BackgroundImage.Tag = "Boat3";
                        this.Buttons[mainBoard].Tag = "BOAT";
                        // this.Buttons[mainBoard].FlatAppearance.BorderSize = 1;
                        //this.Buttons[mainBoard].FlatStyle = FlatStyle.Flat;
                        //this.Buttons[mainBoard].FlatAppearance.BorderColor = Color.Black;
                        //TRUE = VERTICAL
                        //FALSE = HORIZONTAL
                        this.Boats[indexBoat].Vertical = boolrandom.Next(0, 2) > 0 ? true : false;
                        this.Boats[indexBoat].BoatCounterPos--;
                        this.IndexBoat++;
                        break;
                    case 2:
                        mainBoard = random.Next(66,66);
                        this.Boats[indexBoat].MainPos = mainBoard;
                        //  this.Buttons[mainBoard].BackgroundImage = Properties.Resources.Boat4;
                        //this.Buttons[mainBoard].BackgroundImage.Tag = "Boat4";
                        this.Buttons[mainBoard].Tag = "BOAT";
                        // this.Buttons[mainBoard].FlatAppearance.BorderSize = 1;
                        // this.Buttons[mainBoard].FlatStyle = FlatStyle.Flat;
                        // this.Buttons[mainBoard].FlatAppearance.BorderColor = Color.Black;
                        //TRUE = VERTICAL
                        //FALSE = HORIZONTAL
                        this.Boats[indexBoat].Vertical = boolrandom.Next(0, 2) > 0 ? true : false;
                        this.Boats[indexBoat].BoatCounterPos--;
                        this.IndexBoat++;
                        break;
                    case 3:
                        mainBoard = random.Next(54, 55);
                        this.Boats[indexBoat].MainPos = mainBoard;
                        //    this.Buttons[mainBoard].BackgroundImage = Properties.Resources.Boat5;
                        //this.Buttons[mainBoard].BackgroundImage.Tag = "Boat5";
                        this.Buttons[mainBoard].Tag = "BOAT";
                        //  this.Buttons[mainBoard].FlatAppearance.BorderSize = 1;
                        //  this.Buttons[mainBoard].FlatStyle = FlatStyle.Flat;
                        // this.Buttons[mainBoard].FlatAppearance.BorderColor = Color.Black;
                        //TRUE = VERTICAL
                        //FALSE = HORIZONTAL
                        this.Boats[indexBoat].Vertical = boolrandom.Next(0, 2) > 0 ? true : false;
                        this.Boats[indexBoat].BoatCounterPos--;
                        this.IndexBoat++;
                        break;
                }

            }
        }

        public void AddBoats(Button button,int index)
        {
            int indexBoat = this.IndexBoat;
            if (this.Boats[indexBoat].BoatCounterPos > 0)
            {
                int typeBoat = Boats[indexBoat].Id;
                switch (typeBoat)
                {

                    //BARCO TIPO 0
                    case 0:
                        if (Boats[indexBoat].BoatCounterPos == 2)
                        {
                            FirstPos(button, index, indexBoat, Properties.Resources.Boat2, "Boat2");
                        }
                        else
                        {
                            Ship0NextMove(button, index, indexBoat);
                        }
                        if (this.IndexBoat == 1 && this.Boats[indexBoat].BoatCounterPos == 0)
                        this.Panel.Cursor = new Cursor(Properties.Resources.Boat3.GetHicon());
                        break;


                        // BARCO TIPO 1 
                    case 1:
                        switch (Boats[indexBoat].BoatCounterPos)
                        {
                            case 3:
                                FirstPos(button, index, indexBoat, Properties.Resources.Boat3, "Boat3");
                                break;
                            case 2:
                                CheckPosition(button, index, indexBoat,Properties.Resources.Boat3, "Boat3");
                                break;

                            case 1:
                                AddBoatsToBoard(button, index, indexBoat, Properties.Resources.Boat3, 1 , 10, "Boat3");
                                if (this.Boats[indexBoat].BoatCounterPos == 0)
                                    this.Panel.Cursor = new Cursor(Properties.Resources.Boat4.GetHicon());
                                break;

                                // sair do switch do barco
                        }
                        break;


                                // BARCO TIPO 2
                    case 2:
                        this.Panel.Cursor = new Cursor(Properties.Resources.Boat4.GetHicon());
                        switch (Boats[indexBoat].BoatCounterPos)
                        {
                            case 4:
                                FirstPos(button, index, indexBoat, Properties.Resources.Boat4, "Boat4");
                                break;
                            case 3:
                                CheckPosition(button, index, indexBoat, Properties.Resources.Boat4, "Boat4");
                                break;

                            case 2:
                                AddBoatsToBoard(button, index, indexBoat, Properties.Resources.Boat4, 1, 10, "Boat4");
                                break;
                            case 1:
                                AddBoatsToBoard(button, index, indexBoat, Properties.Resources.Boat4, 1, 10, "Boat4");
                                if (this.Boats[indexBoat].BoatCounterPos == 0)
                                this.Panel.Cursor = new Cursor(Properties.Resources.Boat5.GetHicon());
                                break;
                                // sair do switch do barco
                        }
                        break;

                    // BARCO TIPO 3
                    case 3:
                        this.Panel.Cursor = new Cursor(Properties.Resources.Boat5.GetHicon());
                        switch (Boats[indexBoat].BoatCounterPos)
                        {
                            case 5:
                                FirstPos(button, index, indexBoat, Properties.Resources.Boat5, "Boat5");
                                break;
                            case 4:
                                CheckPosition(button, index, indexBoat, Properties.Resources.Boat5, "Boat5");
                                break;

                            case 3:
                                AddBoatsToBoard(button, index, indexBoat, Properties.Resources.Boat5, 1, 10, "Boat5");
                                break;
                            case 2:
                                AddBoatsToBoard(button, index, indexBoat, Properties.Resources.Boat5, 1, 10, "Boat5");
                                break;
                            case 1:
                                AddBoatsToBoard(button, index, indexBoat, Properties.Resources.Boat5, 1, 10, "Boat5");
                                if (this.Boats[indexBoat].BoatCounterPos == 0)
                                    this.StartGame();
                                break;
                                // sair do switch do barco
                        }

                        break;
                }
            }
            else
            {
                this.IndexBoat++;
                    AddBoats(button, index);
            }
        }

        private void StartGame()
        {
            this.Panel.Cursor = Cursors.No;
            this.Label.Text = "Hit a square from opponents Board";
            this.IndexBoat++;
        }

        private void Ship0NextMove(Button button, int index, int indexBoat)
        {
            try
            { 
                Label.BackColor = Color.Cyan;
                if ((this.Buttons[index - 1] == this.Buttons[this.Boats[indexBoat].MainPos] ||
                     this.Buttons[index + 1] == this.Buttons[this.Boats[indexBoat].MainPos] ||
                     this.Buttons[index - 10] == this.Buttons[this.Boats[indexBoat].MainPos] ||
                     this.Buttons[index + 10] == this.Buttons[this.Boats[indexBoat].MainPos] &&
                     this.Buttons[index].Tag != "BOAT") && this.Buttons[index].Tag == null)
                {
                    button.BackgroundImage = Properties.Resources.Boat2;
                    button.BackgroundImage.Tag = "Boat2";
                    button.Tag = "BOAT";
                    Boats[indexBoat].BoatCounterPos--;
                    this.Buttons[index].FlatAppearance.BorderSize = 1;

                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderColor = Color.Black;
                    Label.Text = "Please add your Ship into Board by choosing the square";

                }
                else
                {
                    Label.BackColor = Color.Red;
                    Label.Text = "The Ship can not be splitted or overlaid, please select squares in a row ";
                }
            }
            catch { }

        }

        private void FirstPos(Button button, int index, int indexBoat, Bitmap img, string imagem)
        {
            if (this.Buttons[index].Tag != "BOAT" && this.Buttons[index].Tag == null)
            {
                this.Boats[indexBoat].MainPos = this.Buttons.IndexOf(button);
                button.BackgroundImage = img;
                button.BackgroundImage.Tag = imagem;
                button.Tag = "BOAT";
                button.FlatAppearance.BorderColor = Color.Black;
                Boats[indexBoat].BoatCounterPos--;
                this.Buttons[index].FlatAppearance.BorderSize = 1;
                this.Buttons[index].FlatStyle = FlatStyle.Flat;
                this.Buttons[index].FlatAppearance.BorderColor = Color.Black;
                Label.BackColor = Color.Cyan;
                Label.Text = "Please add your Ship into Board by choosing the square";
            }
            else
            {
                Label.BackColor = Color.Red;
                Label.Text = "The Ship can not be splitted or overlaid, please select squares in a row ";
            }
        }

        private void AddBoatsToBoard(Button button, int index, int indexBoat, Bitmap img, int posCheckVertical, int posCheckHorizontal, string imagem)
        {
            //VERTICAL
            if (this.Boats[indexBoat].Vertical == true)
                if ((this.Buttons[index + posCheckVertical].Tag == "BOAT" && this.Buttons[index + posCheckVertical].BackgroundImage.Tag == imagem) && this.Buttons[index].Tag == null)
                {
                    button.BackgroundImage = img;
                    button.BackgroundImage.Tag = imagem;
                    button.Tag = "BOAT";
                    button.FlatAppearance.BorderColor = Color.Black;
                    Boats[indexBoat].BoatCounterPos--;
                    this.Buttons[index].FlatAppearance.BorderSize = 1;
                    this.Buttons[index].FlatStyle = FlatStyle.Flat;
                    this.Buttons[index].FlatAppearance.BorderColor = Color.Black;
                    Label.BackColor = Color.Cyan;
                    Label.Text = "Please add your Ship into Board by choosing the square";

                }
                else if ((this.Buttons[index - posCheckVertical].Tag == "BOAT" && this.Buttons[index - posCheckVertical].BackgroundImage.Tag == imagem) && this.Buttons[index].Tag == null)
                {
                    button.BackgroundImage = img;
                    button.BackgroundImage.Tag = imagem;
                    button.Tag = "BOAT";
                    button.FlatAppearance.BorderColor = Color.Black;
                    Boats[indexBoat].BoatCounterPos--;
                    this.Buttons[index].FlatAppearance.BorderSize = 1;
                    this.Buttons[index].FlatStyle = FlatStyle.Flat;
                    this.Buttons[index].FlatAppearance.BorderColor = Color.Black;
                    Label.BackColor = Color.Cyan;
                    Label.Text = "Please add your Ship into Board by choosing the square";
                }
                else
                {
                    Label.BackColor = Color.Red;
                    Label.Text = "The Ship can not be splitted or overlaid, please select squares in a row ";
                }
            //HORIZONTAL
            else if (this.Boats[indexBoat].Vertical == false)
            {
                try
                {
                    if ((this.Buttons[index + posCheckHorizontal].Tag == "BOAT" && this.Buttons[index + posCheckHorizontal].BackgroundImage.Tag == imagem) && this.Buttons[index].Tag == null)
                    {
                        button.BackgroundImage = img;
                        button.BackgroundImage.Tag = imagem;
                        button.Tag = "BOAT";
                        button.FlatAppearance.BorderColor = Color.Black;
                        Boats[indexBoat].BoatCounterPos--;
                        this.Buttons[index].FlatAppearance.BorderSize = 1;

                        this.Buttons[index].FlatStyle = FlatStyle.Flat;
                        this.Buttons[index].FlatAppearance.BorderColor = Color.Black;
                        Label.BackColor = Color.Cyan;
                        Label.Text = "Please add your Ship into Board by choosing the square";

                    }
                }
                catch { }
                try
                {
                     if ((this.Buttons[index - posCheckHorizontal].Tag == "BOAT" && this.Buttons[index - posCheckHorizontal].BackgroundImage.Tag == imagem) && this.Buttons[index].Tag == null)
                    {
                        button.BackgroundImage = img;
                        button.BackgroundImage.Tag =imagem;
                        button.Tag = "BOAT";
                        button.FlatAppearance.BorderColor = Color.Black;
                        Boats[indexBoat].BoatCounterPos--;
                        this.Buttons[index].FlatAppearance.BorderSize = 1;

                        this.Buttons[index].FlatStyle = FlatStyle.Flat;
                        this.Buttons[index].FlatAppearance.BorderColor = Color.Black;
                        Label.BackColor = Color.Cyan;
                        Label.Text = "Please add your Ship into Board by choosing the square";
                    }
                }
                catch {}
            }
        }

        private void CheckPosition(Button button, int index, int indexBoat, Bitmap img, string imagem)
        {
            //verificar posiçao =  vertical
            if ((this.Buttons[index - 1] == this.Buttons[this.Boats[indexBoat].MainPos] && this.Buttons[index - 1].BackgroundImage.Tag == imagem) ||
                (this.Buttons[index + 1] == this.Buttons[this.Boats[indexBoat].MainPos] && this.Buttons[index + 1].BackgroundImage.Tag == imagem) &&
                this.Buttons[index].Tag != "BOAT" )
            {
                button.BackgroundImage = img;
                button.BackgroundImage.Tag = imagem;
                button.Tag = "BOAT";
                button.FlatAppearance.BorderColor = Color.Black;
                Boats[indexBoat].BoatCounterPos--;
                this.Buttons[index].FlatAppearance.BorderSize = 1;

                this.Buttons[index].FlatStyle = FlatStyle.Flat;
                this.Buttons[index].FlatAppearance.BorderColor = Color.Black;
                Label.BackColor = Color.Cyan;
                Label.Text = "Please add your Ship into Board by choosing the square";
                this.Boats[indexBoat].Vertical = true;
            }
            //verificar posiçao =  horizontal
            else if ((this.Buttons[index - 10] == this.Buttons[this.Boats[indexBoat].MainPos] && this.Buttons[index - 10].BackgroundImage.Tag == imagem) ||
                (this.Buttons[index + 10] == this.Buttons[this.Boats[indexBoat].MainPos] && this.Buttons[index + 10].BackgroundImage.Tag == imagem) &&
                this.Buttons[index].Tag != "BOAT")
            {
                button.BackgroundImage = img;
                button.BackgroundImage.Tag = imagem;
                button.Tag = "BOAT";
                button.FlatAppearance.BorderColor = Color.Black;
                Boats[indexBoat].BoatCounterPos--;
                this.Buttons[index].FlatAppearance.BorderSize = 1;

                this.Buttons[index].FlatStyle = FlatStyle.Flat;
                this.Buttons[index].FlatAppearance.BorderColor = Color.Black;
                Label.BackColor = Color.Cyan;
                Label.Text = "Please add your Ship into Board by choosing the square";
                this.Boats[indexBoat].Vertical = false;
            }
            else
            {
                Label.BackColor = Color.Red;
                Label.Text = "The Ship can not be splitted or overlaid, please select squares in a row ";
            }
        }

    }
}
