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

    printfn "Introduction.integral: %A" (integral (fun x -> x * x) 1.0 2.0 0.0001)
    // f(x) = x^2
    // F(X) = x^3/3
    // integral f(x) = F(2) - F(1) = 8/3 - 1/3 = 7/3

    let rec integral' f (xmin: float) (xmax: float) (dx: float) (accumulator:float) =
        if (xmin >= xmax) then
            accumulator
        else
            integral' f (xmin + dx) xmax dx (accumulator + (dx * f xmin))

    printfn "Introduction.integral: %A" (integral' (fun x -> x * x) 1.0 2.0 0.00000001 0.0)

module Types =

    let a = 100
    let b = 100L
    let c = "100"

#if FSC
    let d = 100M
    let e = 100I
#endif

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

#if FSC
    let result = Int64.TryParse("100")
    let (success, value) = result

    printfn "TuplesAndRecords.result %A" result

    type MyRecordType = { Id: int64; Name: string; Value: decimal option }
    let myRecord = { Id = 100L; Name = "Hello"; Value = None }
    let newRecord = { myRecord with Id = 200L; Value = Some 2M}
#endif

module Enums =

    type ColorEnum = 
        | Red = 1
        | Green = 2
        | Blue = 4

module DiscriminatedUnions =

    [<NoComparison>]
    type LoginMethods =
    | UserNameAndPassword of string * string
    | UserIdAndPin of int * int
    | FingerPrint of byte array
    | Certificate of System.Security.Cryptography.X509Certificates.X509Certificate

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

    // Null check
    let isNull x =
        match x with
        | null -> true
        | _ -> false

    // Pattern matching with types
    let myObj = "Hello"

#if FSC
    let whatIsIt (x:obj) =
        match x with
        | :? string as s -> printfn "PatternMatching.whatIsIt is string (%A)" s
        | :? int as i -> printfn "PatternMatching.whatIsIt is int (%A)" i
        | :? System.Exception as e -> printfn "PatternMatching.whatIsIt is exception (%A)" e

    whatIsIt myObj
#endif

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

#if FSC
module Operators =

    open Checked

    let rec (~&) n =
        match n with
        | n when n < 0 -> invalidArg "n" "Invalid argument"
        | 0 -> 1
        | _ -> n * (~&) (n - 1)

    let result = &12

    printfn "Operators.&: %A" result

    let (|>) x f = f x

    let result' = 
        [1..10] 
        |> List.map (fun x -> x * x)
        |> List.iter (printfn "%A")
#endif

module ActivePatterns =

    let (|IsOdd|IsEven|) n = if n % 2 = 0 then IsEven else IsOdd

    match 12 with
        | IsEven -> printfn "ActivePatterns: 12 is even"
        | IsOdd -> printfn "ActivePatterns: 12 is odd"

module Classes =

    type MyClass(x:int, y:int) =
        let mutable _x = x
        let mutable _y = y

        member this.X = _x

        member this.Y 
            with get () = _y
            and set (value:int) = _y <- y

        new() = MyClass(0, 0)

    // Inheritance
    type Base() =
        member this.Add x y = x + y
        abstract member MemberFunc : int -> string -> string list
        default this.MemberFunc a b = [""]

    type Derived() =
        inherit Base()
        member this.Sub x y = x - y

    // Abstact class, override
    type Derived2() =
        inherit Base()
        override this.MemberFunc x y = ["Derived"; x.ToString(); y]

module Interfaces =

    type IInterface1 =
        abstract member MemberFunc1 : int -> string -> unit

    type IInterface2 =
        abstract member MemberFunc2 : int64 -> decimal

    type Derived() =
        interface IInterface1 with 
            member this.MemberFunc1 x y = ()

#if FSC
        interface IInterface2 with 
            member this.MemberFunc2 z = 120M
#endif

module Exceptions =
    // failwith -> System.Exception
    // invalidArg -> System.ArgumentException
    // nullArg -> System.NullArgumentException
    // invalidOp -> System.InvalidOperationException

#if FSC
    try
        failwith "fail"
    with
        | Failure msg -> "caught: " + msg
        | :? System.InvalidOperationException as ex -> "unexpected"

    let myFunction x = 
        try
            if x then "ok" else failwith "fail"
        finally
            printf "this will always be printed"
#else
    ()
#endif

module Events =
    let myEvent = Event<string>()
    let publishedEvent = myEvent.Publish
    publishedEvent.Add(function t -> printfn "Events: %A" t)

    myEvent.Trigger("Data")

module UnitsOfMeasure =

    [<Measure>] type kg
    [<Measure>] type m
    [<Measure>] type s

    let c = 300000000L<m/s>
    let mass = 1L<kg>
    let E = mass*c*c

    printfn "UnitsOfMeasure.E: %A" E

module AsyncProgramming =

    let myTask delay = async {
#if FSC
        do System.Threading.Thread.Sleep(delay * 1000)
#endif
        return 100 + delay 
    }

    [1..5]
    |> Seq.map myTask
    |> Async.Parallel
    |> Async.RunSynchronously 
    |> Seq.iter (printfn "Result: %A")

module ComputationalExpressions =
    ()

module TypeProviders =
    ()
