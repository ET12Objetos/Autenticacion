# Aplicacion

- Crear proyecto con el comando:

```
dotnet new webapi -o Aplicacion
```

# Dependencias

- Instalar los siguientes paquetes nuget:
    - Microsoft.EntityFrameworkCore
    - Microsoft.EntityFrameworkCore.Design
    - Microsoft.EntityFrameworkCore.Tools
    - Pomelo.EntityFrameworkCore.MySql

- Con los siguientes comandos:

```
dotnet add package Microsoft.EntityFrameworkCore
```

```
dotnet add package Microsoft.EntityFrameworkCore.Design
```

```
dotnet add package Microsoft.EntityFrameworkCore.Tools
```

```
dotnet add package Pomelo.EntityFrameworkCore.MySql
```

- Configurar **ConnectionStrings** en el archivo **appsettings.json**

```json
"ConnectionStrings": {
    "ITEM_DB" : "server=IP_SERVIDOR_MYSQL;database=NOMBRE_BD;user=USUARIO;password=CONTRASEÑA"
  }
```

Con la configuracion actual me queda:

```json
"ConnectionStrings": {
    "proyecto_db" : "Server=localhost;Database=proyectodb;User=root;Password=telesca1234"
  }
```

El archivo **appsettings.json** queda:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "proyecto_db" : "Server=localhost;Database=proyectodb;User=root;Password=telesca1234"
  }
}
```

# Persistencia

## Contexto (DbContext)

- Crear un directorio con el nombre **Persistencia** dentro del proyecto **Aplicacion**
- Dentro del directorio **Persistencia** crear una clase con el nombre **ApllicacionDbContext**
- Escribir contenido del archivo **AplicacionDbContext.cs**:
  - Método constructor
  - Listas (tablas)

## Anotaciones (Data Annotations Attributes)

- Para cada una de la entidades del dominio **relevantes** agregar las anotaciones necesarias para explicitar el comportamiento del atributo en la base de datos.

Aqui es donde se explita que atributo sera **Primary Key**, **Foreign Key**, su tipo de dato especifico, nombre de la tabla, nombre de la columna (atributo), si es NULL, etc.  

- Aclaracion: **Warning cs8618** agregar en el archivo **Aplicacion.csproj** lo siguiente:

```xml
<NoWarn>8618</NoWarn>
```

Quedando:

```xml
<PropertyGroup>
  <TargetFramework>net6.0</TargetFramework>
  <Nullable>enable</Nullable>
  <ImplicitUsings>enable</ImplicitUsings>
  <NoWarn>8618</NoWarn>
</PropertyGroup>
```

## Configuración

- En el archivo **Program.cs** se debe indicar que nuestro contexto se debe asociar con la base de datos MySql para ello se debe colocar el siguiente codigo:

```c#
//obtengo el connectionString desde el archivo appsettings.json
//se debe indicar el nombre del item "proyecto_db"
var connectionString = builder.Configuration.GetConnectionString("proyecto_db");

//agrego la configuracion al nuestro contexto AplicacionDbContexto
builder.Services.AddDbContext<AplicacionDbContext>(opcion =>
    opcion.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 30))));

//agrego nuestro context AplicacionDbContext al contenedor de objetos
//con esto el objeto va a ser poder accedido desde cualquier otro objeto
//particularmente los controladores
builder.Services.AddDbContext<AplicacionDbContext>();
```

- Ademas tambien debemos crear la base de datos en MySql de forma explicita
```c#
//Por defecto, la accion de crear el objeto contexto no significa que se creara la base de datos 
//en MySql, por lo que lo debemos hacer manualmente

//creo un objeto de opciones de nuestro contexto
var opciones = new DbContextOptionsBuilder<AplicacionDbContext>();

//a las opciones creadas le asigno las credenciales para conectar la base de datos
opciones.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 30)));

//creo un objeto contexto con las opciones previamente definidas
var contexto = new AplicacionDbContext(opciones.Options);

//indico explicitamente que se debe crear nuestro contexto en el motor de base de datos
contexto.Database.EnsureCreated();
```

# Migraciones (Migrations)

- Para crear la base de datos en MySql se debe traducir desde nuestro contexto (C#) a SQL, para ello debemos realizar una migracion. Esto se debe realizar una unica vez al momento de crear la base de datos. 

```
dotnet ef migrations add NOMBRE_MIGRACION --context NOMBRE_CONTEXTO --output-dir DIRECTORIO_MIGRACIONES --project NOMBRE_PROYECTO --startup-project NOMBRE_PROYECTO_EJECUTABLE
```

Ejemplo:

```
dotnet ef migrations add MigracionInicial --context AplicacionDbContext --output-dir Persistencia/Migraciones --project Aplicacion --startup-project Aplicacion
```

- Cada vez que ingresemos un nuevo cambio en el contexto. Por ejemplo agregar un nuevo atributo a una entidad. Se debe realizar una nueva migracion con un nombre distinto a los existentes.

```
dotnet ef migrations add UnNuevoCambio --context AplicacionDbContext --output-dir Persistencia/Migraciones --project Aplicacion --startup-project Aplicacion
```

# Controladores (Controllers)

- De aqui en mas se debe codificar la logica de acceso a datos desde cada controllador.
- Se debe crear una clase controlador por cada entidad
- Por cada controlador debe haber al menos 5 endpoints con las siguientes acciones:
  - Ver Todo
  - Ver un elemento por Id
  - Crear un nuevo elemento
  - Editar un elemento existente por el Id
  - Eliminar un elemento existente por el Id

# Ejecución

Para poder ejecutar la apliacion de **WebApi** se debe realizar desde la terminal:

```
dotnet run --project Aplicacion
```