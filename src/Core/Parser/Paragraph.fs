[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
[<RequireQualifiedAccess>]
module GamebookGenerator.Core.Parser.Paragraph
open FParsec

open GamebookGenerator.Core
open GamebookGenerator.Core.Parser
open GamebookGenerator.Core.Parser.Common

let pheader: (ParagraphId * string) Parser =
    tuple2
        (Inline.plink .>> skipChar '.' .>> inlineSpaces)
        (manySatisfy ((<>) '\n'))

let plines: Line list Parser =
    many (
        Line.parser .>> (skipNewline <|> eof)
    )

let parser: Paragraph Parser =
    pipe2
        (pheader .>> spaces)
        plines
        (fun (id, title) lines ->
            {
                Id = id
                Title = title
                Content = lines
            })
