namespace ViewModels

open System
open System.Windows
open FSharp.ViewModule
open FSharp.ViewModule.Validation
open FsXaml
open System.ComponentModel
open System.Windows.Input

type MainView = XAML<"MainWindow.xaml">

type MyButtonType(o: MainViewModel) =
    let z = Event<EventHandler,EventArgs>()

    interface ICommand with
        [<CLIEvent>]
        member x.CanExecuteChanged: IEvent<EventHandler,EventArgs> = 
            z.Publish
            
        member x.CanExecute(parameter: obj): bool = 
            true

        member x.Execute(parameter: obj): unit = 
            printfn "Button pressed"
            o.X <- o.X + 1

                 
and MainViewModel() as self = 
    inherit ViewModelBase()

    let mutable k = 100

    let evt = Event<_,_>()
    let button = MyButtonType(self)

    interface INotifyPropertyChanged with
        [<CLIEvent>]
        member this.PropertyChanged = evt.Publish 

    member this.X
        with get() =
            printfn "Called G: %A" k 
            k
        and set(value) =
            printfn "Called S: %A" value 
            k <- value
            evt.Trigger(this, PropertyChangedEventArgs("X"))

    member this.MyButton
        with get() = 
            button