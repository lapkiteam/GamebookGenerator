[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
[<RequireQualifiedAccess>]
module GamebookGenerator.Twine.Inline
open GamebookGenerator.Core.Ast

let toTwine (inline': Inline) =
    match inline' with
    | Inline.Link paragraphId ->
        Twee.FSharp.PassageBody.Empty
