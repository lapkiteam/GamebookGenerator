[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
[<RequireQualifiedAccess>]
module GamebookGenerator.Twine.ParagraphBody
open GamebookGenerator.Core
open Twine.SugarCube.FSharp
open Twine.SugarCube.FSharp.Helpers

let toTwine paragraphTitle (paragraphBody: ParagraphBody) : PassageBody =
    [
        line [text paragraphTitle]
        yield! paragraphBody |> List.map Line.toTwine
    ]
