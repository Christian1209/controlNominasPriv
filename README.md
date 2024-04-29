~~Implementar en un futuro al actualizar/dar de alta que los datos que no pueden quedar vacios se remarquen en rojo al estar vacios y no tener el formato correcto y no permitir actualizar/dar de alta~~

~~Botones de actualizar y baja desactivados por default~~
~~Solo se desbloquean los crontroles si la opcion seleccionada es actualizar/baja y se encuentra el empleado en la base de datos.~~
~~Funcion para cambiar el formato de mes numerico a mes alf~~
~~Funcionalidad al boton Actualizar en progreso~~
~~Cambie la columna de sueldo_imss aumente el flotante a 50 digitos~~
~~el boton de baja se activa al encontrar empleado, no se puede editar la info en la ventana de bajas~~

~~en el formateo del mes cambie los valores de los numeros de 1 solo caracter, les agregue un 0~~
~~Cambio en el metodo para setear el index de la fecha,minutos,hora,año,mes y dia en los combo boxes, ahora no es necesario añadir un elemento nuevo al index para mostrarlo~~
~~notas: testear funcionamiento de actualizar~~

Correccion de error al buscar por nombre por primera vez

Enviar baja elimina al empleado de la tabla empleados y lo transfiere a la tabla bajas con todos sus datos;

el menu de bajas se actualiza despues de haberse enviado una baja (btnBajaEmpleado se desactiva hasta cargar otro empleado);

No importa si se modifica la clave por error, esta se guarda al cargar el empleado, no puede ser modificada y esta se usa para procesar la baja;

Implementada funcion para enviar correos enviarCorreo(string emailDestino, string asunto);

correo: procesadornominastest@gmail.com;
