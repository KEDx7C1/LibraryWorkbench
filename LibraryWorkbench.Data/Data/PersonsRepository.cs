using LibraryWorkbench.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryWorkbench.Data
{
    /// <summary>
    /// Hometask 2 6
    /// </summary>
    public class PersonsRepository : IRepository<Person>
    {
        private readonly DataContext _context;

        public PersonsRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Person> GetAll()
        {
            return _context.Persons.Include(b => b.Books);
        }
        public Person Get(int id)
        {
            return _context.Persons.Include(b => b.Books).ThenInclude(a => a.Genres)
                .Include(x => x.Books).ThenInclude(a => a.Author).Where(x => x.PersonId == id).First();
        }
        public void Create(Person person)
        {
            person.CreationDateTime = DateTimeOffset.Now;
            person.UpdationDateTime = person.CreationDateTime;
            person.Version = 1;
            _context.Persons.Add(person);
        }
        public void Update(Person person)
        {
            person.UpdationDateTime = DateTimeOffset.Now;
            person.Version++;
            _context.Entry(person).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            Person person = _context.Persons.Find(id);
            if (person != null)
                _context.Persons.Remove(person);
            else
                throw new ArgumentException();
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
