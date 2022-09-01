using System.ComponentModel.DataAnnotations;

namespace CM.Customers
{
    public class Customer
    {
        
        public int customerID { get; set; }
        [MaxLength(50,ErrorMessage = "The length can't be more than 50 characters")]
        public string firstName { get; set; }
        [Required(ErrorMessage ="Field is required"),MaxLength(50, ErrorMessage = "The length can't be more than 50 characters")]
        public string lastName { get; set; }
        [MaxLength(15,ErrorMessage = "Invalid Phone Number")]
        public string phoneNumber { get; set; }
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string email { get; set; }
        [Required(ErrorMessage = "Field is required")]
        public string notes { get; set; }
        public decimal totalPurchaseAmount { get; set; }
    }
}
