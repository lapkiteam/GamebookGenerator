[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
[<RequireQualifiedAccess>]
module GamebookGenerator.Twine.ParagraphBody
open GamebookGenerator.Core
open Twine.SugarCube.FSharp
open Twine.SugarCube.FSharp.Helpers

let toTwine paragraphTitleOption (paragraphBody: ParagraphBody) : PassageBody =
    [
        match paragraphTitleOption with
        | Some paragraphTitle ->
            line [text paragraphTitle]
        | None -> ()

        yield! paragraphBody |> List.map Line.toTwine
    ]
