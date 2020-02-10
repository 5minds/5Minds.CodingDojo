module NextBiggerNumberTests

open Xunit

open NextBiggerNumber

[<Fact>]
let ``12 => 21`` () =
    Assert.True((getNextBiggerNumber 12L) = 21L)

[<Fact>]
let ``513 => 531`` () =
    Assert.True((getNextBiggerNumber 513L) = 531L)

[<Fact>]
let ``2017 => 2071`` () =
    Assert.True((getNextBiggerNumber 2017L) = 2071L)

[<Fact>]
let ``459853 => 21`` () =
    Assert.True((getNextBiggerNumber 459853L) = 483559L)

[<Fact>]
let ``59884848459853 => 59884848483559`` () =
    Assert.True((getNextBiggerNumber 59884848459853L) = 59884848483559L)

[<Fact>]
let ``9 => -1`` () =
    Assert.True((getNextBiggerNumber 9L) = -1L)

[<Fact>]
let ``111 => -1`` () =
    Assert.True((getNextBiggerNumber 111L) = -1L)

[<Fact>]
let ``531 => -1`` () =
    Assert.True((getNextBiggerNumber 531L) = -1L)
