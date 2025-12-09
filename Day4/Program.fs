module Day4.Program
open System.IO

let getNeighborCount (grid: char[][]) (row, col) targetChar =
    [ for dirRow in -1..1 do
        for dirCol in -1..1 do
            if not (dirRow = 0 && dirCol = 0) then
                let neighRow, neightCol = row + dirRow, col + dirCol
                if neighRow >= 0 && neighRow < grid.Length && neightCol >= 0 && neightCol < grid.[0].Length then
                    if grid.[neighRow].[neightCol] = targetChar then yield 1 ]
    |> List.sum

let isValidSpot (grid: char[][]) (row, col) =
    grid.[row].[col] = '@' && getNeighborCount grid (row, col) '@' < 4

let findValidSpots (grid: char[][]) =
        [ for row in 0 .. grid.Length - 1 do
            for col in 0 .. grid.[0].Length - 1 do
                if isValidSpot grid (row, col) then
                    yield row, col ]

let removeSpots (grid: char[][]) spots =
    let newGrid = grid |> Array.map Array.copy
    spots |> List.iter (fun (row, col) -> 
        newGrid.[row].[col] <- '.')
    newGrid

let rec removeUntilNone grid totalRemoved =
    let validSpots = findValidSpots grid
    
    if validSpots.IsEmpty then
        totalRemoved
    else
        let newGrid = removeSpots grid validSpots
        removeUntilNone newGrid (totalRemoved + validSpots.Length)

let part2 (lines: string[]) =
    let initialGrid =
        lines
        |> Array.map (fun line -> line.ToCharArray())

    removeUntilNone initialGrid 0

let part1 (lines: string[]) =
    let grid =
        lines
        |> Array.map (fun line -> line.ToCharArray())

    let mutable validSpots = 0

    for row in 0 .. grid.Length - 1 do
        for col in 0 .. grid.[0].Length - 1 do
            if isValidSpot grid (row, col) then
                //printfn "Valid (%d, %d)" row col
                validSpots <- validSpots + 1

    validSpots
  
[<EntryPoint>]
let main argv =
    let lines = File.ReadAllLines("input.txt")

    let result1 = part1 lines
    printfn "Result part1: %d" result1

    let result2 = part2 lines
    printfn "Result part2: %d" result2
    0