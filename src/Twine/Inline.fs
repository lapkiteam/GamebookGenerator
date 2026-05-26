[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
[<RequireQualifiedAccess>]
module GamebookGenerator.Twine.Inline
open GamebookGenerator.Core.Ast
open Twine

let toTwine (inline': Inline) =
    match inline' with
    | Inline.Link paragraphId ->
        SugarCube.FSharp.Inline.Link {
            Text = sprintf "$%d" paragraphId
            PassageName = string paragraphId |> Some
        }
    | Inline.Text text ->
        SugarCube.FSharp.Inline.Text text
