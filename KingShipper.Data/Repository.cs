﻿using KingShipper.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.Entity;
using System.Linq.Expressions;
using KingShipper.Library;

namespace KingShipper.Data
{
    public class Repository<T> where T : class
    {

        internal KingShipperContext Context;
        internal DbSet<T> DbSet; 

        public Repository(KingShipperContext context)
        {
            Context = context;
            DbSet = Context.Set<T>();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return DbSet.AsEnumerable();
        }
        public virtual IEnumerable<T> FindAll(Expression<Func<T, bool>> expression)
        {
            return DbSet.Where(expression);
        }

        public virtual IEnumerable<T> ExecuteSqlCommand(string command, params object[] parameters)
        {
            return DbSet.SqlQuery(command, parameters);
        }

        public virtual IEnumerable<T> GetPagination(Expression<Func<T, bool>> expression, out int totalItem, int currentPage = 0, int pageSize = 50)
        {
            throw new NotImplementedException();
        }

        public virtual bool Contains(Expression<Func<T, bool>> expression)
        {
            return DbSet.Count(expression) > 0;
        }

        public virtual T Find(Expression<Func<T, bool>> expression)
        {
            return DbSet.FirstOrDefault(expression);
        }

        public virtual T Add(T entity)
        {
            DbSet.Add(entity);
            Context.SaveChanges();
            return entity;
        }

        public virtual bool Delete(T entity)
        {
            try
            {
                var entry = Context.Entry(entity);
                entry.State = EntityState.Deleted;
                Context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);
                return false;
            }
        }

        public virtual T Update(T entity)
        {
            try
            {
                var entry = Context.Entry(entity);
                DbSet.Attach(entity);
                entry.State = EntityState.Modified;
                Context.SaveChanges();
                return entity;
            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);
                return null;
            }
        }

        public virtual int Count(Expression<Func<T, bool>> expression)
        {
            return DbSet.Count(expression);
        }


    }
}
