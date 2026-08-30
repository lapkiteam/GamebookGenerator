namespace GamebookGenerator.Core

type ParagraphId = int

[<RequireQualifiedAccess>]
type Inline =
    | Text of string
    | Link of ParagraphId

type Line = Inline list

type ParagraphBody = Line list

type Paragraph = {
    Id: ParagraphId
    Title: string
    Content: ParagraphBody
}

type Document = {
    Intro: ParagraphBody
    Paragraphs: Paragraph list
}
