using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using site.Data;
using site.Data.Models;
using System.Web;
namespace site.Pages
{
    public class MessagerModel : PageModel
    {
        public readonly Context _context;

        public MessagerModel(Context context)
        {
            _context = context;
            
        }

        public void OnGet()
        {
        }
        
        public async Task<IActionResult> OnPostAsync()
        {
           // newmsg.date= DateTime.Now;
            _context.Message.Add(newmsg);
             
             await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
            
        }

        [BindProperty]
        public msg newmsg { get; set; } = default!;
        
    }
}
