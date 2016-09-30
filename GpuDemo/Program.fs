// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open System.IO
open MathNet.Numerics
open MathNet.Numerics.LinearAlgebra
open System.Diagnostics

module GpgpuModule =

    let compareSequences seq1 seq2 = 
        // Compare the first 5 decimal digit of the double
        Seq.compareWith (fun x y -> int ( x * 100000.0) - int (y * 100000.0)) seq1 seq2
        |> (=) 0

    [<EntryPoint>]
    let main argv = 
        let dataSize = 3000

        let myMatrix = Matrix<double>.Build.Random(dataSize, dataSize)
        let myVector = Vector<double>.Build.Random(dataSize)

        Control.UseManaged();
        printfn "Linear Algebra Provider = %A" Control.LinearAlgebraProvider

        let stopwatch = Stopwatch.StartNew()
        let solution1 = myMatrix.Solve(myVector);
        let elapsed1 = stopwatch.Elapsed
        printfn "Elapsed time: %A" elapsed1
        printfn "y1 = %A" solution1

        // Using the Intel MKL native provider
        //Control.NativeProviderPath <- Path.Combine(__SOURCE_DIRECTORY__, @"..\packages\MathNet.Numerics.MKL.Win.2.1.0\build\x64")
        Control.UseNativeMKL()
        printfn "Linear Algebra Provider = %A" Control.LinearAlgebraProvider

        stopwatch.Restart()
        let solution2 = myMatrix.Solve(myVector);
        let elapsed2 = stopwatch.Elapsed
        printfn "Elapsed time: %A" stopwatch.Elapsed
        printfn "y1 = %A" solution2

        printfn "Solution1 equals to Solution2 = %A" (compareSequences solution1 solution2)
        printfn "Elapsed1 / Elapsed2 = %A" (elapsed1.TotalMilliseconds / elapsed2.TotalMilliseconds)

        0 
