open System
open System.Threading
open Octokit
open Octokit.Reactive
open System.Threading.Tasks

let myGithubCallback (notification: IssueComment) = 
    printfn "Title: %s" notification.Body
    printfn "UpdatedAt: %A" notification.UpdatedAt
    //printfn "%A" notification
    ()

[<EntryPoint>]
let main argv = 
    let issuesClient = ObservableGitHubClient(ProductHeaderValue("FSharpDemo"))

    //issuesClient.Credentials <- Credentials("211a3b27f7261f913933987e760335128732ba47");
    use subscription = issuesClient.Issue.Comment.GetAllForRepository("fuszenecker", "FSharpDemo").Subscribe(myGithubCallback)

    printfn "Observing..."
    
    while true do
        Thread.Sleep(1000)

    printfn "%A" argv
    0 // return an integer exit code
