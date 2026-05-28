[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
[<RequireQualifiedAccess>]
module GamebookGenerator.Twine.ParagraphBody
open GamebookGenerator.Core
open Twine

let toTwine (paragraphBody: ParagraphBody) : SugarCube.FSharp.PassageBody =
    paragraphBody
    |> List.map Line.toTwine
