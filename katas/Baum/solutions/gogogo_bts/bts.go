package bts

type TreeType struct {
	Value int
	Left  *TreeType
	Right *TreeType
}

func Search(rootTree *TreeType, searchValue int) bool {
	if rootTree == nil {
		return false
	}

	//fmt.Println(rootTree.Value)

	if rootTree.Value == searchValue {
		return true
	}

	if rootTree.Value > searchValue {
		return Search(rootTree.Left, searchValue)
	}

	return Search(rootTree.Right, searchValue)
}
