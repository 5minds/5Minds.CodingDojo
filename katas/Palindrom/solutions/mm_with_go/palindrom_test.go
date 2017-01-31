package palindrom

import "testing"

var palindromTests = []struct {
	in  string
	out bool
}{
	{"Tarne nie deinen Rat!", true},
	{"Eine güldne, gute Tugend: Lüge nie!", true},
	{"Ein agiler Hit reizt sie. Geist?! Biertrunk nur treibt sie. Geist ziert ihre Liga nie!", true},
	{"Abba", true},
	{"Lagerregal", true},
	{"Reliefpfeiler", true},
	{"Rentner", true},
	{"Dienstmannamtsneid", true},
	{"Dienstmannamtsneid-failed", false},
}

func TestIsPalindrom(t *testing.T) {

	for _, tt := range palindromTests {
		actual := IsPalindrom(tt.in)

		if actual != tt.out {
			t.Errorf("IsPalindrom(%s) => %t, want %t", tt.in, actual, tt.out)
		}
	}

}
