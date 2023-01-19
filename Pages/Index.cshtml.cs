// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Mvc.RazorPages;

// namespace myWebApp.Pages;

// public class IndexModel : PageModel
// {
//     private readonly ILogger<IndexModel> _logger;

//     public IndexModel(ILogger<IndexModel> logger)
//     {
//         _logger = logger;
//     }

//     public void OnGet()
//     {

//     }
// }
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using myWebApp.Models;

namespace myWebApp.Pages;

public class IndexModel : PageModel
    {
        public Student[] StudentName { get; private set; }=new Student[]{new Student{FirstMidName="a",LastName="b",ID=1}};
        private readonly ILogger<IndexModel> _logger;
        private readonly myWebApp.Data.SchoolContext _context;

        public IndexModel(ILogger<IndexModel> logger, myWebApp.Data.SchoolContext context)
        {
            _logger = logger;
            _context= context;
        }

        public void OnGet()
        {
           // var s =_context.Students.ToArray();
            this.StudentName = _context.Students.ToArray<Student>();
        }
    }