# Diseño y Evolución de Arquitecturas de Software

## Trabajo Práctico 2

Escenario elegido: Predicción de duración de tarea
La problemática consiste en lanzar una tarea que sea repetitiva (es decir, que se ha realizado en oportunidades anteriores) y producir un indicador de duración estimada de la tarea que sea visible para el usuario.

Criterios de aceptación
La duración estimada debe actualizarse a medida que transcurre el tiempo y se avanza la tarea.
La duración estimada puede calcularse en base a datos históricos locales de ejecución de la tarea.
En el escenario de ejecución en el que no se cuenta con datos históricos, esto debe comunicarse en forma transparente al usuario.


Simulación de tarea: Scan de virus archivos del disco local

## Diseño


```mermaid

classDiagram
    class LectoraArchivos {
        +void AnadirObservador(IObservador observador)
        +void NotificarObservadores(int progreso)
        +void EjecutarComando(IComando comando)
        +Duracion EstimarDuracion(Archivo archivo)
    }

    class IComando {
        +void Ejecutar()
    }

    class ComandoLeerArchivo {
        +Archivo archivo
        +LectoraArchivos lector
        +EstimadorDuracion estimador
        +void Ejecutar()
    }

    class IObservador {
        +void Actualizar(int progreso)
    }

    class UI {
        +void Actualizar(int progreso)
    }

    class Logger {
        +void Actualizar(int progreso)
    }

    class EstimadorDuracion {
        +Dictionary~Archivo, Duracion~ historial
        +void RegistrarDuracion(Archivo archivo, Duracion duracion)
        +Duracion ObtenerDuracionEstimada(Archivo archivo)
    }

    class Duracion {
        +int segundos
        +int ConvertirAMinutos()
        +int ConvertirAHoras()
    }

    LectoraArchivos --> IObservador : notifica
    LectoraArchivos --> IComando : ejecuta
    ComandoLeerArchivo --> EstimadorDuracion : consulta
    EstimadorDuracion --> Archivo : almacena duracion
    ComandoLeerArchivo --> Duracion : usa
    IObservador <|-- UI
    IObservador <|-- Logger
    IComando <|-- ComandoLeerArchivo

```

## ADR 

Directorio docs/ 


## Ejecución del proyecto

Instalar SDK Net Core 8 descargando el instalador desde https://aka.ms/dotnet/download
verificar si se intaló correctamente ejecutando en consola 
dotnet --list-sdks
En la lista debe figurar "8.0.403 [C:\PROGRAM FILES\DOTNET\sdk]" o version posterior

Instalar Herramientas:
dotnet add package Microsoft.EntityFrameworkCore.Tools 
Desde el directorio Scanner, ejecutar el comando siguiente para que genere la base de datos:
 dotnet ef Database Update --startup-project App --project Repository --context ApplicationContext

Para poder correr la aplicación, desde el mismo directorio,ejecutar el siguiente commmando:
     dotnet run <Directorioa_a_Escanear> --project App

Directorioa_a_Escanear debe contener la ruta completa del directorio que será escaneado por la applicacion en windows, 
ej: c:\prueba-untref.
