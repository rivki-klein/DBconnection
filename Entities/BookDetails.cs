namespace Entities
{
    public class BookDetails
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }

        public BookDetails(int id, string firstName, string lastName, string city,
            string country, string phone)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.City = city;
            this.Country = country;
            this.Phone = phone;
        }
    }
}