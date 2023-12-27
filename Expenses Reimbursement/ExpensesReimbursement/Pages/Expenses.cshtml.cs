using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExpensesReimbursement.Pages
{
    public class ExpensesModel : PageModel
    {
        private readonly ExpensesDBContext _dbContext;
        public IEnumerable<Expense> Expenses = Enumerable.Empty<Expense>();

        public ExpensesModel(ExpensesDBContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [BindProperty]
        public Expense NewExpense { get; set; }

        public void OnGet()
        {
            this.Expenses = this._dbContext.Expenses.OrderByDescending(x => x.Date).ToArray();
        }

        public IActionResult OnPost() 
        {
            this._dbContext.Expenses.Add(NewExpense);
            this._dbContext.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}
