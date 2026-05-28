[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
[<RequireQualifiedAccess>]
module GamebookGenerator.Twine.Paragraph
open GamebookGenerator.Core
open Twine.Twee.FSharp

let toTwine (paragraph: Paragraph) =
    let header: PassageHeader = {
        Name = string paragraph.Id
        Tags = None
        Metadata = None
    }
    let passage: Passage<_> = {
        Header = header
        Body =
            ParagraphBody.toTwine paragraph.Title paragraph.Content
    }
    passage
