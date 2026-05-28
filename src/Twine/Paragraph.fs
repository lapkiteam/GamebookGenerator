[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
[<RequireQualifiedAccess>]
module GamebookGenerator.Twine.Paragraph
open GamebookGenerator.Core
open Twine.Twee.FSharp
open Twine.SugarCube.FSharp
open Twine.SugarCube.FSharp.Helpers

let toTwine (paragraph: Paragraph) =
    let header: PassageHeader = {
        Name = string paragraph.Id
        Tags = None
        Metadata = None
    }
    let body: PassageBody =
        [
            line [text paragraph.Title]

            yield! paragraph.Content |> List.map Line.toTwine
        ]
    let passage: Passage<_> = {
        Header = header
        Body = body
    }
    passage
