[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
[<RequireQualifiedAccess>]
module GamebookGenerator.Twine.Paragraph
open GamebookGenerator.Core

let toTwine (paragraph: Paragraph) =
    let header: Twine.Twee.FSharp.PassageHeader = {
        Name = string paragraph.Id
        Tags = None
        Metadata = None
    }
    let body: Twine.Twee.FSharp.PassageBody =
        [
            paragraph.Title
            yield! paragraph.Content |> List.map Line.toTwine
        ]
    let passage: Twine.Twee.FSharp.Passage<_> = {
        Header = header
        Body = body
    }
    passage
