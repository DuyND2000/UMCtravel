
using UMCTravelTour.Common.Constants;
using UMCTravelTour.ViewModel.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UMCTravelTour.DAL.Infrastructures
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// return all records
        /// </summary>
        /// <param name="isDeleted"></param>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Return an entity has primary key match in keyValues paramter(s).
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        TEntity GetById(params object[] keyValues);

        /// <summary>
        /// Return an entity has primary key match in keyValues paramter(s).
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        Task<TEntity> GetByIdAsync(params object[] keyValues);

        /// <summary>
        /// return all records
        /// </summary>
        /// <param name="isDeleted"></param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAllAsync();

        /// <summary>
        /// Add an entity into DbContext, this mean to change the state of entity to added.
        /// </summary>
        /// <param name="entity"></param>
        void Add(TEntity entity);

        /// <summary>
        /// Add an entity into DbContext, this mean to change the state of entity to added.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task AddAsync(TEntity entity);

        /// <summary>
        /// Add a list of entities into DbContext, this mean to change state of entities to added.
        /// Call SaveChanges() method to save data into the database
        /// </summary>
        /// <param name="entities"></param>
        void AddRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Add a list of entities into DbContext, this mean to change state of entities to added.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task AddRangeAsync(IEnumerable<TEntity> entities);

        /// <summary>
        /// Change state of entity to Modified. 
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        void Update(TEntity entity);

        /// <summary>
        /// Change state of entity to Deleted. 
        /// </summary>
        void Delete(params object[] keyValues);

        /// <summary>
        ///Change state of entity to Deleted. 
        /// </summary>
        void Delete(TEntity entity);

        /// <summary>
        ///Change state of entity to Deleted. 
        /// </summary>
        void DeleteByCondition(Func<TEntity, bool> condition);

        /// <summary>
        /// 
        /// </summary>

        Task DeleteAsync(params object[] keyValues);

        /// <summary>
        /// Change state of entity to Deleted. 
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        Task DeleteByConditionAsync(Func<TEntity, bool> condition);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        IEnumerable<TEntity> Find(Func<TEntity, bool> condition);


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        int Count();

        Task<int> CountAsync();

        PagedVm<TEntity> GetPaging(string softBy = null, Func<TEntity, bool> filter = null, Func<IEnumerable<TEntity>, IOrderedEnumerable<TEntity>> orderBy = null, int pageSize = Constant.PageSize, int pageIndex = 1);
    }

}