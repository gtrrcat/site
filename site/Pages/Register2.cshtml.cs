using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using site.Data;
using site.Data.Models;
using System.Web;
namespace site.Pages
{
    public class Register2Model : PageModel
    {
        private readonly Context _context;

        public Register2Model (Context context)
        {
            _context = context;
            
        }

        public void OnGet()
        {
        }
        
        public async Task<IActionResult> OnPostAsync()
        {
            _context.dvoiki.Add(newdva);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
            
        }

        [BindProperty]
        public dva newdva { get; set; } = default!;
        
    }
}
