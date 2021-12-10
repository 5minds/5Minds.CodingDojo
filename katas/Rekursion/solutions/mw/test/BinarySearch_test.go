package test

import (
	binarySearch "binarySearch/src"
	"testing"
)

func TestBinarySearchSingleItemSuccess(t *testing.T) {
	array := []int{2}
	target := 2

	var testResult = binarySearch.BinarySearch(array, target)

	if testResult != target {
		t.Errorf("Expected %d got %d", target, testResult)
	}
}

func TestBinarySearchMultipleItemsSuccess(t *testing.T) {
	array := []int{1, 2, 3, 4, 5, 6, 7, 8, 10, 11, 12, 13, 14, 15}
	target := 4

	var testResult = binarySearch.BinarySearch(array, target)

	if testResult != target {
		t.Errorf("Expected %d got %d", target, testResult)
	}
}

func TestBinarySearchUnsortedFailure(t *testing.T) {
	array := []int{7, 6, 5, 4, 3}
	target := 4

	var testResult = binarySearch.BinarySearch(array, target)

	if testResult != -1 {
		t.Errorf("Expected %d got %d", -1, testResult)
	}
}

func TestBinarySearchSortedButMissingFailure(t *testing.T) {
	array := []int{7, 6, 5, 4, 3}
	target := 22

	var testResult = binarySearch.BinarySearch(array, target)

	if testResult != -1 {
		t.Errorf("Expected %d got %d", -1, testResult)
	}
}
