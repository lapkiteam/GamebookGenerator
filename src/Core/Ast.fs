namespace GamebookGenerator.Core.Ast

[<RequireQualifiedAccess>]
type Inline =
    | Text of string
    | Link of int

type Paragraph = {
    Title: string
    Content: Inline list
}

type Document = {
    Intro: string
    Paragraphs: Paragraph list
}
