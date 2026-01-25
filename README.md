# Auth API

A study-focused authentication API built with modern .NET practices, designed to be clean, professional, and production-ready.

---

# 📦 Database Configuration & Migrations

---

## 🇧🇷 Português — Configuração de Banco de Dados e Migrations

### 🛠 Tecnologias utilizadas

* **.NET 8**
* **Entity Framework Core**
* **PostgreSQL**
* **Docker**
* **EFCore.NamingConventions** (snake_case)

---

### 🧱 Convenção de nomes

Este projeto utiliza **snake_case** no banco de dados para evitar problemas com *case sensitivity* no PostgreSQL e manter um padrão profissional.

A conversão é feita automaticamente usando o pacote:

```text
EFCore.NamingConventions
```

Configuração no `Program.cs`:

```csharp
builder.Services.AddDbContext<AuthDbContext>(options =>
{
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection"))
        .UseSnakeCaseNamingConvention();
});
```

---

### 🐘 Banco de dados via Docker

O banco PostgreSQL é executado via Docker para facilitar o ambiente de desenvolvimento.

Subir o banco:

```powershell
docker compose up -d
```

Parar e remover volumes (reset completo do banco):

```powershell
docker compose down -v
```

---

### 📁 Estrutura das migrations

As migrations ficam no projeto **Infrastructure**, mantendo a separação de responsabilidades:

```text
src/
 └── AuthApi.Infrastructure/
     └── Persistence/
         └── Migrations/
```

---

### 🚀 Criar uma migration

Execute o comando **a partir da raiz da solution**:

```powershell
dotnet ef migrations add InitialCreate --project src/AuthApi.Infrastructure --startup-project src/AuthApi.API --output-dir Persistence/Migrations
```

---

### 🆙 Aplicar migrations ao banco

```powershell
dotnet ef database update --project src/AuthApi.Infrastructure --startup-project src/AuthApi.API
```

---

### 🌱 Seed de dados

O projeto utiliza **seed via EF Core** para dados essenciais do sistema, como perfis padrão (`Admin`, `User`).

Esses dados são versionados e aplicados automaticamente junto com as migrations.

---

### 📌 Observações importantes

* As migrations **devem ser versionadas no Git**
* Nunca altere migrations já aplicadas em produção
* Para projetos de estudo, é seguro remover e recriar migrations
* Para produção, sempre crie novas migrations incrementais

---

## 🇺🇸 English — Database Configuration and Migrations

### 🛠 Technologies used

* **.NET 8**
* **Entity Framework Core**
* **PostgreSQL**
* **Docker**
* **EFCore.NamingConventions** (snake_case)

---

### 🧱 Naming convention

This project uses **snake_case** naming convention in the database to avoid PostgreSQL case sensitivity issues and to follow industry best practices.

The conversion is handled automatically using:

```text
EFCore.NamingConventions
```

Configuration in `Program.cs`:

```csharp
builder.Services.AddDbContext<AuthDbContext>(options =>
{
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection"))
        .UseSnakeCaseNamingConvention();
});
```

---

### 🐘 Database with Docker

PostgreSQL runs inside Docker to simplify the development environment.

Start the database:

```powershell
docker compose up -d
```

Stop and remove volumes (full database reset):

```powershell
docker compose down -v
```

---

### 📁 Migrations structure

Migrations are stored in the **Infrastructure** project to keep a clean architecture separation:

```text
src/
 └── AuthApi.Infrastructure/
     └── Persistence/
         └── Migrations/
```

---

### 🚀 Create a migration

Run the command **from the solution root folder**:

```powershell
dotnet ef migrations add InitialCreate --project src/AuthApi.Infrastructure --startup-project src/AuthApi.API --output-dir Persistence/Migrations
```

---

### 🆙 Apply migrations to the database

```powershell
dotnet ef database update --project src/AuthApi.Infrastructure --startup-project src/AuthApi.API
```

---

### 🌱 Data seeding

The project uses **EF Core data seeding** for essential system data such as default profiles (`Admin`, `User`).

Seed data is versioned and applied automatically with migrations.

---

### 📌 Important notes

* Migrations **must be committed to Git**
* Never modify migrations already applied in production
* For study projects, it's safe to recreate migrations
* For production, always create incremental migrations
