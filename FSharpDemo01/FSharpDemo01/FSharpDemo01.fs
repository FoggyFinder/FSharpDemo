module FSharpDemo01

// #r """..\..\packages\RestSharp\lib\net45\RestSharp.dll"""
open RestSharp

open Algo


printfn "Hello World"

// let z = query {
//     for i in [1..5] do
//     where (i < 3)
//     select i
// }

// printfn "%A" z


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

open Checked

let addChecked () =
    try
        let x = 100uy
        let y = 200uy
        x + y
    with
    | e -> 
        printfn "Exc: %A" e
        0uy
    // finally
    //     let i = 100

addChecked () |> ignore

// let (|Prime|NotPrime|) x =
//     let isEven x =
//         x % 2 = 0

//     let isNotDividable x =
//         let max = int (sqrt (float x))

//         [3..2..max]
//         |> Seq.forall (fun j -> x % j <> 0)

//     if (isEven x) || (not (isNotDividable x)) then NotPrime else Prime

// match 2333455 with
// | Prime -> printfn "Prime"
// | NotPrime -> printfn "Not Prime"

[<EntryPoint>]
let main argv =
    printfn "Starting Performance test:"
    startPerformanceTest ()

    printfn "%A" argv
    0 // return an integer exit code
