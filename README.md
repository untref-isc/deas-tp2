# deas-tp2
Diseño y Evolución de Arquitecturas de Software - TP2

instalar SDK Net Core 8 descargando el instalador desde https://aka.ms/dotnet/download
verificar si se intaló correctamente ejecutando en consola 
dotnet --list-sdks
En la lista debe figurar "8.0.403 [C:\PROGRAM FILES\DOTNET\sdk]" o version posterior

instalar Herramientas:
dotnet add package Microsoft.EntityFrameworkCore.Tools 
Ejecutar el comando para que genere las tablas: Update-Database -StartUpProject App -Project Repository -Context ApplicationContext
si falla, parados en .\deas-tp2\scanner el siguiente comando
 dotnet ef Database Update --startup-project App --project Repository --context ApplicationContext

Este comando se usa para crear nuevas migrations frentea cambios en el modelo de bases de datos:
Add-Migration <Migrationname> -StartUpProject App -Project Repository -Context ApplicationContext

El nombre de cada migration, debe ser único. 
Cada nueva entidad que se agrege al modelo, debe sumarse también a la clase ApplicationContext como una nueva property:
 public DbSet<NewEntity> NewEntity { get; set; }
