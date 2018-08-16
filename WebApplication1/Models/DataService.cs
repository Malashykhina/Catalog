using System;
using System.Collections.Generic;
using System.Linq;

namespace Catalog.Core
{
    public class DataService
    {
        public DataService()
        {
            var eagles = new Team { Name = "Eagles" };
            var bears = new Team { Name = "Bears" };

            Teams = new List<Team>
            {
                eagles,
                bears
            };

            People = new List<Person>
            {
                new Person { Name = "John" },
                new Person { Name = "Joe" },
                new Person { Name = "Ed", Team = eagles },
                new Person { Name = "Merphy", Team = bears },
                new Person { Name = "Met", Team = bears },
            };
        }

        public IEnumerable<Team> Teams { get; set; }
        public IEnumerable<Person> People { get; set; }

        public IEnumerable<Person> getPeopleInTeam (string team){
            var peopleTeam = People.Where
                (item => (item.Team != null) && item.Team.Name.Equals(team)).ToList();
            return peopleTeam;
        }

        public void addPersonToTeam(string team, Person person) {
            foreach (var pers in People) {
                if (pers.Equals(person))
                    pers.Team.Name = team;
            }
        }
    }
}
