using System.ComponentModel.DataAnnotations;

namespace IsolDesign.Domain.Models
{

    public class AssignmentModel
    {
        public int AssignmentId { get; set; }

        public string WorkTitle { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

        public string Photo { get; set; }

        public string Drawing { get; set; }

        public string Video { get; set; }

    }
}
