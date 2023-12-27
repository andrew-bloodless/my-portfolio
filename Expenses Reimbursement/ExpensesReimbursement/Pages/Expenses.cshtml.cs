using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExpensesReimbursement.Pages
{
    public class ExpensesModel(ExpensesDBContext dbContext) : PageModel
    {
        public IEnumerable<Expense> Expenses;

        [BindProperty]
        public Expense? Expense { get; set; }

        public void OnGet()
        {
            Expenses = dbContext.Expenses
                .OrderByDescending(x => x.Date)
                .ToArray();
        }

        public IActionResult OnPost() 
        {
            if (!ModelState.IsValid) 
            {
                return Page();
            }

            if (Expense != null)
            {
                dbContext.Expenses.Add(Expense);
                dbContext.SaveChanges();
            }

            return RedirectToPage();
        }

        public IActionResult OnPostDelete(int id)
        {
            var expense = dbContext.Expenses.Find(id);

            if (expense != null)
            {
                dbContext.Expenses.Remove(expense);
                dbContext.SaveChanges();
            }

            return RedirectToPage();
        }
    }
}
