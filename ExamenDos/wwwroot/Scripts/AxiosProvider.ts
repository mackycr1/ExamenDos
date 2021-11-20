
namespace App.AxiosProvider   {

    //export const GuardarEmpleado = () => axios.get<Entity.DBEntity>("aplicacion").then(({data})=>data );

    /*Producto*/
    export const ProductoEliminar = (id) => axios.delete<DBEntity>("Producto/Grid?handler=Delete&id=" + id).then(({ data }) => data);
    export const ProductoGuardar = (entity) => axios.post<DBEntity>("Producto/Edit", entity).then(({ data }) => data);

    /*Orden*/
    export const OrdenEliminar = (id) => axios.delete<DBEntity>("Orden/Grid?handler=Delete&id=" + id).then(({ data }) => data);
    export const OrdenGuardar = (entity) => axios.post<DBEntity>("Orden/Edit", entity).then(({ data }) => data);
}
