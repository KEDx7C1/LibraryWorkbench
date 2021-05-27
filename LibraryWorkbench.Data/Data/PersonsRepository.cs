using LibraryWorkbench.Data.Intefaces;
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
    public class PersonsRepository : IPersonsRepository
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
            Person person = _context.Persons.Include(b => b.Books).ThenInclude(a => a.Genres)
                .Include(x => x.Books).ThenInclude(a => a.Author).FirstOrDefault(x => x.PersonId == id);
            if (person == null)
                throw new Exception($"Person with Id {id} not found");
            _context.Persons.Remove(person);
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
