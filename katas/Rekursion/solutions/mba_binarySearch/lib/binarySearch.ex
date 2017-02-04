defmodule BinarySearch do
    def binarySearch(array, number) do
       binarySearchRec(array, number, 0, length(array))
    end

    defp binarySearchRec(array, number, first, last) when last < first do
        -1
    end

    defp binarySearchRec(array, number, first, last) do
        midIndex = div(first + last, 2)
        item = Enum.at(array, midIndex) 
        cond do
            number < item -> binarySearchRec(array, number, first, midIndex-1)
            number > item -> binarySearchRec(array, number, midIndex+1, last)
            true -> midIndex
        end
    end
end
