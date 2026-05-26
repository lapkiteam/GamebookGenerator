[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
[<RequireQualifiedAccess>]
module GamebookGenerator.Twine.Paragraph
open GamebookGenerator.Core.Ast
open Twine

let linesToTwine (lines: Line list) =
    lines
    |> List.collect (
        Line.toTwine
        >> fun x -> [x; ""]
    )

let toTwine (paragraph: Paragraph) =
    let header: Twee.FSharp.PassageHeader = {
        Name = string paragraph.Id
        Tags = None
        Metadata = None
    }
    let body: Twee.FSharp.PassageBody =
        [
            // paragraph.Title
            yield! linesToTwine paragraph.Content
        ]
    let passage: Twee.FSharp.Passage = {
        Header = header
        Body = body
    }
    passage
