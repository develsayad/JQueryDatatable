using Core.Web.Models.Base;

namespace Core.Web.Models
{
    public class Customer : BaseEntity
    {


        //public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }




    }
}
