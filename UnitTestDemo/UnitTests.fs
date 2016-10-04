namespace UnitTestDemo

open NUnit.Framework

type SmallRecord = {
    Name: string
    Value: int option
}

type UnitTestClass() = 
    let areEqual x y = Assert.AreEqual(x, y)

    [<Test>]
    member this.``This is the first test`` () =
        [1..5]
        |> areEqual [1; 2; 3; 4; 5]

    [<Test>]
    member this.``Structural equality test`` () =
        { Name = "My little record"; Value = Some 200 }
        |> areEqual { Name = "My little record"; Value = Some 200 }
