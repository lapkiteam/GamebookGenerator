[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
[<RequireQualifiedAccess>]
module GamebookGenerator.Twine.Line
open GamebookGenerator.Core.Ast
open Twine

let toTwine (line: Line) =
    line
    |> List.map Inline.toTwine
    |> SugarCube.FSharp.Printer.Line.print
