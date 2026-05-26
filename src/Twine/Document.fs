[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
[<RequireQualifiedAccess>]
module GamebookGenerator.Twine.Document
open GamebookGenerator.Core.Ast
open Twine
open GamebookGenerator.Core.Ast.Helpers

let introToTwine (startParagraphId: ParagraphId option) (intro: list<Line>) =
    let header: Twee.FSharp.PassageHeader = {
        Name = "Start"
        Tags = None
        Metadata = None
    }
    let body: Twee.FSharp.PassageBody =
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
    let passage: Twee.FSharp.Passage = {
        Header = header
        Body = body
    }
    passage

let toTwine (document: Document): Twee.FSharp.Document =
    let firstParagraph =
        List.tryHead document.Paragraphs
        |> Option.map (fun x -> x.Id)
    [
        introToTwine firstParagraph document.Intro
        yield! document.Paragraphs |> List.map Paragraph.toTwine
    ]
