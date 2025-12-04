open System.IO

let getLargestTwoDigitValue (line:string) =
    let mutable max: int64 = 0
    let mutable curr: int64 = 0
    for i = 0 to line.Length - 2 do
        for j = i + 1 to line.Length - 1 do
            curr <- int64 (line[i] - '0') * 10L + int64 (line[j] - '0')
            if curr > max then
                max <- curr
                printfn "line: %s, i: %d, j: %d, curr:%d" line i j curr
    max


let getLargestSequence (line:string) =
    let mutable numbersToPick = 12
    let mutable startIndex = 0
    let mutable result = System.Text.StringBuilder()
    while numbersToPick > 0 do
        let endIndex = line.Length - numbersToPick
        let mutable maxNumber = '0'
        let mutable maxPos = startIndex
        for i = startIndex to endIndex do
            if line[i] > maxNumber then
                maxNumber <- line[i]
                maxPos <- i
        result.Append(maxNumber) |> ignore

        startIndex <- maxPos + 1
        numbersToPick <- numbersToPick - 1
    result.ToString()

let part1 (lines: string[]) = 
    let largestValues =
        lines
        |> Array.map getLargestTwoDigitValue
        
    printfn "Largest values: %A" largestValues
    largestValues |> Array.sumBy int64 

let part2 (lines: string[]) = 
    let largestValues =
        lines
        |> Array.map getLargestSequence

    printfn "Largest values: %A" largestValues
    largestValues |> Array.sumBy int64 


[<EntryPoint>]
let main argv =
    let lines = File.ReadAllLines("input.txt")

    let result1 = part1 lines
    printfn "Result part1: %d" result1

    let result2 = part2 lines
    printfn "Result part2: %d" result2
    0
