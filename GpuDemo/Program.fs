// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open System.IO
open MathNet.Numerics
open MathNet.Numerics.LinearAlgebra
open System.Diagnostics

[<EntryPoint>]
let main argv = 
    Control.NativeProviderPath <- Path.Combine(__SOURCE_DIRECTORY__,"../")

    printfn "Linear Algebra Provider = %A" Control.LinearAlgebraProvider

    let m = Matrix<double>.Build.Random(500, 500)
    let v = Vector<double>.Build.Random(500)

    let w = Stopwatch.StartNew()
    let y1 = m.Solve(v);
    printfn "Elapsed time: %A" w.Elapsed
    printfn "y1 = %A" y1

        // Using the Intel MKL native provider
    Control.UseNativeMKL()
    printfn "Linear Algebra Provider = %A" Control.LinearAlgebraProvider

    w.Restart()
    let y2 = m.Solve(v);
    printfn "Elapsed time: %A" w.Elapsed
    printfn "y1 = %A" y2

    0 
