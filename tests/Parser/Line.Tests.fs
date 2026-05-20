module GamebookGenerator.Core.Parser.Line.Tests
open Expecto
open FsharpMyExtension.Serialization.Deserializers.FParsec

open GamebookGenerator.Core.Ast.Helpers

[<Tests>]
let ``Parser.Line.parser`` =
    let parser = GamebookGenerator.Core.Parser.Line.parser
    testList "Parser.Line.parser" [
        testCase "multiline text" <| fun () ->
            Expect.equal
                (runResult parser <| String.concat System.Environment.NewLine [
                    "Пойти налево — $1, Пойти направо — $2"
                    "Перекусить — $3"
                ])
                (Ok [
                    text "Пойти налево — "
                    link 1
                    text ", Пойти направо — "
                    link 2
                ])
                ""
        testCase "$24" <| fun () ->
            Expect.equal
                (runResult parser "$24")
                (Error <| String.concat System.Environment.NewLine [
                    "Error in Ln: 1 Col: 1"
                    "$24"
                    "^"
                    "Expecting: newline"
                    "Unexpected: '$'"
                    ""
                ])
                ""
        testCase "empty"  <| fun () ->
            Expect.equal
                (runResult parser "\n")
                (Ok [text ""])
                ""
    ]
