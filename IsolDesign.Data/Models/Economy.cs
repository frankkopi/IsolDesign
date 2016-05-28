using System;

namespace IsolDesign.Data.Models
{
    public class Economy
    {
        public int EconomyId { get; set; }

        public decimal Offer { get; set; }

        public decimal Budget { get; set; }

        public decimal MaterialCost { get; set; }

        public int TotalHours { get; set; }

        public decimal HourPrice { get; set; }

        public decimal TotalCost { get; set; }

        public int StatusHours { get; set; }

        public decimal StatusMaterials { get; set; }

        public decimal StatusTotal { get; set; }

        public DateTime StatusDate { get; set; }

    }
}
