namespace GamebookGenerator.Core.Ast

type ParagraphId = int

[<RequireQualifiedAccess>]
type Inline =
    | Text of string
    | Link of ParagraphId

type Line = Inline list

type Paragraph = {
    Id: ParagraphId
    Title: string
    Content: Line list
}

type Document = {
    Intro: string
    Paragraphs: Paragraph list
}
