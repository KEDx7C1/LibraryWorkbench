﻿using LibraryWorkbench.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryWorkbench.Data.Intefaces
{
    public interface IAuthorsRepository : IDisposable
    {
        public IEnumerable<Author> GetAll();
        public Author Get(int id);
        public void Create(Author author);
        public void Update(Author author);
        public void Delete(int id);
        public void Save();
    }
}