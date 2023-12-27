using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ExpensesReimbursement.Pages
{
    public class ExpensesModel(ExpensesDBContext dbContext) : PageModel
    {
        public IEnumerable<Expense>? Expenses;

        [BindProperty]
        public Expense? Expense { get; set; }

        public async Task OnGetAsync()
        {
            Expenses = await dbContext.Expenses
                .OrderByDescending(x => x.Date)
                .ToArrayAsync();
        }

        public async Task<IActionResult> OnPostAsync() 
        {
            if (!ModelState.IsValid) 
            {
                return Page();
            }

            if (Expense != null)
            {
                dbContext.Expenses.Add(Expense);
                await dbContext.SaveChangesAsync();
            }

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var expense = dbContext.Expenses.Find(id);

            if (expense != null)
            {
                dbContext.Expenses.Remove(expense);
                await dbContext.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}
