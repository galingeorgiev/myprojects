namespace PhoneBook
{
    using System;
    using System.Collections.Generic;
    using Wintellect.PowerCollections;

    public class PhoneBook
    {
        private MultiDictionary<string, Person> phoneBook = new MultiDictionary<string, Person>(true);
        private MultiDictionary<string, Person> phoneBookTown = new MultiDictionary<string, Person>(true);

        public void Add(Person person)
        {
            this.phoneBook.Add(person.Name, person);
            this.phoneBookTown.Add(person.Town, person);
        }

        public void Find(string name)
        {
            ICollection<Person> results = new List<Person>();
            results = this.phoneBook[name];

            foreach (var person in results)
            {
                Console.WriteLine(person);
            }
        }

        public void Find(string name, string town)
        {
            ICollection<Person> results = new List<Person>();
            results = this.phoneBook[name];

            ICollection<Person> resultsByTown = new List<Person>();
            resultsByTown = this.phoneBookTown[town];

            HashSet<Person> uniqueResults = new HashSet<Person>(results);
            uniqueResults.IntersectWith(resultsByTown);

            foreach (var person in uniqueResults)
            {
                Console.WriteLine(person);
            }
        }
    }
}
