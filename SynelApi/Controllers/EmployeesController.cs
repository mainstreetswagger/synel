using AutoMapper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Mvc;
using SynelApi.CsvConverters;
using SynelApi.Db;
using SynelApi.Dtos;
using SynelApi.Entities;
using SynelApi.Interfaces;
using SynelApi.Models;
using System.Diagnostics;
using System.Globalization;
using System.Text.RegularExpressions;

namespace SynelApi.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly SynelDbContext _synelDb;
        private readonly IMapper _mapper;
        private readonly ICSVService _csv;
        private readonly ILogger<EmployeesController> _logger;
        public EmployeesController(SynelDbContext synelDb, IMapper mapper, ICSVService csv, ILogger<EmployeesController> logger)
        {
            _synelDb = synelDb;
            _mapper = mapper;
            _csv = csv;
            _logger = logger;
        }
        public IActionResult Index(int savedPeople = 0, int foundPeople = 0, string searchString = "")
        {
            var people = _synelDb.People.AsQueryable();
            if (!string.IsNullOrEmpty(searchString))
            {
                people = people.Where(p => p.PayrollNumber.Contains(searchString)
                || p.Surename.Contains(searchString)
                || p.Forename.Contains(searchString)
                || p.Telephone.Contains(searchString)
                || p.Mobile.Contains(searchString)
                || p.Address.Contains(searchString)
                || p.Address2.Contains(searchString)
                || p.Postcode.Contains(searchString)
                || p.EmailHome.Contains(searchString));
            }
            people = people.OrderBy(p => p.Surename);
            var peopleData = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeData>>(people);
            ViewData["saved"] = savedPeople;
            ViewData["found"] = foundPeople;
            return View(peopleData);
        }
        [HttpPost]
        [Route("people/create")]
        public async Task<IActionResult> CreatePeople([FromForm] IFormFile file)
        {
            int savedPeople = 0;
            int foundPeople = 0;
            if (file is not null)
            {
                var peopleCsvData = _csv.ReadCSV<EmployeeData, EmployeeCsvCoverter>(file.OpenReadStream());
                var people = _mapper.Map<IEnumerable<EmployeeData>, IEnumerable<Employee>>(peopleCsvData);
                foreach (var person in people)
                {
                    if (_synelDb.People.Any(p => p.PayrollNumber == person.PayrollNumber))
                    {
                        foundPeople++;
                    }
                    else
                    {
                        _synelDb.People.Add(person);
                    }
                }
                savedPeople = await _synelDb.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index), new { savedPeople = savedPeople, foundPeople = foundPeople });
        }
        [HttpGet]
        [Route("people/edit")]
        public IActionResult Edit(string payroll = "")
        {
            if (string.IsNullOrEmpty(payroll))
            {
                return RedirectToAction(nameof(Index));
            }
            var person = _synelDb.People.FirstOrDefault(p => p.PayrollNumber == payroll);
            if (person == null)
            {
                return NotFound("Person not found.");
            }
            var personData = _mapper.Map<Employee, EmployeeData>(person);
            return View(personData);
        }
        [HttpPost]
        [Route("people/edit")]
        public IActionResult Edit(EmployeeData personData)
        {
            if (personData == null)
            {
                return NoContent();
            }
            var person = _mapper.Map<EmployeeData, Employee>(personData);
            _synelDb.People.Update(person);
            _synelDb.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
