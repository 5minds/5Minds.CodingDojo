package binarysearch

import "testing"

func TestSearchRecusionEmptyArray(t *testing.T) {
	testArray := []int{}
	searchTerm := 7
	expected := false

	actual := SearchRecusion(testArray, searchTerm)

	if actual != expected {
		t.Errorf("SearchRecusion(%s, %s) => %t, want %t", testArray, searchTerm, actual, expected)
	}
}

func TestSearchRecusionOneElement(t *testing.T) {
	testArray := []int{7}
	searchTerm := 7
	expected := true

	actual := SearchRecusion(testArray, searchTerm)

	if actual != expected {
		t.Errorf("SearchRecusion(%s, %s) => %t, want %t", testArray, searchTerm, actual, expected)
	}
}

func TestSearchRecusion(t *testing.T) {
	testArray := []int{1, 2, 3, 4, 5, 6, 7, 8}
	searchTerm := 7
	expected := true

	actual := SearchRecusion(testArray, searchTerm)

	if actual != expected {
		t.Errorf("SearchRecusion(%s, %s) => %t, want %t", testArray, searchTerm, actual, expected)
	}
}
