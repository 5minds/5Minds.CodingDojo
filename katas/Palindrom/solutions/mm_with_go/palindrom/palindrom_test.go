package palindrom

import "testing"

func TestIsPalindrom(t *testing.T) {
	expected := true

	actual := IsPalindrom("abba")

	if actual != expected {
		t.Error("abba is a palindrom")
	}
}
