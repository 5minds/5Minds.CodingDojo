open System

open NextBiggerNumber

[<EntryPoint>]
let main argv =
    printfn "%i" ((int64)12 |> getNextBiggerNumber)
    printfn "%i" ((int64)513 |> getNextBiggerNumber)
    printfn "%i" ((int64)2017 |> getNextBiggerNumber)
    printfn "%i" ((int64)459853 |> getNextBiggerNumber)
    printfn "%i" ((int64)59884848459853L |> getNextBiggerNumber)
    printfn "%i" ((int64)9 |> getNextBiggerNumber)
    printfn "%i" ((int64)111 |> getNextBiggerNumber)
    printfn "%i" ((int64)531 |> getNextBiggerNumber)
    0