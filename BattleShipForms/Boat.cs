using BattleShipForms.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipForms
{
    public class Boat
    {
        public string Name { get; set; }
        public int length { get; set; }
        public int Id { get; set; }
        public int BoatCounterPos { get; set; }

        public Boat()
        {

        }
        public Boat(int length, int id)
        {
            this.length = length;
            this.BoatCounterPos = length;
            this.Id = id;
        }
        public Boat(string name, int length, int id)
        {
            Name = name;
            this.length = length;
            this.Id = id;
            this.BoatCounterPos = length;
        }


    }
}
