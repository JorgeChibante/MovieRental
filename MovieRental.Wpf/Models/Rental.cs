namespace MovieRental.Wpf.Models;

public class Rental
{
    public int Id { get; set; }
    public int DaysRented { get; set; }
    public int MovieId { get; set; }
    public int CustomerId { get; set; }
    public string PaymentMethod { get; set; }
}