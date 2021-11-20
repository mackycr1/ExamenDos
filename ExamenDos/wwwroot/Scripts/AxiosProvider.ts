
namespace App.AxiosProvider   {

    //export const GuardarEmpleado = () => axios.get<Entity.DBEntity>("aplicacion").then(({data})=>data );
    export const ProductoEliminar = (id) => axios.delete<DBEntity>("Producto/Grid?handler=Delete&id=" + id).then(({ data }) => data);
    export const OrdenEliminar = (id) => axios.delete<DBEntity>("Orden/Grid?handler=Delete&id=" + id).then(({ data }) => data);
}
