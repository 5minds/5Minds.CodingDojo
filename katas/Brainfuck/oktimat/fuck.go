package main

import (
	"bufio"
	"fmt"
	"io/ioutil"
	"os"
)

func interpret(commands string) string {
	const memSize = 1024
	var memory [memSize]int

	var pos = 0

	var bracketCount = 0
	var output = ""

	for i := 0; i < len(commands); i++ {
		var cmd = commands[i]

		if cmd == '>' {
			pos++
		} else if cmd == '<' {
			pos--
		} else if cmd == '+' {
			memory[pos]++
		} else if cmd == '-' {
			memory[pos]--
		} else if cmd == '.' {
			output += string(memory[pos])
			fmt.Printf("%c", memory[pos])
		} else if cmd == ',' {
			reader := bufio.NewReader(os.Stdin)
			value, _ := reader.ReadByte()
			memory[pos] = int(value)
		} else if cmd == '[' {
			if memory[pos] != 0 {
				continue
			}
			bracketCount = 1
			for bracketCount > 0 {
				i++
				var checkCmd = commands[i]
				if checkCmd == '[' {
					bracketCount++
				} else if checkCmd == ']' {
					bracketCount--
				}
			}
		} else if cmd == ']' {
			if memory[pos] == 0 {
				continue
			}
			bracketCount = 1
			for bracketCount > 0 {
				i--
				var checkCmd = commands[i]
				if checkCmd == ']' {
					bracketCount++
				} else if checkCmd == '[' {
					bracketCount--
				}
			}
		}
	}

	return output
}

func main() {
	path := os.Args[1]

	b, error := ioutil.ReadFile(path)
	if error != nil {
		fmt.Println(error)
		return
	}

	var commands = string(b)
	interpret(commands)
}
