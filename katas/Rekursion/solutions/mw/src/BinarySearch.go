package binarySearch

func BinarySearch(inputArray []int, target int) int {
	if len(inputArray) == 0 { // we've gone through it all
		return -1
	}

	// helper variables

	low := 0
	high := len(inputArray) - 1
	mid := (low + high) / 2

	if inputArray[mid] > target { // take left partial array
		return BinarySearch(inputArray[:mid], target)
	} else if inputArray[mid] < target { // take right partial array
		return BinarySearch(inputArray[mid+1:], target)
	} else {
		return inputArray[mid] // target is at mid of array
	}
}
