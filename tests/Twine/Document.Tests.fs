module GamebookGenerator.Twine.Document.Tests
open Expecto
open GamebookGenerator.Core.Ast.Helpers

[<Tests>]
let ``Twine.Document.toTwine`` =
    testList "Twine.Document.toTwine" [
        testCase "base" <| fun () ->
            Expect.equal
                (toTwine {
                    Intro = []
                    Paragraphs = [
                        {
                            Id = 1
                            Title = "Первый параграф"
                            Content = [
                                [text "Пойти налево — "; link 1; text ", Пойти направо — "; link 2]
                            ]
                        }
                    ]
                })
                [
                    {
                        Header = {
                            Name = "Start"
                            Tags = None
                            Metadata = None
                        }
                        Body = [
                            "Начать — [[$1|1]]."
                        ]
                    }
                    {
                        Header = {
                            Name = "1"
                            Tags = None
                            Metadata = None
                        }
                        Body = [
                            "Первый параграф"
                            "Пойти налево — [[$1|1]], Пойти направо — [[$2|2]]"
                        ]
                    }
                ]
                ""
    ]
