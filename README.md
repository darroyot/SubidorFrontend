Hay 2 proyectos uno en la rama main y el otro en la rama master.

Empezamos con el backend en la rama main,lo descargamos ,si esta en zip lo descomprimimos y lo abrimos con visual studio. vamos a appsetting.json y establecemos la cadena de conexión si no se quisiera utilizar o funcionara la que viene por defecto

Abrimos la consola de paquetes Nugets e introducimos los siguientes comandos uno a uno para crear las migraciones.

add-migration "nueva" Update-Database

Para descargar el Frontend nos vamos a la rama master ,lo descargamos desde ahí ,descomprimimos y abrimos.

Ejecutamos ambos proyectos ,en la vista pulsamos cargar elegimos una foto,se nos habilita el botón subir ,lo pulsamos y se subirá a la base de datos siempre y cuando no supere los 2 megas y sea en png. Esperamos unos segundos A continuación se nos mostrará el nombre de la foto en la cuadricula que aparece debajo del botón.

Si pulsamos eliminar, se eliminará la foto de la base de datos y si pulsamos descargar se nos descargará directamente.

Toda acción que hagamos será registrada en la base de datos en la tabla record.	
