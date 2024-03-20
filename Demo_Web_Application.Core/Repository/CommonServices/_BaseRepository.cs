using Demo_Web_Application.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo_Web_Application.Core.Helper;
using Demo_Web_Application.Core.Repository;

namespace Demo_Web_Application.Core.Repository
{
    public class BaseRepository<T> where T : class
    {

        public IEnumerable<T> GetAllRecords()
        {
            using (var context = new Demo_DBEntities())
            {
                return context.Set<T>().ToList();
            }
        }


        public long Insert(T obj)
        {
            using (var context = new Demo_DBEntities())
            {
                try
                {

                    dynamic entity = obj;
                    context.Set<T>().Add(entity);
                    context.SaveChanges();
                    return entity.StudentId;


                }
                catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                {
                    Exception raise = dbEx;
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            string message = string.Format("{0}:{1}", validationErrors.Entry.Entity.ToString(), validationError.ErrorMessage);
                            raise = new InvalidOperationException(message, raise);
                        }
                    }
                    throw raise;
                }
            }
        }

        public void Update(T entity)
        {
  
            using (var context = new Demo_DBEntities())
            {
                try
                {
                    context.Set<T>().Attach(entity);
                    context.Entry(entity).State = EntityState.Modified;

                    var excluded = new[] { "IsActive", "CreatedBy", "CreatedDate" };
                    var entry = context.Entry(entity);
                    foreach (var name in excluded)
                    {
                        entry.Property(name).IsModified = false;
                    }


                    context.SaveChanges();
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                {
                    Exception raise = dbEx;
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            string message = string.Format("{0}:{1}",
                                validationErrors.Entry.Entity.ToString(),
                                validationError.ErrorMessage);
                            // raise a new exception nesting  
                            // the current instance as InnerException  
                            raise = new InvalidOperationException(message, raise);
                        }
                    }
                    throw raise;
                }
            }
        }

        public bool Delete(int id)
        {
            using (var context = new Demo_DBEntities())
            {
                var dbResult = context.Set<T>().Find(id);

                if (dbResult != null)
                {
                    context.Set<T>().Remove(dbResult);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
        }


        public T GetDetailById(int id)
        {
            using (var context = new Demo_DBEntities())
            {
                var dbResult = context.Set<T>().Find(id);
                return dbResult;
            }
        }

        public T GetDetailById(long id)
        {
            using (var context = new Demo_DBEntities())
            {
                var dbResult = context.Set<T>().Find(id);
                return dbResult;
            }
        }

        public T GetDetailByOrderId(long? id)
        {
            using (var context = new Demo_DBEntities())
            {
                var dbResult = context.Set<T>().Find(id);
                return dbResult;
            }
        }
        
        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}
