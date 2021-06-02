using LibraryWorkbench.Data.Intefaces;
using LibraryWorkbench.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace LibraryWorkbench.Data
{
    /// <summary>
    /// Hometask 2 6
    /// </summary>
    public class PersonsRepository : IPersonsRepository
    {
        private readonly DataContext _context;
        public PersonsRepository(DataContext context)
        {
            _context = context;
        }
        public IQueryable<Person> GetAll()
        {
            return _context.Persons.Include(b => b.Books);
        }
        public Person Get(int id)
        {
            Person person = _context.Persons.Include(b => b.Books).ThenInclude(a => a.Genres)
                .Include(x => x.Books).ThenInclude(a => a.Author).FirstOrDefault(x => x.PersonId == id);
            if (person == null)
                throw new Exception($"Person with Id {id} not found");
            return person;
        }
        public Person GetWithBooks(int id)
        {
            Person person = _context.Persons.Include(b => b.Books).FirstOrDefault(x => x.PersonId == id);
            if (person == null)
                throw new Exception($"Person with Id {id} not found");
            return person;
        }
        public Person Create(Person person)
        {
            person.CreationDateTime = DateTimeOffset.Now;
            person.UpdationDateTime = person.CreationDateTime;
            _context.Persons.Add(person);
            _context.SaveChanges();
            return person;
        }
        public Person Update(Person person)
        {
            person.UpdationDateTime = DateTimeOffset.Now;
            _context.Entry(person).State = EntityState.Modified;
            _context.SaveChanges();
            return person;
        }
        public void Delete(int id)
        {
            Person person = _context.Persons.FirstOrDefault(x => x.PersonId == id);
            if (person == null)
                throw new Exception($"Person with Id {id} not found");
            _context.Persons.Remove(person);
            _context.SaveChanges();
        }
    }
}
