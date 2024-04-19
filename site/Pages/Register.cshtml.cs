using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using site.Data;
using site.Data.Models;
using System.Web;
namespace site.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly Context _context;

        public RegisterModel (Context context)
        {
            _context = context;
            
        }

        public void OnGet()
        {
        }
        
        public async Task<IActionResult> OnPostAsync()
        {
            _context.Users.Add(User);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
            
        }

        [BindProperty]
        public User User { get; set; } = default!;
        public void AddResponse(User user) 
        {
            Console.WriteLine(user.Name);
        }
    }
}
