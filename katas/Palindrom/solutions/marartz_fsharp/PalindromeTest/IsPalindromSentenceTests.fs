module IsPalindromSentenceTests

open System
open Xunit

open Palindrome

[<Fact>]
let ``Tarne nie deinen Rat! is palindrome sentence`` () =
    Assert.True (isPalindromSentence "Tarne nie deinen Rat!")

[<Fact>]
let ``Tarne niee deinen Rat! is not palindrome sentence`` () =
    Assert.False (isPalindromSentence "Tarne niee deinen Rat!")

[<Fact>]
let ``Eine güldne, gute Tugend: Lüge nie! is palindrome sentence`` () =
    Assert.True (isPalindromSentence "Eine güldne, gute Tugend: Lüge nie!")

[<Fact>]
let ``Ein agiler Hit reizt sie. Geist?! Biertrunk nur treibt sie. Geist ziert ihre Liga nie! is palindrome sentence`` () =
    Assert.True (isPalindromSentence "Ein agiler Hit reizt sie. Geist?! Biertrunk nur treibt sie. Geist ziert ihre Liga nie!")
