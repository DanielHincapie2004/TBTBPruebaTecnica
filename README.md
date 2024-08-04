# TBTBPruebaTecnica 

## Descripción
En este repositorio, encontrará la solución a la prueba técnica propuesta. La solución incluye los queries y los proyectos necesarios para cumplir con los requisitos planteados.

## Contenido del Repositorio
- Querys: Archivos SQL con las consultas necesarias.
  - creacionDataBase.sql
  - instruccionesDataBase.sql
  - Diagrama ER.png

- Proyectos: Código fuente de los proyectos desarrollados para la solución.
   - TBTBGlobal_PruebaTecnicaAPI
 
Inicialmente en la carpeta donde deseamos tener el repositorio debemos abrir una teminar y ejecutar el siguiente comando 

```bash
  git clone https://github.com/DanielHincapie2004/Prueba-Tecnica.git
```
     
## Parte I: Base de datos
Para validar la solucion a esta primera fase deberas entrar a la carpeta [Querys](https://github.com/DanielHincapie2004/Prueba-Tecnica/tree/main/Querys) del proyecto, en donde encontraras los archivos en donde se resulelven los puntos solicitados, inicialmente recomiedo hacer uso de <b>SQL Server Management Studio (SSMS) </b> para ejecutar los querys en el siguiente orden: 

1. creacionDataBase.sql <br>
   Este archivo contiene la creacion de la base de datos y las tablas con sus respectivas conexiones, y adicionalmente hace los INSERT solicitados a cada una de las tablas 
2. instruccionesDataBase.sql <br>
   Este archivo contiene el manejo de los datos previamente insertados, haciendo uso de las diferentes sentencias solicitadas. Como adición, se incluye la creación de los procedimientos almacenados (SPS) con las funciones del CRUD.
3. Diagrama ER.png <br>
   Con esta imagen se representa el diagramaER de la base de datos creada previamente

## Parte II: Interfaz de Programación de Aplicación (API)
La solucion a esta parte de la prueba la encontraremos en la carpeta [TBTBGlobal_PruebaTecnicaAPI](https://github.com/DanielHincapie2004/Prueba-Tecnica/tree/main/TBTBGlobal_PruebaTecnicaAPI), alli se encuentra el proyecto desarrollado en ASP.NET version 6.

Una vez se abra el codigo de la API en nuesto IDE de preferencia debemos entrar en el archivo <b>appsettings.json </b> alli encontraremos el sigueinte fragemnto de codigo:
```bash
 "ConnectionStrings": {
  "CadenaSQL": "Server=[Servidor de mi maquina]; DataBase=PRUEBA_TECNICA_TBTB; Trusted_Connection=True; TrustServerCertificate=True;"
 }
```
y en la parte donde nos indica <b> [Servidor de mi maquina]</b> debemos reemplazarlo por el server name que encontramos en nuestro <b>SQL Server Management Studio (SSMS) </b>

Posteriormente podremos ejecutar el proyecto y probar los diferentes Endpoint que se solicitaron de la sigueinte manera 

### GetAll 
- https://localhost:7249/api/User/getAll <br>
 Este endpoint nos listara todos los usuarios que tengamos en la base de datos
### GetById
- https://localhost:7249/api/User/getById/(userId) <br>
 Este endpoint nos listara solo un usuario segun el Id que le enviemos como parte de la ruta
### InsertUser
- https://localhost:7249/api/User/insert <br>
  Este endpoint nos creara registros en la base de datos, este necesitara informacion por medio del body para poder ejecutarse, se le debe enviar un JSON similar a este:
  ```code
   {
      "name": "Prueba",
      "email": "prueba@gmail.com",
      "rol": {
        "id": 1
      }
   }
  ```
### UpdateUser
- https://localhost:7249/api/User/update <br>
 Este endpoint es el encargado de la edicion de usuarios igual que el endpoint de crear tambien necesitara datos en formato JSON por el body de la siguiente manera
```code
   {
      "id": 1,
      "name": "cambioUsuario",
      "email": "cambioUsuario@gmail.com",
      "status": true,
      "rol": {
         "id": 4
      }
   }
```
### DeleteUser
- https://localhost:7249/api/User/delete/(userId) <br>
  Este endpoint similar al getById, se le debera enviar por medio de la ruta el id del usuario que se desea eliminar
