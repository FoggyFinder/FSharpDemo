val myMap : mapperFunction: ('T -> 'TResult) -> inputList: 'T list -> 'TResult list
val myFilter : filterFunction: ('T -> bool) -> inputList:' T list -> 'T list
val myReduce : reduceFunction: (int -> 'a -> int) -> inputList: 'a list -> int