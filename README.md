# 🥷 Codechallenge [![dotnet](https://img.shields.io/badge/dotnet-7.0-purple)](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)

Realizar un microservicio en `.net 7` usando el lenguaje de programación `C#` con las siguientes indicaciones:

## 🗺️ **(2 puntos)**  Generar un un controlador que permita realizar un `CRUD` sobre la entidad `Country`, tendrá los siguientes campos:

- name
- alpha2Code
- alpha3Code
- capital
- region
- nativeName

## 🚩 **(2 puntos)** Generar un controlador que consuma el api pública: https://restcountries.com y contenga

_(En caso de que la url del api esté en mantenimiento o no responda, puedes realizar los apartados que la requieran usando otro api publica pero intentado cumplir los mismos objetivos de la pregunta en otro controlador)_

- _(0.5)_  GET que permita consultar todos los países.
- _(0.5)_ GET que permita consultar un país por nombre.
- _(1)_ GET que permita recuperar una cadena de texto base64 de la bandera (flag) svg de un país concreto.

## 🌍 **(2 puntos)** Agregar un POST al controlador del apartado anterior que permita transferir la información de un país (Country) del api al modelo del microservicio para almacenarlo.

## ✨ **(4 puntos)** Se valorará
- _(1)_ 💾 Sistema de persistencia de datos.
- _(1)_ 📖 La documentación del microservicio (swagger/openapi).
-  _(1)_ 👁️ Un sistema de log y test que permite ver el flujo del microservicio y testearlo.
- _(1)_ 📚  Cualquier dependencia o concepto que ayude a la solución del ejercicio, limpieza del código, patrones, estilo de desarrollo y buenas prácticas.

## 📨 **ENTREGA**

- 📁 Se debe entregar el código fuente con los apartados resueltos en el repositorio
- 🆙 Puedes crear una rama o subirlos a master directamente dentro de `src`
- ⏱️ El tiempo de desarrollo es de una semana pero mucho mejor si nos lo puedes
enviar antes. 

## ✅ Se tendra en cuenta

- 🌐 Url con la aplicación desplegada
    - puedes usar alternativas gratuitas como https://www.back4app.com 
    - un ejemplo de app documentada https://petstore.swagger.io
- 📚 Colección postman con una prueba para cada controlador definido.
    - https://www.postman.com
    -  https://learn.microsoft.com/es-es/power-apps/developer/data-platform/webapi/use-postman-perform-operations

## ⚠️ **RECUERDA**

-  🥷 La evaluación la realizarán nuestros ninja masters
    - cualquier cosa que les facilite la corrección es bienvenida
    - evita los mensajes de error, warnings y comentarios que no sean utiles
- 📜 Según tu calificación, recibirás un diploma de ninja.

## 💡 **CONSEJOS**

- No autogeneres el código con herramientas, puedes buscar y copiar fragmentos de código que te sean utiles, pero siempre entendiendo la lógica de lo que haces
- La persistencia de datos es mejor hacerla en memoria, recuerda que el corrector no tiene tu cadena de conexion de la bd
    - https://learn.microsoft.com/es-es/ef/core/providers/in-memory
- La app deberia poder cargarse en el IDE (nosotros probramos en Visual Studio 2022) y ejecutarla directamente sin tener que modificar nada del código
- Utiliza git de forma correcta, no subas un fichero comprimido
    - https://git-scm.com/docs/gittutorial
    - https://ohshitgit.com


 ## 👋 !Cualquier cosa no dudes en consultarnos!





