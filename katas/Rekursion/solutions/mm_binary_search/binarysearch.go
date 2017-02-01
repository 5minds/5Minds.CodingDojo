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

	//idx := len(array) / 2

	return true
}
