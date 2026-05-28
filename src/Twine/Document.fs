[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
[<RequireQualifiedAccess>]
module GamebookGenerator.Twine.Document
open GamebookGenerator.Core
open GamebookGenerator.Core.Helpers

let introToTwine (startParagraphId: ParagraphId option) (intro: list<Line>) =
    let header: Twine.Twee.FSharp.PassageHeader = {
        Name = "Start"
        Tags = None
        Metadata = None
    }
    let body: Twine.Twee.FSharp.PassageBody =
        [
            yield! intro |> List.map Line.toTwine

            match startParagraphId with
            | Some startParagraphId ->
                Line.toTwine (line [
                    text "Начать — "
                    link startParagraphId
                    text "."
                ])
            | None -> ()
        ]
    let passage: Twine.Twee.FSharp.Passage<_> = {
        Header = header
        Body = body
    }
    passage

let toTwine (document: Document): Twine.Twee.FSharp.Document<_> =
    let firstParagraph =
        List.tryHead document.Paragraphs
        |> Option.map (fun x -> x.Id)
    [
        introToTwine firstParagraph document.Intro
        yield! document.Paragraphs |> List.map Paragraph.toTwine
    ]
