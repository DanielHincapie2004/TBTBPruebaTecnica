# TBTBPruebaTecnica

## Descripción
En este repositorio encontrará la solución a la prueba técnica propuesta. La solución incluye los queries y los proyectos necesarios para cumplir con los requisitos planteados.

## Contenido del Repositorio
- **Queries**: Archivos SQL con las consultas necesarias.
  - `creacionDataBase.sql`
  - `instruccionesDataBase.sql`
  - `Diagrama ER.png`

- **Proyectos**: Código fuente de los proyectos desarrollados para la solución.
  - `TBTBGlobal_PruebaTecnicaAPI`
 
Inicialmente, en la carpeta donde deseamos tener el repositorio, debemos abrir una terminal y ejecutar el siguiente comando:

```bash
git clone https://github.com/DanielHincapie2004/TBTBPruebaTecnica.git
```
     
## Parte I: Base de datos
Para validar la solución a esta primera fase, deberás entrar en la carpeta [Querys](https://github.com/DanielHincapie2004/TBTBPruebaTecnica/tree/main/Querys) del proyecto, donde encontrarás los archivos que resuelven los puntos solicitados. Inicialmente, recomiendo hacer uso de <b>SQL Server Management Studio (SSMS)</b> para ejecutar los queries en el siguiente orden:

1. creacionDataBase.sql <br>
   Este archivo contiene la creación de la base de datos y las tablas con sus respectivas conexiones, y adicionalmente realiza los INSERT solicitados a cada una de las tablas.
2. instruccionesDataBase.sql <br>
   Este archivo contiene el manejo de los datos previamente insertados, haciendo uso de las diferentes sentencias solicitadas. Como adición, se incluyen la creación de los procedimientos almacenados (SPS) con las funciones del CRUD.
3. Diagrama ER.png <br>
   Con esta imagen se representa el diagrama ER de la base de datos creada previamente.

## Parte II: Interfaz de Programación de Aplicación (API)
La solución a esta parte de la prueba se encuentra en la carpeta [TBTBGlobal_PruebaTecnicaAPI](https://github.com/DanielHincapie2004/TBTBPruebaTecnica/tree/main/TBTBGlobal_PruebaTecnicaAPI). Allí se encuentra el proyecto desarrollado en ASP.NET versión 6.

Una vez abras el código de la API en tu IDE de preferencia, debes entrar en el archivo <b>appsettings.json</b> y encontrarás el siguiente fragmento de código:
```bash
 "ConnectionStrings": {
  "CadenaSQL": "Server=[Servidor de mi maquina]; DataBase=PRUEBA_TECNICA_TBTB; Trusted_Connection=True; TrustServerCertificate=True;"
 }
```
En la parte donde se indica <b>[Servidor de mi máquina]</b>, debes reemplazarlo por el nombre del servidor que encuentras en tu <b>SQL Server Management Studio (SSMS)</b>.

Posteriormente, podrás ejecutar el proyecto y probar los diferentes endpoints de la siguiente manera:

### GetAll 
- https://localhost:7249/api/User/getAll <br>
 Este endpoint listará todos los usuarios que tengas en la base de datos.
### GetById
- https://localhost:7249/api/User/getById/(userId) <br>
 Este endpoint listará solo un usuario según el ID que envíes como parte de la ruta.
### InsertUser
- https://localhost:7249/api/User/insert <br>
  Este endpoint creará registros en la base de datos. Necesitarás enviar información por medio del body para poder ejecutarlo. Debes enviar un JSON similar a este:
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
 Este endpoint se encarga de la edición de usuarios. Al igual que el endpoint de creación, necesitarás datos en formato JSON en el body de la siguiente manera:
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
 Este endpoint, similar al GetById, deberá recibir por medio de la ruta el ID del usuario que deseas eliminar.

## Parte III: Aplicación Web
La solución a esta parte de la prueba se encuentra en la carpeta [TBTBGlobal_PruebaTecnicaFront](https://github.com/DanielHincapie2004/TBTBPruebaTecnica/tree/main/TBTBGlobal_PruebaTecnicaFront). Allí se encuentra el proyecto desarrollado en Angular 16.0.0. Para ejecutar el proyecto localmente, debes ejecutar el siguiente comando en la ruta donde tienes instalado el código de la aplicación:

```bash
 npm install
```
Una vez se genere la carpeta <b> node_modules </b>, podrás ejecutar el comando para iniciar el proyecto:
```bash
 ng serve
```
En la aplicación encontrarás un listado de usuarios provenientes del endpoint proporcionado. Adicionalmente, cuenta con filtros por nombre, ciudad y correo. Si haces clic en alguno de los usuarios, podrás ver de manera más detallada la información.

Esta ha sido mi propuesta para dar solución a la prueba técnica enviada. Quedo atento al feedback de la misma. Muchas gracias por la oportunidad. <br><br>
Daniel Hincapie Ramirez
