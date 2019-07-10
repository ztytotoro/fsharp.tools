module Model

open Microsoft.EntityFrameworkCore

type BaseEntity() =
    member val Id: string = "" with get, set

type Project() =
    inherit BaseEntity()

    member val Type : string = "" with get, set
    member val Path : string = "" with get, set

type ProjectType() =
    inherit BaseEntity()

    member val Name : string = "" with get, set

type AppContext() =
    inherit DbContext()

    member val Projects : DbSet<Project> = null with get, set
    member val ProjectTypes : DbSet<ProjectType> = null with get, set

    override this.OnConfiguring(optionsBuilder : DbContextOptionsBuilder) =
        optionsBuilder.UseSqlite "Data Source=data.db"
        |> ignore
