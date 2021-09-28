// Learn more about F# at http://fsharp.org
open System

let alphabet = ['a'..'z']

// check if input conatins all alphabet letters
let isPangram (input: string) = 
    alphabet |> Seq.forall (fun x -> input.Contains x)

// min/max value of snd from tuple list
let minY = Seq.map snd >> Seq.min
let maxY = Seq.map snd >> Seq.max

// check for type of pangram
let pangramCheck (input: string) = 
    if isPangram input <> true then 0
    else
        // group by char and calculate count
        let grouped = input |> Seq.countBy id
        let minCount = minY grouped
        let maxCount = maxY grouped
        
        if      minCount = 1 && maxCount = 1 then 1
        else if minCount = 1 && maxCount > 1 then 2
        else if minCount > 1 && maxCount > 1 then 3
        else 4

[<EntryPoint>]
let main argv =
    printfn "Please enter the sentence to check for a pangram:"
    let input = Console.ReadLine()
    let test = input.ToLower() |> pangramCheck
    
    let message = 
        if      test = 1 then "contains all alphabet letters exactly once."
        else if test = 2 then "contains all alphabet letters at least once."
        else if test = 3 then "contains all alphabet letters more than once."
        else "does not contain all alphabet letters at least once."
    
    printfn "\"%s\" %s" input message
    0 // return an integer exit code
