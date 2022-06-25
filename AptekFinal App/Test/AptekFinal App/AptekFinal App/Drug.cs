using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AptekFinal_App.Enums;

namespace AptekFinal_App
{
    class Drug
    {
        public string Name { get; set; }

        public DrugType DrugType { get; set; }

        public  int Count { get; set; }

        public double PurchasePrice { get; set; }

        public double SalePrice { get; set; }

        public int Id { get; }
        private static int _id;

        public Drug()
        {
            Id = ++_id;
        }
    }
}
