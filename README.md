# VERI*FACTU - Generación de Huellas o Hash de Registros de Facturación

## Descripción

Este proyecto es una implementación en C# del sistema **VERI*FACTU** basado en las especificaciones técnicas proporcionadas por la Agencia Estatal de Administración Tributaria (AEAT). La herramienta genera una huella o "hash" para los registros de facturación de acuerdo con el formato y requisitos especificados en el documento de la AEAT (versión 0.1.2).

https://www.agenciatributaria.es/static_files/AEAT_Desarrolladores/EEDD/IVA/VERI-FACTU/Veri-Factu_especificaciones_huella_hash_registros.pdf

## Funcionalidades

- Generación de huellas de los registros de facturación mediante el algoritmo **SHA-256**.
- Procesamiento de registros de alta, anulación y eventos en el Sistema Informático de Facturación (SIF).
- Salida en formato hexadecimal y en mayúsculas con una longitud de 64 caracteres.
- Validación de huellas en conformidad con las especificaciones de AEAT para asegurar el cumplimiento con los requisitos de facturación.

## Especificaciones Técnicas

- **Algoritmo Hash**: SHA-256.
- **Formato de Salida**: Hexadecimal en mayúsculas.
- **Longitud de Huella**: 64 caracteres alfanuméricos.
- **Lenguaje de Implementación**: C#.

## Contribuciones
Este es un proyecto de código abierto. Se agradecen contribuciones mediante pull requests, así como la apertura de issues para reportar errores o sugerir mejoras.
