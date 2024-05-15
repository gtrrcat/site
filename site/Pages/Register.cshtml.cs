using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using site.Data;
using site.Data.Models;
using System.Security.Cryptography;
using System.Text;
using System.Web;
namespace site.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly Context _context;
        private readonly IConfiguration _configuration;

        public RegisterModel (Context context,IConfiguration configuration)

        {
            _configuration = configuration;
            _context = context;
            
        }

        public void OnGet()
        {
        }
        private const string Key = "EiLCTduaYVxyrjVfw8Kbmw=="; // Здесь укажите ваш ключ шифрования
        private const string IV = "0123456789abcdef"; // Инициализирующий вектор

        public string Encrypt(string plainText)
        {
            using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(_configuration["Crypting:Key"]);
                aesAlg.IV = Encoding.UTF8.GetBytes(_configuration["Crypting:IV"]);

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                    }
                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }
        public string Decrypt(string cipherText)
        {
            using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(Key);
                aesAlg.IV = Encoding.UTF8.GetBytes(IV);

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(cipherText)))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }
        public async Task<IActionResult> OnPostAsync()
        {
            newUser.Password = Encrypt(newUser.Password);
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
            
        }

        [BindProperty]
        public User newUser { get; set; } = default!;
        public void AddResponse(User user) 
        {
            Console.WriteLine(user.Name);
        }
    }
}
