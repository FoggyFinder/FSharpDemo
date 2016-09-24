#if COMPILED
namespace FSharpDemo
#endif

// ---------------------------------------------------------------------------
// TABLE OF CONTENTS
//
//  1. Introduction
//  2. Let's transcend: from imperative to functional programming
//  3. Basic types
//  4. Functions
//  5. Object-oriented programming
//  6. Exception handling and raising
//  7. Events
//  8. Unit of measure in
//  9. Asynchron programming
// 10. Type providers
// 11. Native interop
// 12. Other interesting topics: code quotations and computational expressions
// ---------------------------------------------------------------------------

// ---------------------------------------------------------------------------
// 1. Introduction
// ---------------------------------------------------------------------------

module Introduction =

    let myFunction arg1 arg2 =
        let returnValue = arg1 * arg2
        returnValue

    printfn "Introduction.myFunction: %A" (myFunction 10 20)

    let lambdaFunction = fun x y -> x + y

    let partiallyAppliedFunction () = 
        lambdaFunction 1

    let rec factorial n =
        match n with
        | 0 -> 1
        | _ -> n * factorial (n - 1)

    printfn "Introduction.factorial(10): %A" (factorial 10)

    let rec toBinaryString value =
        match value with 
        | 0 -> "0"
        | 1 -> "1"
        | x -> (toBinaryString (x / 2)) + string (x % 2)

    printfn "Introduction.toBinaryString(13): %A" (toBinaryString 13)

    let myList = [ 1; 2; 3; 4; 5 ]

    let rec reverseList list =
        match list with
        | [] -> []
        | firstItem :: others -> (reverseList others) @ [firstItem]

    printfn "Introduction.reverseList: %A" (reverseList myList)

