# FirmaXadesNet - Versión adaptada para .NET 5/6/7/8

Este repositorio contiene una **versión modificada** de la librería original [FirmaXadesNet](https://github.com/ctt-gob-es/FirmaXadesNet), desarrollada por el Centro de Transferencia de Tecnología del Gobierno de España.

La versión original estaba diseñada exclusivamente para **.NET Framework**, lo que impedía su uso en proyectos modernos basados en **.NET Core o .NET 5+**. Esta versión ha sido **adaptada y actualizada para ser compatible con .NET 5, .NET 6, .NET 7 y .NET 8**, manteniendo la funcionalidad original de firma XAdES.

## Objetivos de esta adaptación

- Compatibilidad con **.NET moderno** (.NET 5+)
- Migración de APIs obsoletas de .NET Framework
- Correcciones menores para mejorar la portabilidad y mantenimiento
- Asegurar compatibilidad con proyectos multiplataforma (Windows, Linux)

## Características principales

- Generación de firmas XAdES-BES
- Soporte para múltiples referencias en la firma
- Inclusión de propiedades de firma avanzadas (SigningTime, SigningCertificate, etc.)
- Soporte para firma de documentos XML

## Cambios clave respecto al proyecto original

- Proyecto migrado a **SDK-style projects** (`.csproj`)
- Eliminación de dependencias exclusivas de .NET Framework
- Uso de APIs compatibles con .NET moderno
- Validación de compatibilidad hasta .NET 8
