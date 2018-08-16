using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Catalog.Core;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class TeamsController : Controller
    {
        DataService dataService { get; set; }
        public TeamsController(DataService ds) {
            dataService = ds;
        }
        public IActionResult Index() {
            var model = dataService.Teams;
            return View(model);
        }

        public IActionResult People() {
            
            var model = dataService.People;
            return View(model);
        }

        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult TeamDetails(string team) {
            var model = dataService.getPeopleInTeam(team);
            return View("~/Views/Teams/People.cshtml", model);
            //var ds = new DataService();
            //ds.People= dataService.getPeopleInTeam(team);
            //ds.Teams = new List<Team> { new Team() { Name=team} };
            //return View(ds);
        }

        public IActionResult AddPerson(string team, Person pers) {
            var model = dataService.getPeopleInTeam(team);
            dataService.addPersonToTeam(team, pers);
            
            return View("~/Views/Teams/People.cshtml", model);
            //var ds = new DataService();
            //ds.People= dataService.getPeopleInTeam(team);
            //ds.Teams = new List<Team> { new Team() { Name=team} };
            //return View(ds);
        }
    }
}
