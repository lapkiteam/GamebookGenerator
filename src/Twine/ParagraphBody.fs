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

        line [text ""]

        yield!
            paragraphBody
            |> List.map (fun line ->
                let line = Line.toTwine line
                line @ [text "<br>"]
            )
    ]
