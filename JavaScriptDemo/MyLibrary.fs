namespace JavaScriptDemo

module MyLibrary =
    let fibonacciSeq = 
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

    let fibonacciSum () =
        fibonacciSeq
        |> Seq.filter (fun x -> x % 2 = 0)
        |> Seq.take 5
        |> Seq.sum

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
