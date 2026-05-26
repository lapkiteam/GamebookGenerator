module GamebookGenerator.Core.Parser.Inline.Tests
open Expecto
open FsharpMyExtension.Serialization.Deserializers.FParsec

open GamebookGenerator.Core.Ast

[<Tests>]
let ``Parser.Content.ptext`` =
    testList "Parser.Content.ptext" [
        testCase "multiline text" <| fun () ->
            Expect.equal
                (runResult ptext <| String.concat System.Environment.NewLine [
                    "Ты стоишь на развилке."
                    "Пойти налево — §1"
                    "Пойти направо — §2"
                ])
                (Ok "Ты стоишь на развилке.")
                ""
        testCase "with §" <| fun () ->
            Expect.equal
                (runResult ptext
                    "Пойти налево — §1"
                )
                (Ok "Пойти налево — ")
                ""
    ]

[<Tests>]
let ``Parser.Content.plink`` =
    testList "Parser.Content.plink" [
        testCase "link" <| fun () ->
            Expect.equal
                (runResult plink "§1")
                (Ok 1)
                ""
    ]
