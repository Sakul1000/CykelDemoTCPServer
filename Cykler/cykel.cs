using System;
using System.Collections.Generic;
using System.Text;

namespace Cykler
{
   public class cykel
    {
        private int _id;
        private string _farve;
        private int _pris;
        private int _gear;

        public cykel(int id, string farve, int pris, int gear)
        {
            _id = id;
            _farve = farve;
            _pris = pris;
            _gear = gear;
        }

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string Farve
        {
            get => _farve;
            set => _farve = value;
        }

        public int Pris
        {
            get => _pris;
            set => _pris = value;
        }

        public int Gear
        {
            get => _gear;
            set => _gear = value;
        }
    }
}
