module IsPalindromTests

open System
open Xunit

open Palindrome

[<Fact>]
let ``abba is palindrome`` () =
    Assert.True (isPalindrome "abba")

[<Fact>]
let ``Abba is palindrome`` () =
    Assert.True (isPalindrome "Abba")

[<Fact>]
let ``abbaa is not palindrome`` () =
    Assert.False (isPalindrome "abbaa")

[<Fact>]
let ``Lagerregal is palindrome`` () =
    Assert.True (isPalindrome "Lagerregal")

[<Fact>]
let ``Reliefpfeiler is palindrome`` () =
    Assert.True (isPalindrome "Reliefpfeiler")

[<Fact>]
let ``Rentner is palindrome`` () =
    Assert.True (isPalindrome "Rentner")

[<Fact>]
let ``Dienstmannamtsneid is palindrome`` () =
    Assert.True (isPalindrome "Dienstmannamtsneid")
