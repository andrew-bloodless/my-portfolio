using ExpensesReimbursement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace MyApp.Namespace
{
    public class EditModel(ExpensesDBContext dBContext) : PageModel
    {
        [BindProperty]
        public Expense? Expense { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Expense = await dBContext.Expenses.FirstOrDefaultAsync(x => x.Id == id);

            if (Expense == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Expense != null)
            {
                dBContext.Attach(Expense).State = EntityState.Modified;

                try
                {
                    await dBContext.SaveChangesAsync();
                }
                catch (DBConcurrencyException)
                {
                    if (!dBContext.Expenses.Any(x => x.Id == Expense.Id))
                    {
                        return NotFound();
                    }
                    else 
                    { 
                        throw; 
                    }
                }
            }

            return RedirectToPage("Expenses");
        }
    }
}
