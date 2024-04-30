using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ADVprogramming_ass2.Model;

namespace ADVprogramming_ass2.Pages
{
    public class IndexModel : PageModel
    {
        public string egg { get; set; }

        


        public void OnGet()
        {
            egg = "egg";
        }
    }
}