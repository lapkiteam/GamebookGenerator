namespace Twine.SugarCube.FSharp
open Twine.Twee.FSharp

type Link = {
    Text: string
    PassageName: PassageName option
}

[<RequireQualifiedAccess>]
type Inline =
    | Text of string
    | Link of Link

type Line = Inline list

type PassageBody = Line list
