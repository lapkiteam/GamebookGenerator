[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
[<RequireQualifiedAccess>]
module GamebookGenerator.Core.Parser.Inline
open FParsec
open GamebookGenerator.Core
open GamebookGenerator.Core.Parser.Common

let plink: ParagraphId Parser =
    pstring paragraphChar >>. pint32

let ptext: _ Parser =
    many1Satisfy (isNoneOf $"{paragraphChar}\n")

let parser: _ Parser =
    choice [
        ptext |>> Inline.Text
        plink |>> Inline.Link
    ]
