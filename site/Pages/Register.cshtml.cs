using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using site.Data.Models;
using System.Web;
namespace site.Pages
{
    public class Index1Model : PageModel
    {
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            return RedirectToPage("./Rgister");
        }

        [BindProperty]
        public User User { get; set; }
        public void AddResponse(User user) 
        {
            Console.WriteLine(user.Name);
        }
    }
}
