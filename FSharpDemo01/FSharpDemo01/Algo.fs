module Algo

    open Checked

    let Polynomial = 0x90000001u;

    let Summarize (state: uint32) (start: uint64) (n: int): uint64 =
        let mutable Shreg:uint32 = 0u
        let mutable accumulator = start
        Shreg <- state;

        let Next (): uint32 =
            Shreg <- Shreg <<< 1;

            if Shreg &&& 0x80000000u <> 0u then
                Shreg <- Shreg ^^^ Polynomial

            Shreg

        for i = 1 to n do
            accumulator <- accumulator + (uint64)(Next ())

        accumulator

    // Performance test runner
    open System.Diagnostics

    let startPerformanceTest () : unit =

        let startState = 2u
        let startSum = 0uL
        let n = 2000000000

        let sw = new Stopwatch ()

        sw.Start ()
        printfn "F#: "
        let result = Summarize startState startSum n
        printfn "Eredmény: %A" result
        printfn "Idő: %A" sw.Elapsed
