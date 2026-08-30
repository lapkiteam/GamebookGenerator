[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
[<RequireQualifiedAccess>]
module GamebookGenerator.Twine.Inline
open GamebookGenerator.Core
open GamebookGenerator.Core.Parser.Common
open Twine

let toTwine (inline': Inline) =
    match inline' with
    | Inline.Link paragraphId ->
        SugarCube.FSharp.Inline.Link {
            Text = "turnto" // todo: make option to `sprintf "$%d" paragraphId`
            PassageName = string paragraphId |> Some
        }
    | Inline.Text text ->
        SugarCube.FSharp.Inline.Text text
