﻿using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repo.IRepo;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repo
{
    internal class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly AppDbContext _db;
        internal DbSet<T> _dbset;
        public GenericRepo(AppDbContext appDbContext)
        {
            _db = appDbContext;
            this._dbset = _db.Set<T>(); //this.dbset == _db.Categories 
        }
        public void Add(T entity)
        {
            _dbset.Add(entity);
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = _dbset;
            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = _dbset;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            _dbset.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbset.RemoveRange(entities);
        }
    }
}
