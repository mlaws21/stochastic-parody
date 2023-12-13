open Parser
open Evaluator
open Combinator
open System.IO

(*
* Driver program for the <TODO> language
* @param args: a list of strings taken from command line, should only be a single string that is a file to translate
* @return 0 for clean exits with code -99 for a bad file read
*)
[<EntryPoint>]
let main args =
    let input = 
        try 
            File.ReadAllText args[0]
        with 
        | :? FileNotFoundException -> 
                printfn "File not found\nUsage: dotnet run <file.song>"
                exit(-99)
        | ex -> printfn "Usage: dotnet run <file.song>"
                exit(-99)

    let astOp = parse input
    match astOp with
    | Some ast -> printfn "%A" (prettyprint (evalProg ast))
    | None -> ()

    0
