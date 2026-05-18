namespace GamebookGenerator.Core.Ast

[<RequireQualifiedAccess>]
type Content =
    | Text of string
    | Link of string

type Paragraph = {
    Title: string
    Content: Content
}

type Document = {
    Intro: string
    Paragraphs: Paragraph list
}