#if FSC // JS doesn't have good tail-recursion
    // y = integral f(x) = x^2 from 1.0 to 2.0 
    // f(x) = x^2
    // F(X) = x^3/3
    // y = F(2) - F(1) = 8/3 - 1/3 = 7/3

    let rec integral f (xmin: float) (xmax: float) (dx: float) =
        if (xmin >= xmax) then
            0.0
        else
            (dx * f xmin) + (integral f (xmin + dx) xmax dx)

    printfn "Introduction.integral: %A" (integral (fun x -> x * x) 1.0 2.0 0.0001)

    // public static double integral(FSharpFunc<double, double> f, double xmin, double xmax, double dx)
    // {
    //     if (xmin >= xmax)
    //     {
    //         return 0.0;
    //     }
    //     return dx * f.Invoke(xmin) + Introduction.integral(f, xmin + dx, xmax, dx);
    // }  

    let rec integral' f (xmin: float) (xmax: float) (dx: float) (accumulator:float) =
        if (xmin >= xmax) then
            accumulator
        else
            integral' f (xmin + dx) xmax dx (accumulator + (dx * f xmin))

    printfn "Introduction.integral: %A" (integral' (fun x -> x * x) 1.0 2.0 0.00000001 0.0)

    // public static double integral'(FSharpFunc<double, double> f, double xmin, double xmax, double dx, double accumulator)
    // {
    //     while (xmin < xmax)
    //     {
    //         FSharpFunc<double, double> arg_21_0 = f;
    //         double arg_1F_0 = xmin + dx;
    //         double arg_1D_0 = xmax;
    //         double arg_1B_0 = dx;
    //         accumulator += dx * f.Invoke(xmin);
    //         dx = arg_1B_0;
    //         xmax = arg_1D_0;
    //         xmin = arg_1F_0;
    //         f = arg_21_0;
    //     }
    //     return accumulator;
    // }

#endif

// ---------------------------------------------------------------------------
// 2. Let's transcend: from imperative to functional programming
// ---------------------------------------------------------------------------

module LetsTranscend =

    // Q: What is the sum of the first 5 even Fibonacci numbers?
    // A: 798.

    // ------------------------------------------------------
    // The imperative
    // ------------------------------------------------------
    //
    // public int CalculateFibonacciSumImperative()
    // {
    //     var x1 = 0;
    //     var x2 = 1;
    //     var sum = 0;
    //     var count = 0;
    //
    //     do
    //     {
    //         var newValue = x1 + x2;
    //         x1 = x2;
    //         x2 = newValue;
    //
    //         if (newValue % 2 == 0)
    //         {
    //             count++;
    //             sum += newValue;
    //         }
    //     } while (count != 5);
    //
    //     return sum;
    // }

    // ------------------------------------------------------
    // With iterator
    // ------------------------------------------------------
    //
    // public static IEnumerable<int> FibonacciSeq
    // {
    //     get
    //     {
    //         var x1 = 0;
    //         var x2 = 1;
    //
    //         while (true)
    //         {
    //             var newValue = x1 + x2;
    //             x1 = x2;
    //             x2 = newValue;
    //
    //             yield return newValue;
    //         }
    //     }
    // }
    //
    // var s = FibonacciSeq
    //     .Where(x => x % 2 == 0)
    //     .Take(5)
    //     .Sum();

    // ------------------------------------------------------
    // Rewritten in F#
    // ------------------------------------------------------

    let fibonacciSeq1 = seq {
        let mutable x1 = 1
        let mutable x2 = 1

        while true do
            let temp = x2
            x2 <- x1 + x2
            x1 <- temp
            yield x2
    }

    let fibonacciSum =
        fibonacciSeq1
        |> Seq.filter (fun x -> x % 2 = 0)
        |> Seq.take 5
        |> Seq.sum

    // ------------------------------------------------------
    // Recursive sequence
    // ------------------------------------------------------

    let fibonacciSeq2 =
        let rec fibseq n1 n2 = seq { 
                let n0 = n1 + n2 
                yield n0
                yield! fibseq n0 n1 
        }
        
        seq { 
            yield! (fibseq 0 1)
        }

    let fibonacciSum2 =
        fibonacciSeq2
        |> Seq.filter (fun x -> x % 2 = 0)
        |> Seq.take 5
        |> Seq.sum

    // ------------------------------------------------------
    // F# Core lib solution
    // ------------------------------------------------------

    let fibonacciSeq' = 
        Seq.unfold 
            (* Generator fn *)  (fun (x1, x2) -> Some (x1 + x2, (x2, x1 + x2))) 
            (* Initial state *) (0, 1)

            // 0     1     2     3     5     8
            // Unfold parameters:
            //             x1    x2
            // Next return value:
            //                         x1+x2
            // New state:
            //                   x1'   x2'

    let fibonacciSum' =
        fibonacciSeq'
        |> Seq.filter (fun x -> x % 2 = 0)
        |> Seq.take 5
        |> Seq.sum

    printfn "LetsTranscend.fibonacciSum: %A" fibonacciSum'

// ---------------------------------------------------------------------------
// 3. Basic types
// ---------------------------------------------------------------------------

module Types =

    let a = 100
    let b = 100L
    let c = "100"

#if FSC // JS doesn't have decimal and biginteger
    let d = 100M
    let e = 100I (* BigInteger *)

    // Fermat little theorem: (a^p) mod p = p
    let p = bigint.ModPow(e, 65537I,  65537I)
    let q = bigint.Pow (e, 65537)
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
    let intList': List<int> = [for x in 1..5 -> x * x]

    printfn "Collections.rev %A" (List.rev intList)
    printfn "Collections.filter %A" (List.filter (fun i -> i % 2 = 0) intList)
    printfn "Collections.map %A" (List.map (fun i -> i * i * i) intList)
    printfn "Collections.fold %A" (List.fold (fun acc x -> acc + x) 0 intList)
    printfn "Collections.foldOp %A" (List.fold (+) 0 intList)
    printfn "Collections.sum %A" (List.sum intList)

    let intArray = [|1; 2; 3; 4; 5|]
    let intArray': int array = [|1; 2; 3; 4; 5|]

    intArray.[3] <- 20

    let intSeq = seq {
        yield 1
        yield 2
        yield 3
    }

    printfn "Collections.Seq %A" intSeq

    let mySet1 = set ["1"; "2"; "3"]
    let mySet2 = set ["2"; "3"; "4"]
    let union = Set.union mySet1 mySet2
    let intersection = Set.intersect mySet1 mySet2

module TuplesAndRecords =
    open System

    let myTuple = ("Hello", "from", "F#", DateTime.Now)

#if FSC // JS doesn't have 64-bit integer
    let result = Int64.TryParse("100")

    // C# 6 feature
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

// C# 8 feature
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

// C# 7 feature
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

#if FSC // JS doesn't have System.Exception
    let whatIsIt (x:obj) =
        match x with
        | :? string as s -> printfn "PatternMatching.whatIsIt is string (%A)" s
        | :? int as i -> printfn "PatternMatching.whatIsIt is int (%A)" i
        | :? System.Exception as e -> printfn "PatternMatching.whatIsIt is exception (%A)" e
        | _ -> printfn "PatternMatching.whatIsIt is unknown"

    whatIsIt myObj
#endif

module ActivePatterns =

    let (|IsOdd|IsEven|) n = if n % 2 = 0 then IsEven else IsOdd

    match 12 with
        | IsEven -> printfn "ActivePatterns: 12 is even"
        | IsOdd -> printfn "ActivePatterns: 12 is odd"

// ---------------------------------------------------------------------------
// 4. Functions
// ---------------------------------------------------------------------------

module FunctionsAndCurrying =

    let myfunction arg1 arg2 = arg1 + arg2
    let result = myfunction 10 20

    let add x y = x + y
    let bicrement = add 2
    let r = bicrement 10

#if FSC // JS doesn't support operator overloading
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
        [1..5] 
        |> List.map (fun x -> x * x)
        |> List.iter (printfn "Operators.|> %A")
#endif

module ControlFlow =

    let result = 
        if 2 > 3 then 
            "True" 
        else 
            "False"

    let mutable i = 0

    while i < 5 do
        printfn "ControlFlow.while:%A " i
        i <- i + 1

    for i = 1 to 5 do
        printfn "ControlFlow.for1:%A " i

    for i in [1..3..20] do
        printfn "ControlFlow.for2:%A " i

// ---------------------------------------------------------------------------
// 5. Object-oriented programming in F#
// ---------------------------------------------------------------------------

module Structs =

    type Point2D =
        struct
            val X: float
            val Y: float
            new(x, y) = { X = x; Y = y }
        end

    let myPoint2D = Point2D(2.0, 3.0)

    printfn "Structs.myPoint2D: {%A %A}" myPoint2D.X myPoint2D.Y

module Classes =

    type MyClass(x:int, y:int) = class
        let mutable mx = x
        let mutable my = y

        member this.X = mx

        member this.Y 
            with get () = my
            and set (value:int) = my <- value

        new() = MyClass(0, 0)

        new(?values) =
            let firstArg = defaultArg values 100
            let secondArg = defaultArg values 200
            MyClass(firstArg, secondArg)
    end

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

    type IInterface1 = interface
        abstract member MemberFunc1 : int -> string -> unit
    end

    type IInterface2 = (* interface-end can be omitted *)
        abstract member MemberFunc2 : int64 -> decimal

    type Derived() =
        interface IInterface1 with 
            member this.MemberFunc1 x y = ()

#if FSC // JS doesn't support decimal
        interface IInterface2 with 
            member this.MemberFunc2 z = 120M
#endif

// ---------------------------------------------------------------------------
// 6. Exception handling and raising
// ---------------------------------------------------------------------------

module Exceptions =
    // failwith -> System.Exception
    // nullArg -> System.NullArgumentException
    // invalidArg -> System.ArgumentException
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

// ---------------------------------------------------------------------------
// 7. Events
// ---------------------------------------------------------------------------

module Events =

    // F# events
    let myEvent = Event<string>()
    let publishedEvent = myEvent.Publish
    publishedEvent.Add(function t -> printfn "Events: %A" t)

    myEvent.Trigger("Data")

#if FSC // JS doesn't support CLI events
    // CLI events
    open System

    type MyEventArgs() =
        inherit EventArgs()
        override this.ToString() =
            "TYPE = MyEventArgs"

    let myCliEvent = Event<_, _>()

    [<CLIEvent>]
    let publishedCliEvent = myCliEvent.Publish

    let handler = new Handler<_>(fun (sender: obj) (args: MyEventArgs) -> printfn "Events: %A" (args.ToString()))
    publishedCliEvent.AddHandler(handler)
    
    publishedCliEvent.Add(fun args -> printfn "Events: %A" (args.ToString()))

    myCliEvent.Trigger(new Object(), new MyEventArgs())
#endif

// ---------------------------------------------------------------------------
// 8. Unit of measure
// ---------------------------------------------------------------------------

module UnitsOfMeasure =

    [<Measure>] type kg
    [<Measure>] type m
    [<Measure>] type s

    let c = 300000000L<m/s>
    let mass = 1L<kg>
    let E = mass*c*c

    printfn "UnitsOfMeasure.E: %A" E

// ---------------------------------------------------------------------------
// 9. Asynchron programming F#
// ---------------------------------------------------------------------------

module AsyncProgramming =

#if FSC // JS doesn't support System.Threading.Thread.Sleep and Async.RunSynchronously
    let myTask delay = async {
        do System.Threading.Thread.Sleep(delay * 1000)
        return 100 + delay 
    }

    [1..3]
    |> Seq.map myTask
    |> Async.Parallel
    |> Async.RunSynchronously 
    |> Seq.iter (printfn "AsyncProgramming.Result: %A")
#endif

    let counterThread =
        MailboxProcessor.Start(fun inbox ->
            let rec loop counter =
                async { 
                    do printfn "AsyncProgramming.Counter = %d, waiting..." counter
                    let! msg = inbox.Receive()
                    return! loop(counter + msg) 
                }

            // Start loop with counter = 0
            loop 0)

    counterThread.Post(5)
    counterThread.Post(-20)

// ---------------------------------------------------------------------------
// 10. Type providers
// ---------------------------------------------------------------------------

#if FSC // JS doesn't support assembly refeences and type providers
#reference "packages/FSharp.Data/lib/net40/FSharp.Data.dll"
module TypeProviders =

    open FSharp.Data

    // CSV provider
    type MyCsv = CsvProvider<"data/input.csv">

    let input = MyCsv()
    // let otherInput = MyCsv.Load(...)

    input.Headers |> printfn "TypeProviders: %A"

    input.Rows
    |> Seq.iter (fun row -> printfn "TypeProviders: %A|%A|%A" row.First row.Second row.Third)
#endif

// ---------------------------------------------------------------------------
// 11. Native interop
// ---------------------------------------------------------------------------

#if FSC // JS has different native interop solution
module NativeInteropModule =

    open System.Runtime.InteropServices

    [<DllImport("kernel32.dll", EntryPoint="Beep")>]
    extern void Beep(int32 frequency, int32 length);

    Beep(700, 1500)
#endif

// ---------------------------------------------------------------------------
// Other interesting topics: code quotations and computational expressions
// ---------------------------------------------------------------------------

#if FSC // JS doesn't support Code Quotations
module CodeQuotations =

    let myFnExpr = <@ fun x y -> x + y @>
#endif

module ComputationalExpressions =

    let divideBy bottom top =
        if bottom = 0
        then None
        else Some(top/bottom)

    let divideByWorkflow init x y z = 
        let a = init |> divideBy x
        match a with
        | None -> None  // give up
        | Some a' ->    // keep going
            let b = a' |> divideBy y
            match b with
            | None -> None  // give up
            | Some b' ->    // keep going
                let c = b' |> divideBy z
                match c with
                | None -> None  // give up
                | Some c' ->    // keep going
                    //return 
                    Some c'

    let good = divideByWorkflow 12 3 2 1
    let bad = divideByWorkflow 12 3 0 1

    type MaybeBuilder() =
        member this.Bind(x, f) = 
            match x with
            | None -> None
            | Some a -> f a
        member this.Return(x) = 
            Some x
   
    let maybe = new MaybeBuilder()

    let divideByWorkflow' init x y z = 
        maybe {
            let! a = init |> divideBy x
            let! b = a |> divideBy y
            let! c = b |> divideBy z
            return c
        }

    let good' = divideByWorkflow' 12 3 2 1
    let bad' = divideByWorkflow' 12 3 0 1    

// ----------------------------------------------------------------------------
// vim key combinations
// ----------------------------------------------------------------------------
// :FsiShow
// CTRL-w x
// CTRL-w CTRL-w
// -i -d
// ----------------------------------------------------------------------------
