package main

import (
	"fmt"
	"testing"
)

func TestHelloWorld(t *testing.T) {
	var result = interpret("++++++++++[>+++++++>++++++++++>+++>+<<<<-]>++.>+.+++++++..+++.>++.<<+++++++++++++++.>.+++.------.--------.>+.")
	fmt.Println()
	if result != "Hello World!" {
		t.Fail()
	}
}
