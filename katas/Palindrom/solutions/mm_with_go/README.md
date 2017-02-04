# Solutions for a Palindrom in GO

## Start the tests

- Install go via `brew install go`
- Run the tests via `go test`

## Code

- palindrom.go: Contains the package _palindrom_ with 
 the public func __IsPalindrom__
- palindrom_test.go: Contains the table tests for 
 all palindrom of the dojo.

## Hints 

At first check if the input has a length of 0 or 1.
After that make the _input_ to lower case and only 
accepts chars between _a_ and _z_. Create a reverse
of the prepared string and compare the string. If
both strings are equal a palindrom was found.

