[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
[<RequireQualifiedAccess>]
module GamebookGenerator.Core.Parser.Inline
open FParsec
open GamebookGenerator.Core.Ast
open GamebookGenerator.Core.Parser.Common

let plink: ParagraphId Parser =
    pstring "$" >>. pint32

let ptext: _ Parser =
    many1Satisfy (isNoneOf "$\n")

let parser: _ Parser =
    choice [
        ptext |>> Inline.Text
        plink |>> Inline.Link
    ]
