namespace FacebookApiDemo

open System
open Nancy
open Nancy.Hosting.Self
open Nancy.Extensions
open System.Threading

module Rest =
    type FacebookApiModule() as this =
        inherit NancyModule()

        do
            this.Get.["/"] <- fun _ ->
                this.printRequest "GET"
                "Hello from Nancy" :> obj

            this.Post.["/"] <- fun _ ->
                this.printRequest "POST"
                [] :> obj

        member this.printRequest verb =
            printfn "\n---------------------------------------------------------"
            printfn "%s request arrived:" verb
            printfn "---------------------------------------------------------"

            this.Request.Headers
            |> Seq.iter (fun keyValuePair -> printfn "%s: %A" keyValuePair.Key (String.concat ", " keyValuePair.Value))

            printfn ""

            this.Request.Body.AsString()
            |> printfn "%s"

module MainModule =

    [<EntryPoint>]
    let main argv =
        let url = "http://localhost:5004"

        printfn "Starting Nancy Demo Service..."

        use host = new NancyHost(Uri(url))
        host.Start()
        printfn "Running on %A" url

        while true do
            Thread.Sleep(1000)

        0
