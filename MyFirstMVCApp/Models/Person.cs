using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace MyFirstMVCApp.Models
{
  public class Person
  {
    /// <summary>
    /// creates Person object with required properties
    /// set by CSV
    /// </summary>
    public int Year { get; set; }
    public string Honor { get; set; }
    public string Name { get; set; }
    public string Country { get; set; }
    public int BirthYear { get; set; }
    public int DeathYear { get; set; }
    public string Title { get; set; }
    public string Category { get; set; }
    public string Context { get; set; }

    /// <summary>
    /// takes values from the CSV file and puts in it an object
    /// </summary>
    /// <param name="CSVLine">each CSV Line read by streamreader</param>
    /// <returns>Person Object</returns>
    public static Person CSVConvert(string CSVLine)
    {
      string[] line = CSVLine.Split(',');
      Person CreatePerson = new Person();
      CreatePerson.Year = (int)Convert.ToInt16(line[0]);
      CreatePerson.Honor = (string)line[1];
      CreatePerson.Name = (string)line[2];
      CreatePerson.Country = (string)line[3];
      CreatePerson.BirthYear = (line[4] == "") ? 0 : Convert.ToInt16(line[4]);
      CreatePerson.DeathYear = (line[5] == "") ? 0 : Convert.ToInt16(line[5]);
      CreatePerson.Title = (string)line[6];
      CreatePerson.Category = (string)line[7];
      CreatePerson.Context = (string)line[8];
      return CreatePerson;
    }
    /// <summary>
    /// reads the CSV files, converts it into object and adds it to a list
    /// </summary>
    /// <returns>List of time persons</returns>
    public static List<Person> CSVPeople()
    {
      List<Person> TimePerson = File.ReadAllLines("Resources/personOfTheYear.csv")
                                              .Skip(1)
                                              .Select(CSVLine => CSVConvert(CSVLine))
                                              .ToList();
      return TimePerson;
    }
  }
}
