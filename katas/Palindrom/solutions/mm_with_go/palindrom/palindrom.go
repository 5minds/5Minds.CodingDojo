package palindrom

import (
	"fmt"
	"regexp"
	"strings"
)

func reverse(s string) (result string) {
	for _, v := range s {
		result = string(v) + result
	}
	return
}

// IsPalindrom check if the input is a palindrom.
// A palindrom is a string that equal when read
// from right or from left
func IsPalindrom(input string) (isPalindrom bool) {
	isPalindrom = false

	if len(input) == 0 || len(input) == 1 {
		isPalindrom = true
	} else {
		input = strings.ToLower(input)
		re := regexp.MustCompile("[^a-z]")

		input = re.ReplaceAllString(input, "")

		reverseInput := reverse(input)

		fmt.Println(input)
		fmt.Println(reverseInput)

		isPalindrom = reverseInput == input
	}

	return
}
