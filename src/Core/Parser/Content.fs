[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
[<RequireQualifiedAccess>]
module GamebookGenerator.Core.Parser.Content
open FParsec
open GamebookGenerator.Core.Ast
open GamebookGenerator.Core.Parser.Common

let plink: _ Parser =
    pstring "$" >>. pint32

let ptext: _ Parser =
    many1Satisfy ((<>) '$')

let parser: _ Parser =
    choice [
        ptext |>> Content.Text
        plink |>> Content.Link
    ]
