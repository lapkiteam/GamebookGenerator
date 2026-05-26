module Twine.SugarCube.FSharp.Printer.Line.Tests
open Expecto
open FsharpMyExtension.Serialization.Serializers.ShowList

open Twine.SugarCube.FSharp
open Twine.SugarCube.FSharp.Printer

[<Tests>]
let ``Printer.Line.shows`` =
    let print = Line.shows >> show
    testList "Printer.Line.show" [
        testCase "base" <| fun () ->
            Expect.equal
                (print [
                    Inline.Text "Ты подходишь к "
                    Inline.Link {
                        Text = "Джону"
                        PassageName = Some "Джон"
                    }
                    Inline.Text "."
                ])
                "Ты подходишь к [[Джону|Джон]]."
                ""
    ]
