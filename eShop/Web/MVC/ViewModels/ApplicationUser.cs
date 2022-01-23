namespace MVC.ViewModels;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    public string CardHolderName { get; set; } = null!;

    public string CardNumber { get; set; } = null!;

    public int CardType { get; set; }

    public string City { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string CountryCode { get; set; } = null!;

    public string Expiration { get; set; } = null!;

    [Required]
    public string LastName { get; set; } = null!;

    public double Latitude { get; set; }

    public double Longitude { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    public string SecurityNumber { get; set; } = null!;

    public string State { get; set; } = null!;

    public string StateCode { get; set; } = null!;

    public string Street { get; set; } = null!;

    public string ZipCode { get; set; } = null!;
}
