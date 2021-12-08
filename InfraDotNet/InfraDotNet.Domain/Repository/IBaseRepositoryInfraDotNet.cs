using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InfraDotNet.Domain.Repositories
{
    public interface IBaseRepositoryInfraDotNet<TEntity,TPrimaryKey> 
        where TEntity : class
        where TPrimaryKey : IComparable<TPrimaryKey>
    {
        #region CREATE
        Task<TEntity> CreateAsync(TEntity model);
        TEntity Create(TEntity model);
        #endregion

        #region UPDATE
        Task<TEntity> UpdateAsync(TEntity model);
        TEntity Update(TEntity model);
        #endregion

        #region DELETE
        Task<TEntity> DeleteAsync(TEntity model);
        TEntity Delete(TEntity model);
        #endregion

        #region READ 
        Task<TEntity?> FindByIdAsync(TPrimaryKey primaryKey);
        TEntity? FindById(TPrimaryKey primaryKey);
        Task<IEnumerable<TEntity>> FindAllAsync();
        IEnumerable<TEntity> FindAll(TPrimaryKey primaryKey);
        IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> expression);
        #endregion

        #region SAVE
        void SaveChanges();
        Task SaveChangesAsync();
        #endregion


    }
}
