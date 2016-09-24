let rec myMap f l =
    match l with
    | [] -> []
    | x :: xs -> f x :: myMap f xs

let rec myFilter f l =
    match l with
    | [] -> []
    | x :: xs -> if f x then x :: myFilter f xs else myFilter f xs