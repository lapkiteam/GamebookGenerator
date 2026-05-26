[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
[<RequireQualifiedAccess>]
module GamebookGenerator.Twine.Document
open GamebookGenerator.Core.Ast
open Twine

let introToTwine (intro: list<Line>) =
    let header: Twee.FSharp.PassageHeader = {
        Name = "Start"
        Tags = None
        Metadata = None
    }
    let body: Twee.FSharp.PassageBody =
        intro |> List.map Line.toTwine
    let passage: Twee.FSharp.Passage = {
        Header = header
        Body = body
    }
    passage

let toTwine (document: Document): Twee.FSharp.Document =
    [
        introToTwine document.Intro
        yield! document.Paragraphs |> List.map Paragraph.toTwine
    ]
