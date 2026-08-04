# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## What this repo is

`facturacion.crom.sgfe.layers.sln` — the class-library "layers" for CROM, a multi-module ERP/back-office system (Seguridad/auth, Gestión Comercial, Almacén, Parqueo, Recursos Humanos, Asistencia, Proyectos, Importaciones, facturación electrónica, etc.). This repo builds the DLLs (Data Access, Business Logic, Business Entities); there is no web/API host project here — these assemblies are consumed by a separate front-end/service repo. Only two UI-ish projects exist locally: `CROM.Seguridad.Login` (WinForms login) and `CROM.TablasMaestras.Interface` (a WinForms maintenance form).

.NET Framework 4.6.2, C#, Visual Studio solution (not SDK-style csproj). All `.csproj` files use the legacy MSBuild format with strong-name signing (`.snk` per project) and NuGet `packages.config` (packages restored to `./packages`, not per-project `packages/`).

## Build

Open `facturacion.crom.sgfe.layers.sln` in Visual Studio 2022, or from a Developer Command Prompt / PowerShell with MSBuild on PATH:

```
nuget restore facturacion.crom.sgfe.layers.sln
msbuild facturacion.crom.sgfe.layers.sln /p:Configuration=Debug /p:Platform="Any CPU"
```

There is no `dotnet build` (legacy framework, non-SDK-style projects) and no CI workflow configured (`.github/` only holds `copilot-instructions.md`, no Actions). There are no test projects in the solution — validate changes by building and, where relevant, by tracing the call path manually (see below), since there is no automated test suite to run.

## Solution layout

Projects live under `CROM.Layers/<ProjectName>/` and are grouped in the `.sln` by numbered solution folders per business module (e.g. `01CROM.Seguridad`, `03CROM.TablasMaestras`, `05CROM.GestionAlmacen`, `06CROM.GestionComercial`, `09CROM.Asistencia`). Each module typically splits into two or three projects:

- **`<Module>.DataAcces`/`DataAccess`** — data access. Wraps a LINQ-to-SQL `DataContext` generated from a `.dbml` (e.g. `_DBMLSeguridadSistemaDataContext`, `_GestionComercial`, `_Almacen`) and calls SQL Server stored procedures exposed as typed methods on the context (`usp_sis_R_Auditoria_Paged`, `omgc_mnt_GetAll_Sistema`, etc.). Almost never raw SQL/LINQ-to-entities — the DB does the querying, C# just marshals rows into BE objects.
- **`<Module>.BussinesLogic`/`BusinessLogic`** — logic layer. Thin wrapper around the Data layer: validate/transform, call Data, and either return an `OperationResult` (see below) for the web-facing surface or an `IEnumerable<T>`/`List<T>` for internal callers.
- **`<Module>.Interface`** (some modules) — WinForms UI, or (for `CROM.ComercialAlmacen.Interfaces` / `CROM.GC.Services.Interfaces`) pure interface/contract + HTTP client stubs consumed by other systems.

Cross-cutting projects (used by nearly everything, live under `00CROM.Tools`, `02CROM.BussinesEntities`, `11CROM.Data`):

- **`CROM.Tools.Comun`** — the real "common" layer: `entities/` (`OperationResult`, `BaseLayer`, `ComboListItemString`, ...), `settings/GlobalSettings` (reads `ConfigurationManager.AppSettings`/connection strings), `security/`, `web/` (`WebConstants`, `HelperWeb` HTTP client wrapper), `helpers/` (`HelpLogging` via log4net, `HelpException`), `extensions/`, `attributes/` (e.g. `LetterCaseAttribute`), `utils/excel/`.
- **`CROM.Data`** — generic ADO.NET plumbing (`DataHelper` implementing `IDataHelper`): `ExecuteReader/Dataset/Scalar/NonQuery` against stored procs, reflection-based entity-to-`DbParameter` binding (`ExecuteEntity*`), `SqlHelperParameterCache`.
- **`CROM.BusinessEntities`** — shared DTOs/BE classes (`BEBase`, `BEBaseRequest`, `BEBaseResponse`) plus per-module subfolders (`SUNAT/`, `Comercial/`, `Almacen/`, `RecursosHumanos/`, ...). Individual modules also keep their own `BussinesEntities` project (e.g. `CROM.Seguridad.BussinesEntities`) for entities that don't need to be shared.
- **`CROM.Tools.Config`** (`CROM.Configuracion`) — app configuration entities backed by its own `.dbml` (`DBML_Config`).
- **`CROM.Tools.Crypto`**, **`CROM.Licencias.Tools`** — encryption and license-key/expiration handling.
- **`CROM.Tools.Windows`**, **`CROM.Tools.Web`** — WinForms and legacy WebForms UI helpers respectively.

