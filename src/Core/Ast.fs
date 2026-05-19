namespace GamebookGenerator.Core.Ast

[<RequireQualifiedAccess>]
type Content =
    | Text of string
    | Link of int

type Paragraph = {
    Title: string
    Content: Content
}

type Document = {
    Intro: string
    Paragraphs: Paragraph list
}
