[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
[<RequireQualifiedAccess>]
module Twine.SugarCube.FSharp.Printer.Line
open FsharpMyExtension.Serialization.Serializers.ShowList

open Twine.SugarCube.FSharp

let shows (line: Line) =
    line
    |> List.map Inline.shows
    |> joinsEmpty empty

let print line =
    show (shows line)
