open System.IO

[<EntryPoint>]
let main argv =
    let lines = File.ReadAllLines("test.txt")
    let mutable currentPos = 50
    let mutable timesAtZero = 0
    for line in lines do
        let direction = line.[0]
        let distance = int line.[1..]
        
        let zerosPassed = 
            if direction = 'R' then
                (currentPos + distance) / 100
            else
                let startVal = float (currentPos - 1)
                let endVal = float (currentPos - distance - 1)
                int (floor (startVal / 100.0) - floor (endVal / 100.0))
        
        timesAtZero <- timesAtZero + zerosPassed

        if direction = 'R' then
            currentPos <- (currentPos + distance) % 100
        else if direction = 'L' then
            currentPos <- (currentPos - distance) % 100
            if currentPos < 0 then 
                currentPos <- currentPos + 100
                
        printfn "Moved %c%d to %d (Zeros passed: %d)" direction distance currentPos zerosPassed
    printfn "Times at zero: %d" timesAtZero
    0 