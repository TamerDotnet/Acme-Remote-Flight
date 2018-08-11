using AcmeRemoteFilghts.CoreLayer.Data;
using AcmeRemoteFilghts.DataLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace ExamDesigner.Data
{
    public partial class EfRepository<T> : IRepository<T> where T : BaseEntity
    {
        #region Fields

        private readonly AcmeDbContext _context;
        private DbSet<T> _entities; 

        #endregion

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="context">Object context</param>
        public EfRepository(AcmeDbContext context)
        {
            this._context = context;
        }

       
        public virtual T GetById(object id )
        {
            //return Entities.Find(id);
            return Entities.AsNoTracking().SingleOrDefault(x => x.Id == (int)id);
        }
        public IEnumerable<T> QueryObjectGraph(Expression<Func<T, bool>> filter, string children)
        {
            if(children=="")
                return Entities.Where(filter);
            else
                return Entities.Include(children).Where(filter);
        }
        public virtual void Insert(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));

                Entities.Add(entity);

                _context.SaveChanges();
            }
            catch (InvalidOperationException dbEx)
            {
                //ensure that the detailed error text is saved in the Log
                throw new Exception(dbEx.Message);
            }
        }
        public virtual void Insert(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException(nameof(entities));

                foreach (var entity in entities)
                    Entities.Add(entity);

                _context.SaveChanges();
            }
            catch (InvalidOperationException dbEx)
            {
                throw new Exception(dbEx.Message);
            }
        } 
        public virtual void Update(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));

                _context.Update(entity);
                //_context.Entry(entity).State = EntityState.Detached;

                //_context.Entry(entity).State = EntityState.Modified;

               _context.SaveChanges();
            }
            catch (InvalidOperationException dbEx)
            {
                throw new Exception(dbEx.Message);
            }
        }
        private static Object UpdateForType(Type type,  Object source, Object destination)
        {
            FieldInfo[] myObjectFields = type.GetFields(
                BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

            foreach (FieldInfo fi in myObjectFields)
            {
                fi.SetValue(destination, fi.GetValue(source));
            }
            return destination;
        }
        public virtual void Update(Type type,int Id, T newEntity)
        {
            var oldEntity = Entities.Find(Id);
            Entities.Attach(oldEntity);
            while (type != null)
            {
                 UpdateForType(type,newEntity, oldEntity  );
                type = type.BaseType;
            }
            _context.SaveChanges();
        }

        /// <summary>
        /// Update entities
        /// </summary>
        /// <param name="entities">Entities</param>
        public virtual void Update(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException(nameof(entities));

                _context.SaveChanges();
            }
            catch (InvalidOperationException dbEx)
            {
                throw new Exception(dbEx.Message);
            }
        }

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public virtual void Delete(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));

                Entities.Remove(entity);

                _context.SaveChanges();
            }
            catch (InvalidOperationException dbEx)
            {
                throw new Exception(dbEx.Message);
            }
        }

        /// <summary>
        /// Delete entities
        /// </summary>
        /// <param name="entities">Entities</param>
        public virtual void Delete(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException(nameof(entities));

                foreach (var entity in entities)
                    Entities.Remove(entity);

                _context.SaveChanges();
            }
            catch (InvalidOperationException dbEx)
            {
                throw new Exception(dbEx.Message);
            }
        }

        public bool Exists(int Id)
        {
          var obj = Entities.Find(Id);
            if (obj == null)
                return false;

            return true;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets a table
        /// </summary>
        public virtual IQueryable<T> Table
        {
            get
            {
                return Entities;
            }
        }

        /// <summary>
        /// Gets a table with "no tracking" enabled (EF feature) Use it only when you load record(s) only for read-only operations
        /// </summary>
        public virtual IQueryable<T> TableNoTracking
        {
            get
            {
                return Entities.AsNoTracking();
            }
        }

        /// <summary>
        /// Entities
        /// </summary>
        protected virtual DbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = _context.Set<T>();
                return _entities;
            }
        }

       
        #endregion
    }

}
