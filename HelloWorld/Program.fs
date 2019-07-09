module Program

open System
open Model
open Microsoft.EntityFrameworkCore

let add (path: string, ctx: AppContext) =
    ctx.Projects.Add(Project(Type = "", Path = path)) |> ignore
    ctx.SaveChanges() |> ignore
    ()

let get (str: string, ctx: AppContext) =
    query {
        for project in ctx.Projects do
            where (EF.Functions.Like (project.Path, sprintf "%%%s%%" str))
    }
    |> Seq.toList

[<EntryPoint>] 
let main argv =
    use db = new AppContext()
    db.Database.Migrate() |> ignore
    match argv.[0] with
    | "get" -> get (argv.[1], db) |> printfn "%A"
    | "add" -> add (argv.[1], db)
    | _ -> ()
    
    if (Array.contains "get" argv) then printfn "Go Go Go!"
    else printfn "Stop!"
    0 // return an integer exit code
