open System.IO
open System

[<EntryPoint>]
let main argv =
    let fileName = argv.[0]
    File.ReadAllText(fileName) |> Console.WriteLine
    1