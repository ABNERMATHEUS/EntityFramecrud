using InfraDotNet.Domain.Entity;
using InfraDotNet.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InfraDotNet.Infra.Repository
{
    public abstract class BaseRepositoryInfraDotNet<TEntity, TPrimaryKey> : IBaseRepositoryInfraDotNet<TEntity, TPrimaryKey>
        where TEntity : class
        where TPrimaryKey : IComparable<TPrimaryKey>
    {
        protected readonly DbContext _dbContext;

        protected BaseRepositoryInfraDotNet(DbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        #region CREATE
        public virtual TEntity Create(TEntity model)
        {
            _dbContext.Set<TEntity>().Add(model);
            AddTimestamps(model);
            SaveChanges();
            return model;
        }

        public async virtual Task<TEntity> CreateAsync(TEntity model)
        {
            await _dbContext.Set<TEntity>().AddAsync(model);
            AddTimestamps(model);
            await SaveChangesAsync();
            return model;
        }

        #endregion

        #region READ
        public virtual IEnumerable<TEntity> FindAll(TPrimaryKey primaryKey)
        {
            return _dbContext.Set<TEntity>().ToList();
        }

        public async virtual Task<IEnumerable<TEntity>> FindAllAsync()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }


        public virtual TEntity? FindById(TPrimaryKey primaryKey)
        {
            return _dbContext.Set<TEntity>().Find(primaryKey);
        }

        public async virtual Task<TEntity?> FindByIdAsync(TPrimaryKey primaryKey)
        {
            return await _dbContext.Set<TEntity>().FindAsync(primaryKey);
        }

        public virtual IQueryable<TEntity> Filter(Expression<Func<TEntity,bool>> expression)
        {
            return _dbContext.Set<TEntity>().Where(expression);
        }

        #endregion

        #region UPDATE
        public virtual TEntity Update(TEntity model)
        {            
            _dbContext.Set<TEntity>().Update(model);
            AddTimestamps(model);
            SaveChanges();
            return model;
        }

        public async virtual Task<TEntity> UpdateAsync(TEntity model)
        {

            _dbContext.Set<TEntity>().Update(model);    
            AddTimestamps(model);
            await SaveChangesAsync();
            return model;
        }
        #endregion

        #region DELETE
        public virtual TEntity Delete(TEntity model)
        {
            _dbContext.Remove(model);
            SaveChanges();
            return model;
        }

        public async virtual Task<TEntity> DeleteAsync(TEntity model)
        {
            _dbContext.Remove(model);
            await SaveChangesAsync();
            return model;
        }

        #endregion

        #region SAVE
        public virtual void SaveChanges()
        {
           _dbContext.SaveChanges();
        }

        public async virtual Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
        #endregion

        private void AddTimestamps(TEntity model)
        {
            var entities = _dbContext.ChangeTracker
                            .Entries()
                            .Where(x => x.Entity is BaseEntityInfraDotNet<TPrimaryKey> && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                var now = DateTime.UtcNow;

                if (entity.State == EntityState.Added)
                {
                    ((BaseEntityInfraDotNet<TPrimaryKey>)entity.Entity).CreatedAt = now;
                    ((BaseEntityInfraDotNet<TPrimaryKey>)entity.Entity).UpdatedAt = null;
                }
                else if(entity.State == EntityState.Modified)
                {
                    ((BaseEntityInfraDotNet<TPrimaryKey>)entity.Entity).UpdatedAt = now;
                    _dbContext.Entry(model).Property("CreatedAt").IsModified = false;
                }                
            }
        }

    }
}
