module Twine.SugarCube.FSharp.Printer.Link.Tests
open Expecto
open FsharpMyExtension.Serialization.Serializers.ShowList

open Twine.SugarCube.FSharp.Printer

[<Tests>]
let ``Printer.Link.shows`` =
    let print = Link.shows >> show
    testList "Printer.Link.show" [
        testCase "just text" <| fun () ->
            Expect.equal
                (print {
                    Text = "Ударить"
                    PassageName = None
                })
                "[[Ударить]]"
                ""
        testCase "with explicit transition" <| fun () ->
            Expect.equal
                (print {
                    Text = "Ударить"
                    PassageName = Some "attack"
                })
                "[[Ударить|attack]]"
                ""
    ]
