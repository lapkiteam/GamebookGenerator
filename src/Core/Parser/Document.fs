[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
[<RequireQualifiedAccess>]
module GamebookGenerator.Core.Parser.Document
open FParsec
open FsharpMyExtension.Serialization.Deserializers.FParsec

open GamebookGenerator.Core
open GamebookGenerator.Core.Parser
open GamebookGenerator.Core.Parser.Common

let parser: Document Parser =
    pipe2
        (Paragraph.plines .>> spaces)
        (many (Paragraph.parser .>> spaces))
        (fun intro paragraphs ->
            {
                Intro = intro
                Paragraphs = paragraphs
            })
    .>> spaces .>> eof

let parse =
    run parser >> ParserResult.toResult

let parseFile path =
    runParserOnFile parser () path System.Text.Encoding.UTF8
    |> ParserResult.toResult
