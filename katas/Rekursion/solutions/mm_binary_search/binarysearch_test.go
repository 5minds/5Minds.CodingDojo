package binarysearch

import "testing"

func TestSearchRecusionEmptyArray(t *testing.T) {
	testArray := []int{}
	searchTerm := 7
	expected := false

	actual := SearchRecusion(testArray, searchTerm)

	if actual != expected {
		t.Errorf("SearchRecusion(%d, %d) => %t, want %t", testArray, searchTerm, actual, expected)
	}
}

func TestSearchRecusionOneElement(t *testing.T) {
	testArray := []int{7}
	searchTerm := 7
	expected := true

	actual := SearchRecusion(testArray, searchTerm)

	if actual != expected {
		t.Errorf("SearchRecusion(%d, %d) => %t, want %t", testArray, searchTerm, actual, expected)
	}
}

func TestSearchRecusionLow(t *testing.T) {
	testArray := []int{1, 2, 3, 4, 5, 6, 7, 8, 9}
	searchTerm := 2
	expected := true

	actual := SearchRecusion(testArray, searchTerm)

	if actual != expected {
		t.Errorf("SearchRecusion(%d, %d) => %t, want %t", testArray, searchTerm, actual, expected)
	}
}

func TestSearchRecusionHigh(t *testing.T) {
	testArray := []int{1, 2, 3, 4, 5, 6, 7, 8}
	searchTerm := 7
	expected := true

	actual := SearchRecusion(testArray, searchTerm)

	if actual != expected {
		t.Errorf("SearchRecusion(%d, %d) => %t, want %t", testArray, searchTerm, actual, expected)
	}
}

func TestSearchRecusionNotFound(t *testing.T) {
	testArray := []int{1, 2, 3, 4, 5, 6, 7, 8}
	searchTerm := 9
	expected := false

	actual := SearchRecusion(testArray, searchTerm)

	if actual != expected {
		t.Errorf("SearchRecusion(%d, %d) => %t, want %t", testArray, searchTerm, actual, expected)
	}
}
