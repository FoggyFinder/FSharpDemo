#r @"../packages/NUnit/lib/net45/nunit.Framework.dll"
open NUnit.Framework

let areEqual x y = Assert.AreEqual(x, y)

// --------------------------------------------------------------------
// Map
// --------------------------------------------------------------------

let rec myMap mapperFunction inputList =
    match inputList with
    | [] -> []
    | x :: xs -> (mapperFunction x) :: (myMap mapperFunction xs)

[0..5]
|> myMap (fun x -> x * 3)
|> areEqual [0; 3; 6; 9; 12; 15]

// --------------------------------------------------------------------
// Filter
// --------------------------------------------------------------------

let rec myFilter filterFunction inputList =
    match inputList with
    | [] -> []
    | x :: xs -> if filterFunction x then x :: myFilter filterFunction xs 
                    else myFilter filterFunction xs

[0..20]
|> myFilter (fun x -> x % 3 = 0)
|> areEqual [0; 3; 6; 9; 12; 15; 18]

// --------------------------------------------------------------------
// Reduce
// --------------------------------------------------------------------

let rec myReduce reduceFunction initialValue inputList =
    let rec myReduceInner reduceFunction accumulator inputList =
        match inputList with
        | [] -> accumulator
        | x :: xs ->
            let accumulator' = reduceFunction accumulator x
            myReduceInner reduceFunction accumulator' xs

    myReduceInner reduceFunction initialValue inputList

[0..5]
|> myReduce (fun a v -> a + v) 10
|> areEqual 25

[1;2;3;4;5]
|> myReduce (*) 1
|> areEqual 120