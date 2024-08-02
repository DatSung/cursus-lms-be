namespace Cursus.LMS.Model.Domain;

public class Company
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string PostalCode { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Website { get; set; }
    public DateTime FoundedDate { get; set; }
    public string LogoUrl { get; set; }
    public string Description { get; set; }
}