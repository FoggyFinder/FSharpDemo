module FSharpDemo01

// #r """..\..\packages\RestSharp\lib\net45\RestSharp.dll"""
open RestSharp

open Algo

let getHup () =
    let client = RestClient ("http://hup.hu/tracker")
    
    RestRequest (Method.GET)
    |> client.Execute
    |> fun x -> x.Content

// [1..1000]
// |> Seq.iter (function x -> getHup() |> ignore)

// type myInterface =
//     abstract MyProg : unit -> unit
//     abstract M : int -> int

// let z = function
//     | 10, 20 -> printfn "%A" 10
//     | _, _ -> ()

// z (10, 20)

// open Checked
// let x = 100uy
// let y = 200uy
// let s = x + y

[<EntryPoint>]
let main argv =
    printfn "Starting Performance test:"
    startPerformanceTest ()

    printfn "%A" argv
    0 // return an integer exit code
