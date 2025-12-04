open System.IO

let part1 input = 
    200


[<EntryPoint>]
let main argv =
    let line = File.ReadAllText("test.txt").Trim()

    let result1 = part1 line
    printfn "Result part1: %d" result1
    0
