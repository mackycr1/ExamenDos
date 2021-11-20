"use strict";
var App;
(function (App) {
    var AxiosProvider;
    (function (AxiosProvider) {
        //export const GuardarEmpleado = () => axios.get<Entity.DBEntity>("aplicacion").then(({data})=>data );
        AxiosProvider.ProductoEliminar = function (id) { return axios.delete("Producto/Grid?handler=Delete&id=" + id).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
        AxiosProvider.OrdenEliminar = function (id) { return axios.delete("Orden/Grid?handler=Delete&id=" + id).then(function (_a) {
            var data = _a.data;
            return data;
        }); };
    })(AxiosProvider = App.AxiosProvider || (App.AxiosProvider = {}));
})(App || (App = {}));
//# sourceMappingURL=AxiosProvider.js.map