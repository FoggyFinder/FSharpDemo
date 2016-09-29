namespace ViewModels

open System
open System.Windows
open FSharp.ViewModule
open FSharp.ViewModule.Validation
open FsXaml
open System.ComponentModel
open System.Windows.Input

type MainView = XAML<"MainWindow.xaml">

type MyButtonType(viewModel: MainViewModel) =
    let executeChangedEvent = Event<EventHandler,EventArgs>()

    interface ICommand with
        [<CLIEvent>]
        member this.CanExecuteChanged: IEvent<EventHandler,EventArgs> = 
            executeChangedEvent.Publish
            
        member this.CanExecute(parameter: obj): bool = 
            viewModel.Number < 110

        member this.Execute(parameter: obj): unit =
            viewModel.Number <- viewModel.Number + 1
            executeChangedEvent.Trigger(this, EventArgs())

and MainViewModel() as self = 
    inherit ViewModelBase()

    let mutable number = 100

    let event = Event<_,_>()
    let button = MyButtonType(self)

    interface INotifyPropertyChanged with
        [<CLIEvent>]
        member this.PropertyChanged = event.Publish 

    member this.Number
        with get() =
            printfn "Called G: %A" number 
            number
        and set(value) =
            printfn "Called S: %A" value 
            number <- value
            event.Trigger(this, PropertyChangedEventArgs("Number"))

    member this.MyButton
        with get() = 
            button