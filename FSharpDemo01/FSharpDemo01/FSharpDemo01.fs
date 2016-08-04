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

[<EntryPoint>]
let main argv =
    printfn "Starting Performance test:"
    startPerformanceTest ()

    printfn "%A" argv
    0 // return an integer exit code
