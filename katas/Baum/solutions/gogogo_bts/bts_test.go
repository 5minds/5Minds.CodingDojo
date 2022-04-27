package bts

import "testing"

var (
	tree TreeType
)

func createTreeType() *TreeType {
	var tree *TreeType

	tree1 := &TreeType{Value: 1, Left: nil, Right: nil}
	tree6 := &TreeType{Value: 6, Left: nil, Right: nil}
	tree3 := &TreeType{Value: 3, Left: tree1, Right: tree6}

	tree13 := &TreeType{Value: 13, Left: nil, Right: nil}
	tree14 := &TreeType{Value: 14, Left: tree13, Right: nil}

	tree10 := &TreeType{Value: 10, Left: nil, Right: tree14}

	tree = &TreeType{Value: 8, Left: tree3, Right: tree10}

	return tree
}

func TestRootNil(t *testing.T) {
	var tree *TreeType
	expected := false

	searchValue := -1

	actual := Search(tree, searchValue)

	if actual != expected {
		t.Errorf("Search(Tree, %d) => %t, want %t", searchValue, actual, expected)
	}
}

func TestRootFound(t *testing.T) {
	var tree *TreeType
	tree = createTreeType()

	expected := true

	searchValue := 8

	actual := Search(tree, searchValue)

	if actual != expected {
		t.Errorf("Search(Tree, %d) => %t, want %t", searchValue, actual, expected)
	}
}

func TestFoundLeft1(t *testing.T) {
	var tree *TreeType
	tree = createTreeType()

	expected := true

	searchValue := 1

	actual := Search(tree, searchValue)

	if actual != expected {
		t.Errorf("Search(Tree, %d) => %t, want %t", searchValue, actual, expected)
	}
}

func TestFoundLeft14(t *testing.T) {
	var tree *TreeType
	tree = createTreeType()

	expected := true

	searchValue := 14

	actual := Search(tree, searchValue)

	if actual != expected {
		t.Errorf("Search(Tree, %d) => %t, want %t", searchValue, actual, expected)
	}
}
