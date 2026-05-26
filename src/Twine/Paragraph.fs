[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
[<RequireQualifiedAccess>]
module GamebookGenerator.Twine.Paragraph
open GamebookGenerator.Core

let toTwine (paragraph: Paragraph) =
    let header: Twee.FSharp.PassageHeader = {
        Name = string paragraph.Id
        Tags = None
        Metadata = None
    }
    let body: Twee.FSharp.PassageBody =
        [
            paragraph.Title
            yield! paragraph.Content |> List.map Line.toTwine
        ]
    let passage: Twee.FSharp.Passage = {
        Header = header
        Body = body
    }
    passage
