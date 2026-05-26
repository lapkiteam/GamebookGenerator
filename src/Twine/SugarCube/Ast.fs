namespace Twine.SugarCube.FSharp
open Twee.FSharp

type Link = {
    Text: string
    PassageName: PassageName
}

[<RequireQualifiedAccess>]
type Inline =
    | Text of string
    | Link of Link
