using ExpensesReimbursement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExpensesReimbursement.Pages.Expenses
{
    public class CreateModel(ExpensesDBContext dBContext) : PageModel
    {
        [BindProperty]
        public Expense? Expense { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Expense != null)
            {
                dBContext.Expenses.Add(Expense);
                await dBContext.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
