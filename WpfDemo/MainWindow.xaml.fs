namespace ViewModels

open System
open System.Windows
open FSharp.ViewModule
open FSharp.ViewModule.Validation
open FsXaml
open System.ComponentModel
open System.Windows.Input

type MainView = XAML<"MainWindow.xaml">

type MainViewModel() as self = 
    inherit ViewModelBase()

    let number = self.Factory.Backing(<@ self.Number @>, 100)

    let addNumber() =
        number.Value <- number.Value + 1

    let addNumberCommand = self.Factory.CommandSyncChecked(addNumber,fun () -> number.Value < 110)
    
    member this.MyButton = addNumberCommand
    member this.Number
        with get() = number.Value
        and set v = number.Value <- v
