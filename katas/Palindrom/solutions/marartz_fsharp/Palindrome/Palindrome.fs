module Palindrome

open System

let isLetterOrDigit (c: char): bool = Char.IsLetterOrDigit(c)

let removeSpecialChars (text: string): string = text |> (Seq.filter isLetterOrDigit) |> String.Concat

let textLen (text: string): int = text.Length
let firstChar (text: string): char = text.Chars(0)
let lastChar (text: string): char = text.Chars(text.Length - 1)
let loweredChar (c: char): char = Char.ToLower c
let isCharEqual (a: char) (b: char) = a.CompareTo(b) = 0
let reduceText (text: string): string = text.Substring(1, text.Length - 2)

let isLoweredFirstAndLastCharEqual (text: string): bool = isCharEqual (text |> firstChar |> loweredChar) (text |> lastChar |> loweredChar)

let rec isPalindrome (text: string): bool =
    (textLen text) < 2 || (text |> isLoweredFirstAndLastCharEqual && text |> reduceText |> isPalindrome)

let isPalindromSentence (text: string): bool =
    text |> removeSpecialChars |> isPalindrome