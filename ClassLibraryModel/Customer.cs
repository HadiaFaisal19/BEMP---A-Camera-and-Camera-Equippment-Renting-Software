using System.ComponentModel.DataAnnotations;

namespace ClassLibraryModel
{
    public class Customer
    {
        [Key]
        public string CustomerCnic { get; set; }
        public string CustomerName { get; set; }
        public string CustomerContact { get; set; }

        public string ReferenceName { get; set; }
        public string ReferenceContact { get; set; }

        public string PictureUrl { get; set; }

        public DateTime Dob { get; set; }
    }
}

