[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
[<RequireQualifiedAccess>]
module GamebookGenerator.Core.Parser.Line
open FParsec

open GamebookGenerator.Core
open GamebookGenerator.Core.Parser
open GamebookGenerator.Core.Parser.Common

let pemptyText: Line Parser =
    followedByNewline >>% [Inline.Text ""]

let parser: Line Parser =
    choice [
        notFollowedByString paragraphChar >>. many1 Inline.parser
        pemptyText
    ]
