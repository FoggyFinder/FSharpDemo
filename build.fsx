#reference "./packages/FAKE/tools/FakeLib.dll"
open Fake

let sourceFiles = [
    "main.fsx"
]

let dependencies = [
    "packages\\FSharp.Data\\lib\\net40\\FSharp.Data.dll"
]

Target "Restore" (fun _ ->
    Paket.Restore (fun x -> x)
)

Target "Build JS" (fun _ ->

    let fableCompiler = "node_modules\\.bin\\fable.cmd"
    let fableArgs = "-m commonjs"

    let sources = sourceFiles |> String.concat ","
    let arguments = fableArgs + " " + sources

    let result = ExecProcessAndReturnMessages (fun info ->
        info.FileName <- fableCompiler 
        info.WorkingDirectory <- "." 
        info.Arguments <- arguments) (System.TimeSpan.FromMinutes 5.0)

    result.Messages
    |> Seq.iter (printfn "FABLE Output: %A") 

    if result.ExitCode <> 0 then
        failwithf "%A returned with a non-zero exit code" fableCompiler
)

Target "Copy Dependencies" (fun _ -> 
    dependencies
    |> FileHelper.Copy "."
)

Target "Build EXE" (fun _ ->
    sourceFiles
    |> FscHelper.Compile [
            FscHelper.Out "main.exe"
            FscHelper.Target FscHelper.TargetType.Exe
            // FscHelper.Debug false
            FscHelper.Checked true
            FscHelper.Define "FSC"
        ]
)

"Restore"
==> "Copy Dependencies"
==> "Build EXE"

"Restore"
==> "Build JS"

Run "Build EXE"
Run "Build JS"
