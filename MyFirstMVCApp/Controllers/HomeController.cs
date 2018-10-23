using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyFirstMVCApp.Models;


namespace MyFirstMVCApp.Controllers
{
  public class HomeController : Controller
  {
    [HttpPost]
    public IActionResult Index(int beginningYear, int endingYear)
    {
      Console.WriteLine(beginningYear);
      Console.WriteLine(endingYear);
      return RedirectToAction("Result", new { beginningYear, endingYear });
    }

    [HttpGet]
    public ViewResult Index()
    {
      return View();
    }

    public ViewResult Result( int beginningYear, int endingYear)
    {
      List<Person> TimeofYearPerson = Person.CSVPeople();
      var SelectedPerson = (from result in TimeofYearPerson
                            where result.Year > beginningYear && result.Year < endingYear
                            select result).ToList<Person>();

      return View(SelectedPerson);
    }
  }

}
