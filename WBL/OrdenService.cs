using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BD;
using Entity;

namespace WBL
{
    public interface IOrdenService
    {
        Task<DBEntity> Insert(OrdenEntity entity);
        Task<DBEntity> Update(OrdenEntity entity);
        Task<DBEntity> Delete(OrdenEntity entity);
        Task<IEnumerable<OrdenEntity>> Get();
        Task<OrdenEntity> GetById(OrdenEntity entity);
    }

    public class OrdenService : IOrdenService
    {
        private readonly IDataAccess sql;

        public OrdenService(IDataAccess sql)
        {
            this.sql = sql;
        }

        public async Task<IEnumerable<OrdenEntity>> Get()
        {
            try
            {
                var result = sql.QueryAsync<OrdenEntity, ProductoEntity>("OrdenObtener", "IdOrden, IdProducto");
                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<OrdenEntity> GetById(OrdenEntity entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<OrdenEntity>("OrdenObtener", new { entity.IdOrden });
                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DBEntity> Insert(OrdenEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("OrdenInsertar", new
                {
                    entity.IdProducto,
                    entity.CantidadProducto,
                    entity.Estado
                });
                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DBEntity> Update(OrdenEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("OrdenActualizar", new
                {
                    entity.IdOrden,
                    entity.IdProducto,
                    entity.CantidadProducto,
                    entity.Estado
                    
                });
                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DBEntity> Delete(OrdenEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("OrdenEliminar", new { entity.IdOrden });
                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
