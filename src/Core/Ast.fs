namespace GamebookGenerator.Core

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
    Intro: Line list
    Paragraphs: Paragraph list
}
