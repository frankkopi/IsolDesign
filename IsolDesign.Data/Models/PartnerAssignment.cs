namespace IsolDesign.Data.Models
{
    public class PartnerAssignment : Assignment
    {
        public int PartnerId { get; set; }  // FK

        public string Credits { get; set; } // helpers on the Assignment


        public virtual Partner Partner { get; set; }
    }
}
