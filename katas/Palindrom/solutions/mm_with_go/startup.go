package main

import (
	"flag"
	"fmt"

	"./sub"
)

func main() {

	input := flag.String("palindrom", "abba", "The given palindrom")

	flag.Parse()

	is := palindrom.IsPalindrom(*input)

	fmt.Println("please type go test", is)
}
