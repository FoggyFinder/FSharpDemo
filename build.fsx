#reference "./packages/FAKE/tools/FakeLib.dll"
open Fake

let sourceFiles = [
    "main.fsx"
]

Target "Restore" (fun _ ->
    Paket.Restore (fun x -> x)
)

Target "Build JS" (fun _ ->
    let fableCompiler = "node_modules/.bin/fable.cmd"
    let fableArgs = "-m commonjs -s"

    let sources = sourceFiles |> String.concat ","

    let result = ExecProcessAndReturnMessages (fun info ->
        info.FileName <- fableCompiler 
        info.WorkingDirectory <- "." 
        info.Arguments <- fableArgs + " " + sources) (System.TimeSpan.FromMinutes 5.0)

    result.Messages
    |> Seq.iter (printfn "FABLE Output: %A") 

    if result.ExitCode <> 0 then
        failwithf "%A returned with a non-zero exit code" fableCompiler
)

Target "Build EXE" (fun _ ->
    sourceFiles
    |> FscHelper.Compile [
            FscHelper.Out "main.exe"
            FscHelper.Target FscHelper.TargetType.Exe
            // FscHelper.Debug false
            FscHelper.Checked true
        ]
)

"Restore"
==> "Build JS"
==> "Build EXE"

Run "Build EXE"
