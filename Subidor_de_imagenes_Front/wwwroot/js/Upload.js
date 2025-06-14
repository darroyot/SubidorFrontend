$(document).ready(function () {

    $("#file-1").on("change", function (ev) {

        imagenseleccionada = ev.target.files[0];
        nombreImagen = ev.target.files[0].name;
        var reader = new FileReader();
        $("#foto").val(nombreImagen);
        reader.addEventListener("load", (evt) => {
            //el contenido del fichero de imagen  esta en :evt.target.result
            //Lo cargo en el tag <img usando el atributo  src;
            $("#imagenusuario").attr("src", evt.target.result);
            $("#imagenusuario").css("display", "block")
            $("#sube").attr("style", "visibility:visible"); ///-->visibilizamos el boton de subir
            //$("#anidarfoto").text("Cambiar");
            $("#sube").on("click", subirImagenServidor);
            //                                    ----->apuntamos a la funcion(que esta arriba)
        });
        reader.readAsDataURL(imagenseleccionada);


    })

    function subirImagenServidor() {
        ///peticion AJAX para mandar multipart/form-data al servidor con fichero imagen
        var datosAenviar = new FormData();
        datosAenviar.append("Photo", imagenseleccionada);

        $.ajax({
            url: "/Subidor/SubidaImagensync",
            type: "POST",
            data: datosAenviar,
            contentType: false,
            processData: false,
            success: function () {
                $("#foto").attr("value", nombreImagen);
                $("#sube").attr("style", "visibility:invisible");
                Swal.fire({
                    title: "Foto Subida correctamente",
                    text: "Sube",
                    icon: "success"
                });
                location.reload()
            },
            error: function () {
                Swal.fire({
                    icon: "error",
                    title: "Oops...",
                    text: "FALLA",

                });

            }
        });

    }

})