using System.ComponentModel.DataAnnotations;

namespace ExpensesReimbursement;

public class Expense
{
    public int Id { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [Required]
    public string? Description { get; set; }
    
    [Required]
    [Range(double.Epsilon, int.MaxValue, ErrorMessage = "Price should greater than zero.")]
    public decimal? Price { get; set; }
}