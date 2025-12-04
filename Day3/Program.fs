open System.IO

let getLargestTwoDigitValue (line:string) =
    99

let part1 (lines: string[]) = 
    let largestValues =
        lines
        |> Array.map getLargestTwoDigitValue
        
    printfn "Largest values: %A" largestValues
    largestValues |> Array.sumBy int64 

let part2 (input: string[]) = 2000


[<EntryPoint>]
let main argv =
    let lines = File.ReadAllLines("test.txt")

    let result1 = part1 lines
    printfn "Result part1: %d" result1

    let result2 = part2 lines
    printfn "Result part1: %d" result2
    0
