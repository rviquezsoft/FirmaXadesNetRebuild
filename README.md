# FirmaXadesNetReBuild - Versión adaptada para .NET 5/6/7/8

Este repositorio contiene una **versión modificada** de la librería original [FirmaXadesNet](https://github.com/ctt-gob-es/FirmaXadesNet), desarrollada por el Dpto. de Nuevas Tecnologías de la Concejalía de Urbanismo del Ayuntamiento de Cartagena, la cual está basada en una modificación del XAdES starter kit desarrollado por Microsoft Francia.

La versión original estaba diseñada exclusivamente para **.NET Framework**, lo que impedía su uso en proyectos modernos basados en **.NET Core o .NET 5+**. Esta versión ha sido **adaptada y actualizada para ser compatible con .NET 5, .NET 6, .NET 7 y .NET 8**, manteniendo la funcionalidad original de firma XAdES.

## Objetivos de esta adaptación

- Compatibilidad con **.NET moderno** (.NET 5+)
- Migración de APIs obsoletas 
- Correcciones menores para mejorar la portabilidad y mantenimiento
- Asegurar compatibilidad con proyectos multiplataforma (Windows, Linux)

## Características principales

- Generación de firmas XAdES-BES
- Soporte para múltiples referencias en la firma
- Inclusión de propiedades de firma avanzadas (SigningTime, SigningCertificate, etc.)
- Soporte para firma de documentos XML

## Cambios clave respecto al proyecto original

- Eliminación de dependencias exclusivas de .NET Framework
- Uso de APIs compatibles con .NET moderno
- Validación de compatibilidad hasta .NET 8

## Licencias

Este proyecto está licenciado bajo la **MIT License**, la cual permite la redistribución y modificación del código bajo las condiciones detalladas en el archivo `LICENSE`.

### Dependencia: Microsoft XAdES .NET Starter Kit

Este proyecto utiliza la librería `Microsoft.Xades` (parte del **XAdES .NET Starter Kit**), originalmente desarrollado por **Microsoft France**, para la firma de documentos XAdES. La librería original está licenciada bajo la **CeCILL-B License**.

**Condiciones:**
- La librería `Microsoft.Xades` se utiliza.
- Al redistribuir el código o las modificaciones, se debe incluir el aviso de derechos de autor y la licencia CeCILL-B.
- El software se distribuye "tal cual", sin garantías.

La licencia completa de la **CeCILL-B** se puede encontrar en el archivo `LICENSE_CeCILL-B.txt`.

## Licencia de la Librería (CeCILL-B)

La librería `Microsoft.Xades` está licenciada bajo la **CeCILL-B**. Puedes consultar el texto completo de la licencia en el archivo `LICENSE_CeCILL-B.txt`, o en el siguiente enlace: [Licencia CeCILL-B](http://www.cecill.info/).

## Cómo contribuir

1. Realiza un fork de este repositorio.
2. Crea una nueva rama para tu funcionalidad o corrección.
3. Realiza los cambios y haz commit.
4. Abre un pull request con una descripción detallada de los cambios realizados.

## Agradecimientos

Agradecemos al Dpto. de Nuevas Tecnologías de la Concejalía de Urbanismo del Ayuntamiento de Cartagena por su contribución al proyecto original, así como a Microsoft France por el XAdES Starter Kit, base de esta librería.
