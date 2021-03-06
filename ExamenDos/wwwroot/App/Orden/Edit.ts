namespace OrdenEdit {

    var Entity = $("#AppEdit").data('entity');

    var Formulario = new Vue(
        {
            data:
            {
                Formulario: "#FormEdit",
                Entity: Entity
            },
            methods:
            {
                Save() {
                    if (BValidateData(this.Formulario)) {
                        Loading.fire("Guardando");
                        App.AxiosProvider.OrdenGuardar(this.Entity).then(data => {
                            Loading.close();

                            /*If no error exist*/
                            if (data.CodeError == 0) {

                                /*Message indicating the file was successfully deleted*/
                                Toast.fire({ title: "Registro almaceno exitosamente!", icon: "success" }).then(() => window.location.href = "Orden/Grid")
                            }
                            else {
                                Toast.fire({ title: data.MsgError, icon: "error" })
                            }
                        })
                    }
                    else {
                        Toast.fire({ title: "Todos los campos son requeridos" });
                    }
                }
            },
            mounted() {
                CreateValidator(this.Formulario)
            }
        }
    );

    Formulario.$mount("#AppEdit")
}