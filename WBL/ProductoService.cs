using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BD;
using Entity;

namespace WBL
{
    public interface IProductoService
    {
        Task<DBEntity> Insert(ProductoEntity entity);
        Task<DBEntity> Update(ProductoEntity entity);
        Task<DBEntity> Delete(ProductoEntity entity);
        Task<IEnumerable<ProductoEntity>> Get();
        Task<ProductoEntity> GetById(ProductoEntity entity);
    }

    public class ProductoService : IProductoService
    {
        private readonly IDataAccess sql;

        public ProductoService(IDataAccess sql)
        {
            this.sql = sql;
        }

        public async Task<IEnumerable<ProductoEntity>> Get()
        {
            try
            {
                var result = sql.QueryAsync<ProductoEntity>("ProductoObtener");
                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ProductoEntity> GetById(ProductoEntity entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<ProductoEntity>("ProductoObtener", new { entity.IdProducto });
                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DBEntity> Insert(ProductoEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("ProductoInsertar", new
                {
                    entity.NombreProducto,
                    entity.PrecioProducto
                });
                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DBEntity> Update(ProductoEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("ProductoActualizar", new
                {
                    entity.IdProducto,
                    entity.NombreProducto,
                    entity.PrecioProducto
                });
                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DBEntity> Delete(ProductoEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("ProductoEliminar", new { entity.IdProducto });
                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
