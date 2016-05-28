namespace IsolDesign.Data.Models
{
    public class Subcontractor
    {
        public int SubcontractorId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Country { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Homepage { get; set; }

        public string ContactName { get; set; }

        public string ContactPhone { get; set; }

        public string ContactEmail { get; set; }

        public int PartnerId { get; set; }


        public virtual Partner Partner { get; set; }
    }
}
