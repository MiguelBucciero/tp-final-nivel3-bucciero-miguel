# Base local y base del hosting

La web lee la cadena de conexión `CatalogoDB` de `TPFinalNivel3BuccieroMiguel\connectionStrings.config`
(`<connectionStrings configSource=...>` en `Web.config`). Ese archivo no se sube a git y existe en dos lugares:

| Dónde | Archivo | Base |
|---|---|---|
| PC | `connectionStrings.config` | `.\SQLEXPRESS` / `CATALOGO2025` (Windows) |
| Hosting | `wwwroot\connectionStrings.config` | `db71080` (usuario y contraseña SQL) |

Si falta el local (por ejemplo, después de clonar), el primer build lo crea copiando `connectionStrings.example.config`.

## Cadena de conexión del hosting (una sola vez)
1. Abrí `TPFinalNivel3BuccieroMiguel\connectionStrings.hosting.config` y reemplazá `ESCRIBI_TU_USUARIO` y
   `ESCRIBI_TU_CONTRASEÑA` por el usuario y la contraseña de la base `db71080` (panel > *Databases*).
2. Subilo a la raíz del sitio (`wwwroot`, donde queda `Web.config`) **con el nombre `connectionStrings.config`**,
   por el *File Manager* del panel o por FTP.
3. Tu `connectionStrings.config` local no se toca. Ninguno de los dos se sube a git.

## Publicar desde Visual Studio
- `connectionStrings.config` y `connectionStrings.hosting.config` no están incluidos en el proyecto, así que
  Web Deploy no los sube y no pisa el del servidor.
- En el perfil de publicación dejá tildado **no borrar archivos adicionales en el destino**
  (`SkipExtraFilesOnServer`), para que el `connectionStrings.config` del hosting no se borre al publicar.

## Restaurar la base
- PC: la base `CATALOGO2025` sale del backup de Somee (`CATALOGO2025_autobackup_..._2026-09-30.BAK`).
- Hosting: se cargó con `C:\Backups\CATALOGO2025_hosting.sql` (tablas + datos) ejecutado sobre `db71080`.
