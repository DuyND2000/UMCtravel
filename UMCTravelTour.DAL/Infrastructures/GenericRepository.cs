
using Microsoft.EntityFrameworkCore;
using UMCTravelTour.Common.Constants;
using UMCTravelTour.Core;
using UMCTravelTour.Core.Models;
using UMCTravelTour.DAL.Infrastructures;
using UMCTravelTour.ViewModel.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMCTravelTour.DAL.Infrastructures
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class

    {
        protected readonly UMCTravelContext Context;

        protected DbSet<TEntity> DbSet;

        public GenericRepository(UMCTravelContext context)
        {
            this.Context = context;
            this.DbSet = this.Context.Set<TEntity>();
        }

        public virtual void Add(TEntity entity)
        {
            this.DbSet.Add(entity);
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            await this.DbSet.AddAsync(entity);
        }

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            this.DbSet.AddRange(entities);
        }

        public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await this.DbSet.AddRangeAsync(entities);
        }

        public virtual int Count()
        {
            return this.DbSet.Count();
        }

        public virtual async Task<int> CountAsync()
        {
            return await this.DbSet.CountAsync();
        }

        public virtual void Delete(params object[] keyValues)
        {
            var entityExisting = this.DbSet.Find(keyValues);
            if (entityExisting != null)
            {
                this.DbSet.Remove(entityExisting);
            }
            else
            {
                throw new ArgumentNullException($"{string.Join(";", keyValues)} was not found in the {typeof(TEntity)}");
            }
        }

        public virtual void Delete(TEntity entity)
        {
            this.DbSet.Remove(entity);
        }

        public virtual async Task DeleteAsync(params object[] keyValues)
        {
            var entityExisting = await this.DbSet.FindAsync(keyValues);
            this.DbSet.Remove(entityExisting);
        }

        /// <summary>
        /// Delete all record with condition
        /// </summary>
        /// <param name="condition"></param>
        public virtual void DeleteByCondition(Func<TEntity, bool> condition)
        {
            var query = this.DbSet.Where(condition);
            foreach (var entity in query)
            {
                this.Delete(entity);
            }
        }

        public virtual async Task DeleteByConditionAsync(Func<TEntity, bool> condition)
        {
            var query = this.DbSet.Where(condition);
            foreach (var entity in query)
            {
                await this.DeleteAsync(entity);
            }
        }

        public IEnumerable<TEntity> Find(Func<TEntity, bool> condition)
        {
            return this.DbSet.Where(condition);
        }


        public virtual IEnumerable<TEntity> GetAll()
        {
            return this.DbSet.AsEnumerable();
        }


        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {

            return await this.DbSet.ToListAsync();
        }


        public TEntity GetById(params object[] keyValues)
        {
            return this.DbSet.Find(keyValues);
        }

        public virtual async Task<TEntity> GetByIdAsync(params object[] keyValues)
        {
            return await this.DbSet.FindAsync(keyValues);
        }

        public virtual PagedVm<TEntity> GetPaging(string softBy = null, Func<TEntity, bool> filter = null, Func<IEnumerable<TEntity>, IOrderedEnumerable<TEntity>> orderBy = null, int pageSize = Constant.PageSize, int pageIndex = 1)
        {
            IEnumerable<TEntity> data = DbSet.AsEnumerable();
            if (softBy == null)
            {
                data = DbSet.AsEnumerable();
            }
            if (filter != null)
            {
                data = data.Where(filter);
            }

            var totalRows = data.Count();
            var totalPages = (int)Math.Ceiling((double)totalRows / pageSize);
            if (orderBy != null)
            {
                data = orderBy(data);
            }
            data = data.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return new PagedVm<TEntity>(data, pageSize, pageIndex, totalPages);
        }
        public void Update(TEntity entity)
        {
            this.DbSet.Update(entity);
        }
    }
}
