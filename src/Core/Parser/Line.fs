[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
[<RequireQualifiedAccess>]
module GamebookGenerator.Core.Parser.Line
open FParsec

open GamebookGenerator.Core.Ast
open GamebookGenerator.Core.Parser
open GamebookGenerator.Core.Parser.Common

let parser: Line Parser =
    notFollowedByString "$"
    >>. many1 Inline.parser
