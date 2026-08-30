module GamebookGenerator.Twine.Document.Tests
open Expecto
open GamebookGenerator.Core.Helpers

module SugarCube = Twine.SugarCube.FSharp.Helpers

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
                            SugarCube.line [
                                SugarCube.text "Начать — "
                                SugarCube.link {
                                    Text = "§1"
                                    PassageName = Some "1"
                                }
                                SugarCube.text "."
                            ]
                        ]
                    }
                    {
                        Header = {
                            Name = "1"
                            Tags = None
                            Metadata = None
                        }
                        Body = [
                            SugarCube.line [
                                SugarCube.text "Первый параграф"
                            ]
                            SugarCube.line [
                                SugarCube.text "Пойти налево — "
                                SugarCube.link {
                                    Text = "§1"
                                    PassageName = Some "1"
                                }
                                SugarCube.text ", Пойти направо — "
                                SugarCube.link {
                                    Text = "§2"
                                    PassageName = Some "2"
                                }
                            ]
                        ]
                    }
                ]
                ""
    ]
