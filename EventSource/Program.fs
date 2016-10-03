open System
open System.Threading
open Octokit
open Octokit.Reactive

let myGithubCallback (notification: Issue) = 
    printfn "Title: %A" notification.Title
    printfn "UpdatedAt: %A" notification.UpdatedAt
    ()

[<EntryPoint>]
let main argv = 
    let client = new GitHubClient(new ProductHeaderValue("FSharpDemo"));
    client.Credentials <- Credentials("211a3b27f7261f913933987e760335128732ba47");

    let user = client.User.Current().Result
    printfn "User: %s" user.Name

    //let observableClient = ObservableNotificationsClient(client)
    //use subscription = observableClient.GetAllForRepository("fuszenecker", "FSharpDemo").Subscribe(myGithubCallback)

    let issuesClient = ObservableIssuesClient(client)
    use subscription = issuesClient.GetAllForCurrent().Subscribe(myGithubCallback)

    printfn "Observing..."
    
    while true do
        Thread.Sleep(1000)

    printfn "%A" argv
    0 // return an integer exit code
