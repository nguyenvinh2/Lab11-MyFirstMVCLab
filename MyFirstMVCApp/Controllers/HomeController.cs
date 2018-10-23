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
    /// <summary>
    /// listens for user input, redirects to result to process inputs
    /// </summary>
    /// <param name="beginningYear">year search range parameter</param>
    /// <param name="endingYear">year search range parameter</param>
    /// <returns></returns>
    [HttpPost]
    public IActionResult Index(int beginningYear, int endingYear)
    {
      Console.WriteLine(beginningYear);
      Console.WriteLine(endingYear);
      return RedirectToAction("Result", new { beginningYear, endingYear });
    }
    /// <summary>
    /// Landing Page, see index.cshtml
    /// </summary>
    /// <returns>the view of index.cshtml</returns>
    [HttpGet]
    public ViewResult Index()
    {
      return View();
    }
    /// <summary>
    /// queries model for all Persons that fall within year range, puts those data
    /// in table
    /// </summary>
    /// <param name="beginningYear">year search range parameter</param>
    /// <param name="endingYear">year search range parameter</param>
    /// <returns>webpage with all matched Persons in table format</returns>
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
