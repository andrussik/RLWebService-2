# RL web service

* [For developers](#for-developers)
    * [DAL](#dal)
    * [BLL](#bll)
    * [Domain](#domain)
    * [EF and database](#ef)
    * [Secrets](#secrets)
    * [Rules](#rules)
  

## <a name="for-developers" /> For developers

### <a name="dal"/> DAL - *Data Access Layer*
* This layer should access data from external sources and return it, nothing else!
* DAL consists of repositories.
* Repositories have scoped lifetime.
* Repositories are registered in repository collection. Each external source has it's own repository collection.
* To create new repository:
    1. Create interface in Contracts directory.
    2. Create repository in App directory.
    3. Register new repository in repository collection.
* External sources:
    * Database
    * Sierra API 
    * Riks API
    * Urram API
    * Search engine API

### <a name="bll" /> BLL - *Business Logic Layer*    
* This layer should do all the mandatory calculations.
* BLL consists of BL classes and services.
* BL classes are static and contain methods that are used across services to make necessary calculations.
* Services make necessary calculations and provide output for:
    * controllers -> clients
    * repositories -> external sources
* Services have scoped lifetime.
* Services are registered in service collection.
* To create new service:
    1. Create interface in Contracts directory.
    2. Create repository in App directory.
    3. Register new service in service collection.
  
### <a name="domain" /> Domain
* Database entities (every database entity must derive from BaseEntity class)
* Look-up enums

### <a name="ef"/> EF and database
* Install EF tools: `dotnet tool install --global dotnet-ef`
* Set up database connection:
    * Set up [Secrets](#secrets)
    * Create new secret: `dotnet user-secrets set "ConnectionStrings:AzureSqlEdge" "server=localhost,1433;database=RLDB;user=SECRET_USER;password=SECRET_PASSWORD"`
* Create new table:
    1. Create model class in Domain/Models
    2. Add DbSet in DAL/EF/AppDbContext.cs
    3. Add migration X: `dotnet ef migrations add X --startup-project WebApp --project DAL -o EF/Migrations`
    4. Generate SQL script from migration X to migration Y: `dotnet ef migrations script X Y --startup-project WebApp --project DAL -o DAL/EF/script.sql`
    5. Review and run script.
* List available migrations `dotnet ef migrations list --startup-project WebApp --project DAL`

### <a name="secrets" /> Secrets
* Initialize user secrets: `dotnet user-secrets init --project WebApp`
* Set a secret: `dotnet user-secrets set "ApiKeys:ServiceApiKey" "12345" --project WebApp`
* Remove a secret: `dotnet user-secrets remove "ApiKeys:ServiceApiKey" --project WebApp`
* List the secrets: `dotnet user-secrets list --project WebApp`

Access tokens are stored in IdentityServerClient and updated automatically with token handlers.

### <a name="rules" /> Rules
* Get rid of all the warnings before deploy!
* If you use raw SQL, then be as strongly typed as possible, e.g. `$"select * from [{nameof(TableName)}].[{nameof(ColumnName)}]"`
* Feel free to add any rules ;)

### <a name="todo" /> TO-DO
* ~~Repository factory~~
* ~~Service factory~~
* ~~Injectable repository collection~~
* ~~Injectable service collection~~
