open System
open Octokit
open Octokit.Reactive

let myGithubCallback  notification = 
    printfn "NOTI: %A" (notification.ToString())
    ()

[<EntryPoint>]
let main argv = 
    let client = new GitHubClient(new ProductHeaderValue("FSharpDemo"));
    client.Credentials <- Credentials("d7633e43c0b5750fc5d94bdb9c8d5bc518b2f623");

    let observableClient = ObservableNotificationsClient(client)

    use subscription = observableClient.GetAllForRepository("fuszenecker", "FSharpDemo").Subscribe(myGithubCallback)

    printfn "Observing..."
    Console.ReadLine() |> ignore

    printfn "%A" argv
    0 // return an integer exit code
