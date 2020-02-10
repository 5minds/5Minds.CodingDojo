open Palindrome

[<EntryPoint>]
let main argv =
    let text = "Ein agiler Hit reizt sie. Geist?! Biertrunk nur treibt sie. Geist ziert ihre Liga nie!"
    printfn "%b" (text |> isPalindromSentence)
    0
