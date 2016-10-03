var myLibrary = require("./MyLibrary.js")

var fs = myLibrary.fibonacciSum()
console.log("Fibonaccí sum: " + fs)

var myObj = new myLibrary.MyClass(10, 20)
console.log("MyClass.X = ", myObj.X)
console.log("MyClass.Y = ", myObj.Y)