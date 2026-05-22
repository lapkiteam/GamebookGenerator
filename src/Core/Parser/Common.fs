module GamebookGenerator.Core.Parser.Common
open FParsec

type 'a Parser = Parser<'a, unit>

let inlineSpaces: _ Parser =
    skipManySatisfy (isAnyOf " \t")
