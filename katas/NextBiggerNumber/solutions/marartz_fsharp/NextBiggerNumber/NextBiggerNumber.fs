module NextBiggerNumber

let getNextBiggerNumber (num: int64) : int64 = 
    let rec getNextBiggerNumberInt (num: int64) (trailingDigits: list<uint8>): int64 =
        let lastDigit = (uint8)(num % 10L)
        if lastDigit = (uint8)0 then
            -1L
        elif trailingDigits.Length < 1 || lastDigit >= trailingDigits.[0] then
            getNextBiggerNumberInt (num / 10L) (List.append [(uint8)lastDigit] trailingDigits)
        else
            let rec getIndexOfNextBiggerDigit (digits: list<uint8>) (index: int) (pivotDigit: uint8) : int =
                if digits.IsEmpty || index < 0 || index >= digits.Length then
                    -1
                else
                    if digits.[index] > pivotDigit then
                        index
                    else 
                        getIndexOfNextBiggerDigit digits (index + 1) pivotDigit

            let rec digitsToNum (num: int64) (trailingDigits: list<uint8>): int64 =
                if trailingDigits.IsEmpty then
                    num
                else
                    digitsToNum ((num * 10L) + (int64)trailingDigits.[0]) trailingDigits.[1..]

            let sortedDigits = (List.append [lastDigit] trailingDigits) |> List.sort
            let indexOfNextBiggerDigit = getIndexOfNextBiggerDigit sortedDigits 0 lastDigit
            let nextBiggerDigit = sortedDigits.[indexOfNextBiggerDigit]

            if indexOfNextBiggerDigit = 0 then
                digitsToNum (num / 10L) (List.append [nextBiggerDigit] sortedDigits.[1..])
            elif indexOfNextBiggerDigit = sortedDigits.Length - 1 then
                digitsToNum (num / 10L) (List.append [nextBiggerDigit] sortedDigits.[.. (sortedDigits.Length - 2)])
            else
                digitsToNum (num / 10L) (List.append [nextBiggerDigit] (List.append sortedDigits.[..(indexOfNextBiggerDigit - 1)] sortedDigits.[(indexOfNextBiggerDigit + 1)..]))
        
    if num < 0L then
        -1L
    else
        getNextBiggerNumberInt num List.Empty
