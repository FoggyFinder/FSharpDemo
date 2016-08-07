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

let (|Prime|NotPrime|) x =
    let isEven x =
        x % 2 = 0

    let isNotDividable x =
        let max = int (sqrt (float x))

        [3..2..max]
        |> Seq.forall (fun j -> x % j <> 0)

    let isNotDividable2 x =
        let max = int (sqrt (float x))

        let rec isDividableWithOddNumbers x n max =
            match (x, n, max) with
            | _, n, max when n >= max -> false
            | x, n, _ when x % n = 0 -> true
            | x, n, max -> isDividableWithOddNumbers x (n+2) max                

        not (isDividableWithOddNumbers x 3 max)

    if (isEven x) || (not (isNotDividable2 x)) then NotPrime else Prime

match 65537 with
| Prime -> printfn "Prime"
| NotPrime -> printfn "Not Prime"

// let o = System.Object ()
// let z = lock o
//         <| fun x -> 100


[<EntryPoint>]
let main argv =
    printfn "Starting Performance test:"
    startPerformanceTest ()

    printfn "%A" argv
    0 // return an integer exit code
