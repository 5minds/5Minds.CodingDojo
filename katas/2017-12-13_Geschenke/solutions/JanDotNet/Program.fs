

let getNextPosition symbol currentPos =
    let x, y = currentPos
    match symbol with
    | '^' -> (x, y-1)
    | 'v' | 'V' -> (x, y+1)
    | '>' -> (x+1, y)
    |  _ -> (x-1, y)


let getAllPositions line =
    let mutable positions = [(0,0)]
    for symbol in line do
        let currentPos = positions |> List.head
        let nextPos = currentPos |> (symbol |> getNextPosition)
        positions <- positions |> List.append [nextPos]
    positions


[<EntryPoint>]
let main argv = 
    let lines = System.IO.File.ReadAllLines("D:\dojo\input.txt")
    
    for line in lines do
        line 
        |> getAllPositions 
        |> List.distinct 
        |> List.length 
        |> printfn "%A"
        
    System.Console.ReadKey() |> ignore
    0 // return an integer exit code
