let rec myMap mapperFunction inputList =
    match inputList with
    | [] -> []
    | x :: xs -> mapperFunction x :: myMap mapperFunction xs

let rec myFilter filterFunction inputList =
    match inputList with
    | [] -> []
    | x :: xs -> if filterFunction x then x :: myFilter filterFunction xs 
                    else myFilter filterFunction xs

let rec myReduce reduceFunction inputList =
    let rec myReduceInner reduceFunction a inputList =
        match inputList with
        | [] -> a
        | x :: xs ->
            let a' = reduceFunction a x
            myReduceInner reduceFunction a' xs

    myReduceInner reduceFunction 0 inputList

// myReduce (fun a v -> a + v) [1;2;3;4;5]
myReduce (+) [1;2;3;4;5]
