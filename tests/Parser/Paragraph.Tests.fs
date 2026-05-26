module GamebookGenerator.Core.Parser.Paragraph.Tests
open Expecto
open FsharpMyExtension.Serialization.Deserializers.FParsec

open GamebookGenerator.Core.Ast.Helpers

[<Tests>]
let ``Parser.Line.pheader`` =
    testList "Parser.Line.pheader" [
        testCase "base" <| fun () ->
            Expect.equal
                (runResult pheader
                    "§27.  Параграф такой-то")
                (Ok (27, "Параграф такой-то"))
                ""
    ]

[<Tests>]
let ``Parser.Line.plines`` =
    testList "Parser.Line.plines" [
        testCase "base" <| fun () ->
            Expect.equal
                (runResult plines <| String.concat System.Environment.NewLine [
                    "Первая строка"
                    ""
                    " Строка вторая"
                    ""
                    "§10. Новый параграф"
                ])
                (Ok [
                    [text "Первая строка"]
                    [text ""]
                    [text " Строка вторая"]
                    [text ""]
                ])
                ""
    ]
