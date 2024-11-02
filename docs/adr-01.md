# Architecture Decision Record para Predicción de Duración de Tarea

Decision Date: 2024-10-31

Status: Accepted

## Context

Con el propósito de cumplir con el atributo de usabilidad debemos ofrecer al usuario una retroalimentación cuando ejecute la tarea de escaneo de archivos en busca de virus.
Generamos distintos escenarios para explicitar las entradas necesarias para realizar la estimación del tiempo restante para finalizar la tarea.

## Decision

Un módulo de predicción se encargará de registrar las duraciones de los pasos de la tarea y estimar el tiempo restante de la tarea en base a tiempos históricos:
Para realizar una primera estimación cuando no se cuentan con valores históricos, se hace un escaneo de los 10 primeros archivos, se promedia su tiempo de procesamiento y se multiplica por la cantidad de archivos a analizar.
La primera ejecución de la tarea, cuando no existen valores históricos para realizar una estimación, se procede a realizar el registro del tiempo de procesamiento de cada archivo. Se guarda el tamaño del archivo y el tiempo que tardó en lo que denominamos *Zocalo*. Si se procesa otro archivo con el mismo tamaño, actualiza en la base de datos la cantidad de archivos de *Zocalo* y se actualiza el promedio de ejecución.
Las corridas futuras realizarán la estimación de duración de escaneo de archivos según los tamaños de archivos a escanear y sus coincidencias con los zócalos en la base de datos.

El módulo de presentación se conectará con la interfaz de usuario para mostrar el progreso y el tiempo restante aproximado.	

## Factors

La estimación de esta forma nos dará mayor precisión en el tiempo definido porque será sensible a la actividad del Sistema, al llevar un registro detallado del procesamiento de cada paso (análisis de un documento) dentro de la tarea (escaneo de documentos).

## Alternatives Considered

Contemplamos censar el procesamiento de un archivo y realizar una multiplicación fija por la cantidad de archivos que restan por ser procesados.

## Consequences

La adopción del enfoque elegido tiene las siguientes consecuencias:

1. Implementación de las Clases: 
Zocalo

2. Persistencia en la Base de Datos de
ResultadoEjecucion

3. Implementación de los Servicios
EscaneadorService
EstimadorDuracionService

## Conclusion
Basándonos en los factores que fueron considerados, decidimos estimar la duración de la tarea de análisis de archivos según el tiempo necesario para procesar un archivo. El tiempo de estimación se va actualizando adecuadamente según los tamaños de los archivos y el estado del Sistema.


ADR Template: https://github.com/joelparkerhenderson/architecture-decision-record/blob/main/locales/en/examples/python-django-framework/index.md
