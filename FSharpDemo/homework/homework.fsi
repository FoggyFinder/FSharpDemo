// --------------------------------------------------------------------
// Baby level
// --------------------------------------------------------------------

val myMap : mapperFunction: ('T -> 'TResult) -> inputList: 'T list -> 'TResult list

// [0..5]
// |> myMap (fun x -> x * 3)
// |> areEqual [0; 3; 6; 9; 12; 15]

// --------------------------------------------------------------------
// Intermediate level
// --------------------------------------------------------------------

val myFilter : filterFunction: ('T -> bool) -> inputList: 'T list -> 'T list

// [0..20]
// |> myFilter (fun x -> x % 3 = 0)
// |> areEqual [0; 3; 6; 9; 12; 15; 18]

// --------------------------------------------------------------------
// Superhero level
// --------------------------------------------------------------------

val myReduce : reduceFunction: ('TAcc -> 'T -> 'TAcc') -> initialValue: 'TAcc -> inputList: 'T list -> 'TAcc

// [0..5]
// |> myReduce (fun a v -> a + v) 10
// |> areEqual 25

// [1;2;3;4;5]
// |> myReduce (*) 1
// |> areEqual 120