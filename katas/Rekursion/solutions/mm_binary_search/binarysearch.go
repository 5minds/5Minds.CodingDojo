package binarysearch

// SearchRecusion search a term of int in a sorted array
func SearchRecusion(array []int, searchTerm int) (found bool) {

	if len(array) == 0 {
		found = false
		return
	}

	if len(array) == 1 {
		found = array[0] == searchTerm
		return
	}

	len := len(array)
	center := len / 2

	if array[center] == searchTerm {
		found = true
		return
	}

	if array[center] < searchTerm {
		newArray := array[center:len]
		found = SearchRecusion(newArray, searchTerm)
		return
	}

	newArray := array[0 : center-1]
	found = SearchRecusion(newArray, searchTerm)
	return
}
