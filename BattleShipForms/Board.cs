using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipForms
{
    public class Board
    {
        public Button[,] Map { get; set; }
        public List<Boat> Boats { get; set; }
        public int IndexBoat { get; set; }
        public bool Full { get; set; }

        public Board()
        {
            this.Map = new Button[10, 10];
            IndexBoat = 0;
            Full= false;
        }

        public Board(List<Boat> boat)
        {
            this.Boats = boat;
            this.Map = new Button[10, 10];
            IndexBoat = 0;
            Full = false;
        }


        public void AddBoats(Button button)
        {
            int indexBoat = this.IndexBoat;
            if (this.Boats[indexBoat].BoatCounterPos > 0)
            {
                int typeBoat = Boats[indexBoat].Id;
                switch (typeBoat)
                {
                    case 0:
                        if (Boats[indexBoat].BoatCounterPos == 2)
                        {
                            button.BackgroundImage = Properties.Resources.Boat2;
                            button.Tag = "BOAT";
                            Boats[indexBoat].BoatCounterPos--;
                            button.FlatStyle = FlatStyle.Flat;
                            button.FlatAppearance.BorderColor = Color.Black;
                        }
                        else
                        {
                            try
                            {
                                button.BackgroundImage = Properties.Resources.Boat2;
                                button.Tag = "BOAT";
                                Boats[indexBoat].BoatCounterPos--;
                                button.FlatStyle = FlatStyle.Flat;
                                button.FlatAppearance.BorderColor = Color.Black;
                            }
                            catch
                            {

                            }

                        }
                        break;

                    case 1:
                        button.BackgroundImage = Properties.Resources.Boat3;
                        button.Tag = "BOAT";
                        button.FlatAppearance.BorderColor = Color.Black;
                        Boats[indexBoat].BoatCounterPos--;
                        break;

                    case 2:
                        button.BackgroundImage = Properties.Resources.Boat4;
                        button.Tag = "BOAT";
                        button.FlatAppearance.BorderColor = Color.Black;
                        Boats[indexBoat].BoatCounterPos--;
                        break;

                    case 3:
                        button.BackgroundImage = Properties.Resources.Boat5;
                        button.Tag = "BOAT";
                        button.FlatAppearance.BorderColor = Color.Black;
                        Boats[indexBoat].BoatCounterPos--;
                        if (Boats[indexBoat].BoatCounterPos == 0)
                        {
                            IndexBoat = 5;
                        }

                        break;
                }
            }
            else
            {
                this.IndexBoat++;
                    AddBoats(button);
            }
        }
    }
}
