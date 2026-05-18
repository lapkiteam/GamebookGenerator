module GamebookGenerator.Lib.Tests
open Expecto

[<Tests>]
let ``Lib.hello`` =
    testList "Lib.hello" [
        testCase "world" <| fun () ->
            Expect.equal
                (hello "World")
                "Hello, World!"
                ""
    ]