## Core conventions (read before writing new Logic/Data code)

- **Layering is strict**: UI/consumer → `*.BussinesLogic` → `*.DataAcces` → stored procedure. Don't call a `DataAcces` class directly from outside its paired Logic class, and don't put SQL/query logic in the Logic layer — that belongs in the stored procedure, invoked via the DataContext.
- **`BaseLayer` (`CROM.Tools.Comun.entities`)**: web-facing Logic methods inherit `BaseLayer` and return `OperationResult` via `OK(data)` (serializes `data` to JSON into `OperationResult.data`) or `Error(className, methodName, ex, user, idEmpresa)` (logs via `HelpLogging` and returns a broken-rule with a generic user-facing message — the real exception never leaks to `OperationResult`). Follow the existing `try { ... return OK(x); } catch (Exception ex) { return Error(GetType().Name, MethodBase.GetCurrentMethod().Name, ex, "", ""); }` shape for new methods.
- **Multi-tenant by `codEmpresa`**: virtually every entity/request carries `codEmpresa` (and often `codEmpresaRUC`), and most `BEBase*` classes `[JsonIgnore]` it so it isn't trusted from client payloads — it's set server-side from the authenticated session/token, not from request bodies.
- **Paging convention**: paged list requests use `BEBuscadorBaseRequest`/`BEBuscadorBase` (`jqCurrentPage`, `jqPageSize`, `jqSortColumn`, `jqSortOrder`), and paged stored procs return `ROWNUM`/`TOTALROWS` columns per row, mapped onto `ROW`/`TOTALROWS` on the response BE (see `AuditoriaData.ListAuditoriaPage` / `usp_sis_R_Auditoria_Paged` for the canonical pattern).
- **Connection strings** are resolved by name via `GlobalSettings.GetBDCadenaConexion("cnxCROMSystemaSEG")`-style calls (one named connection string per DB/module, e.g. `cnxCROMSystemaSEG` for Seguridad) — never hardcode connection strings.
- **Naming**: Business entities are prefixed `BE` (`BEAuditoriaResponse`, `BEBuscaAuditoriaRequest`); Data/Logic classes are named `<Entity>Data` / `<Entity>Logic`; DataContext types are prefixed `_` and match the `.dbml` filename (`_DBMLSeguridadSistemaDataContext`, `_GestionComercial`...). String parameters are upper-cased by convention when bound to SQL parameters unless the property/parameter is marked `[LetterCase(LetterCaseAttribute.LetterCaseType.SensitiveCase)]`.
- **Editing a `.dbml`-backed stored procedure call**: the C# method signature on the DataContext (`_XXXDataContext.designer.cs`) is generated from the `.dbml`. If a stored procedure's parameters or result columns change, the `.dbml` must be updated/refreshed in Visual Studio (or the designer edited to match) — don't hand-edit `.designer.cs` method bodies expecting them to survive a refresh.
- **Some services call out over HTTP** instead of hitting the DB directly — e.g. `CROM.GC.Services.Interfaces.seguridad.ApiServiceSeguridad` posts JSON to an external security API (`GlobalSettings.GetDEFAULT_URL_WS_API_Seguridad()` + `WebConstants` endpoint paths) via `HelperWeb.ProcessRequest`. Check whether a module talks to its own DB or to another system's API before assuming the standard Data-layer pattern applies.
- Logging goes through `HelpLogging` (log4net-backed), not `Console`/`Trace` directly.
