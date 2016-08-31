#r "./packages/FAKE/tools/FakeLib.dll" // include Fake lib
open Fake 

let fableCompiler = "node_modules/.bin/fable.cmd"
let fableArgs = "-m commonjs -s"
let fableFiles = "main.fsx"

Target "Restore" (fun _ ->
    Paket.Restore (fun x -> x)
)

Target "Build" (fun _ ->
    let result = ExecProcessAndReturnMessages (fun info ->
        info.FileName <- fableCompiler 
        info.WorkingDirectory <- "." 
        info.Arguments <- fableArgs + " " + fableFiles) (System.TimeSpan.FromMinutes 5.0)

    result.Messages
    |> Seq.iter (printfn "FABLE Output: %A") 

    if result.ExitCode <> 0 then
        failwithf "%A returned with a non-zero exit code" fableCompiler
)

"Restore"
==> "Build"

Run "Build"
