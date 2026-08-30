[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
[<RequireQualifiedAccess>]
module Twine.SugarCube.FSharp.Printer.PassageBody
open FsharpMyExtension.Serialization.Serializers.ShowList
open Twine.Twee.FSharp.Printer

open Twine.SugarCube.FSharp

let shows newlineType (passageBody: PassageBody) =
    let newline =
        showString <| NewlineType.toString newlineType
    passageBody
    |> List.map Line.shows
    |> joinsEmpty newline
