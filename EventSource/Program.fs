open System
open Octokit
open Octokit.Reactive

let myGithubCallback  notification = 
    printfn "NOTI: %A" (notification.ToString())
    ()

[<EntryPoint>]
let main argv = 
    let client = new GitHubClient(new ProductHeaderValue("FSharpDemo"));
    client.Credentials <- Credentials("853ca4d05a27db33747154c2119fd6921e08710b");

    let observableClient = ObservableNotificationsClient(client)

    use subscription = observableClient.GetAllForRepository("fuszenecker", "FSharpDemo").Subscribe(myGithubCallback)

    printfn "Observing..."
    Console.ReadLine() |> ignore

    printfn "%A" argv
    0 // return an integer exit code
