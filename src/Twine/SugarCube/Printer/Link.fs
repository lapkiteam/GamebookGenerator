[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
[<RequireQualifiedAccess>]
module Twine.SugarCube.FSharp.Printer.Link
open FsharpMyExtension.Serialization.Serializers.ShowList

open Twine.SugarCube.FSharp

let shows (link: Link) =
    between
        (showString "[[")
        (showString "]]")
        (
            showString link.Text << (
                match link.PassageName with
                | None ->
                    empty
                | Some passageName ->
                    showChar '|' << showString passageName
            )
        )
