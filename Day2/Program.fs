open System.IO

let isInvalidId (id: string) =
    let isEven = id.Length % 2 = 0
    
    if isEven then
        let mid = id.Length / 2
        let firstHalf = id.Substring(0, mid)
        let secondHalf = id.Substring(mid)
        firstHalf = secondHalf
    else
        false

let part1 (input: string) = 
    let ranges = input.Split(',')
    
    let allInvalidIds = 
        ranges
        |> Array.collect (fun (range: string) ->
            let parts = range.Trim().Split('-')
            let startNumb = int64 parts.[0]
            let _endNumb = int64 parts.[1]
            [|startNumb .. _endNumb|]
        )
        |> Array.map string
        |> Array.filter isInvalidId
    
    printfn "Invalid IDs: %A" allInvalidIds
    allInvalidIds |> Array.sumBy int64


let isInvalidIdTwo (id: string) =
    let maxPatternLength = id.Length / 2
    let mutable found = false
    
    for patternLength = 1 to maxPatternLength do
        if id.Length % patternLength = 0 then
            let pattern = id.Substring(0, patternLength)
            let repetitions = id.Length / patternLength
            let repeated = String.replicate repetitions pattern
            
            if repeated = id then
                found <- true
    
    found

let part2 (input: string) =
    let ranges = input.Split(',')
    
    let allInvalidIds = 
        ranges
        |> Array.collect (fun (range: string) ->
            let parts = range.Trim().Split('-')
            let startNumb = int64 parts.[0]
            let _endNumb = int64 parts.[1]
            [|startNumb .. _endNumb|]
        )
        |> Array.map string
        |> Array.filter isInvalidIdTwo
    
    printfn "Invalid IDs: %A" allInvalidIds
    allInvalidIds |> Array.sumBy int64

[<EntryPoint>]
let main argv =
    let line = File.ReadAllText("input.txt").Trim()
    
    let result1 = part1 line
    printfn "Part 1: %d" result1
    
    let result2 = part2 line
    printfn "Part 2: %d" result2
    0