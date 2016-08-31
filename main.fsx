namespace FSharpDemo

module Introduction =
    let myFunction arg1 arg2 =
        let returnValue = arg1 * arg2
        returnValue

    printfn "Introduction: %A" (myFunction 10 20)

    let rec factorial n =
        match n with
        | 0 -> 1
        | _ -> n * factorial (n - 1)

    printfn "Introduction.factorial(10): %A" (factorial 10)

    let myList = [ 1; 2; 3; 4; 5]

    let rec reverseList list =
        match list with
        | [] -> []
        | firstItem :: others -> (reverseList others) @ [firstItem]

    printfn "Introduction.reverseList: %A" (reverseList myList)

    let rec integral f (xmin: float) (xmax: float) (dx: float) =
        if (xmin >= xmax) then
            0.0
        else
            (dx * f xmin) + (integral f (xmin + dx) xmax dx)  

    printfn "Introduction.integral: %A" (integral (fun x -> x * x) 1.0 2.0 0.00001)
    // f(x) = x^2
    // F(X) = x^3/3
    // integral f(x) = 8/3 - 1/3 = 7/3

module Types =

    let a = 100
    let b = 100L
    let c = "100"
    let d = 100M
    let e = 100I
    let f = System.DateTime.Now
    let g = ()
    let h = true

module TypeAliases =

    type LoginNameType = string
    type PinCodeType = int

    type FirstNameType = string
    type LastNameType = string
    type FullNameType = FirstNameType * LastNameType

module Collections =

    open FSharp.Collections

    let intList = [1; 2; 3; 4; 5]
    let intList': List<int> = [1; 2; 3; 4; 5]

    let intArray = [|1; 2; 3; 4; 5|]
    let intArray': int array = [|1; 2; 3; 4; 5|]

    intArray.[3] <- 20

    let intSeq = seq {
        yield 1
        yield 2
        yield 3
    }

    printfn "Collections.Seq %A" intSeq

module TuplesAndRecords =
    open System

    let myTuple = ("Hello", "from", "F#", DateTime.Now)
    let result = Int64.TryParse("100")
    let (success, value) = result

    printfn "TuplesAndRecords.myTuple %A" result

    type MyRecordType = { Id: int64; Name: string; Value: decimal option }
    let myRecord = { Id = 100L; Name = "Hello"; Value = None }
    let newRecord = { myRecord with Id = 200L; Value = Some 2M}

module Enums =

    type ColorEnum = 
        | Red = 1
        | Green = 2
        | Blue = 4

module DiscriminatedUnions =

    type LoginMethods =
    | UserNameAndPassword of string * string
    | UserIdAndPin of int * int
    | FingerPrint of byte array
    | Certificate of System.Security.X509Certificate

    let myLogin = UserIdAndPin(274161, 06180)

    type UserNameType = string
    type PasswordType = string

    type LoginMethods'' =
    | UserNameAndPassword of UserNameType * PasswordType

module Generics = ()

    // 'T
    // _
    // 'T when 'T :> System.Exception
    // 'T when 'T : null
    // 'T when 'T : (static member CreateObject: unit -> 'T)
    // 'T when 'T : (new: unit -> 'T)
    // 'T when 'T : not struct

module OptionType =

    type Option<'T> =
    | Some of 'T
    | None

    type OptionalStringType = string option
    type OptionalDateTimeType = Option<System.DateTime>

module PatternMatching =

    open System

    let myValue = Some DateTime.Now

    match myValue with
    | Some x -> printfn "PatternMatching.DateTime: %A" x
    | None -> printfn "PatternMatching.DateTime: nothing is provided"

    let rec fibonacci n =
        match n with
        | 0 -> 0
        | 1 -> 1
        | n when n < 0 -> invalidArg "n" "Argument 'n' is invalid"
        | _ -> fibonacci (n - 1) + fibonacci (n - 2)

    printfn "PatternMatching.TenthFibonacci: %A " (fibonacci 10)

    let isNull x =
        match x with
        | null -> true
        | _ -> false

module Structs =

    type Point2D =
        struct
            val X: float
            val Y: float
            new(x, y) = { X = x; Y = y }
        end

    let myPoint2D = Point2D(2.0, 3.0)

    printfn "Structs.myPoint2D: {%A %A}" myPoint2D.X myPoint2D.Y

module FunctionsAndCurrying =

    let myfunction arg1 arg2 = arg1 + arg2
    let result = myfunction 10 20

    let add x y = x + y
    let bicrement = add 2
    let r = bicrement 10
