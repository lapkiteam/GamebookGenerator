[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
[<RequireQualifiedAccess>]
module Twine.SugarCube.FSharp.Printer.Inline

open FsharpMyExtension.Serialization.Serializers.ShowList

open Twine.SugarCube.FSharp

let shows (inline': Inline) : ShowS =
    match inline' with
    | Inline.Text text ->
        showString text
    | Inline.Link link ->
        Link.shows link
