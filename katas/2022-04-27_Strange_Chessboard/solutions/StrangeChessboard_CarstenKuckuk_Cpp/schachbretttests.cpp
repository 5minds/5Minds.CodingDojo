// Projekt: Strange Chessboard Kata, 5Minds Coding Dojo, 27.04.2022, 19:10-20:10, Lösung Carsten Kuckuk, ck@kuckuk.com
// Datei: schachbretttests.cpp

// DUT:
#include "schachbrett.hpp"""

// Google Test Library:
#include "gtest/gtest.h"

int main(int argc, char** argv)
{
	::testing::InitGoogleTest(&argc, argv);

	int nErg = RUN_ALL_TESTS();

	return nErg;
}

TEST(Schachbrettkata, IstGeradeTest)
{
	ASSERT_TRUE(IstGerade(0));
	ASSERT_FALSE(IstGerade(1));
	ASSERT_TRUE(IstGerade(2));
	ASSERT_FALSE(IstGerade(3));
}

TEST(Scharbrettkata, Summentest)
{
	std::vector<int> rgEins = { 1 };
	std::vector<int> rgEinsZwei = { 1,2 };
	std::vector<int> rgEinsZweiDrei = { 1,2,3 };

	ASSERT_EQ(1, Summe(rgEins));
	ASSERT_EQ(3, Summe(rgEinsZwei));
	ASSERT_EQ(6, Summe(rgEinsZweiDrei));

}

TEST(Schachbrettkata, Gesamtfelder)
{
	std::vector<int> rgEins = { 1 };
	std::vector<int> rgEinsZwei = { 1,2 };
	std::vector<int> rgEinsZweiDrei = { 1,2,3 };

	ASSERT_EQ(1, AnzahlAllerFelder(rgEins, rgEins));
	ASSERT_EQ(3, AnzahlAllerFelder(rgEins, rgEinsZwei));
	ASSERT_EQ(9, AnzahlAllerFelder(rgEinsZwei, rgEinsZwei));
}


TEST(Schachbrettkata, Weissefelder)
{
	std::vector<int> rgEins = { 1 };
	std::vector<int> rgEinsZwei = { 1,2 };
	std::vector<int> rgEinsZweiDrei = { 1,2,3 };

	ASSERT_EQ(1, AnzahlWeisserFelder(rgEins, rgEins));
	ASSERT_EQ(1*1, AnzahlWeisserFelder(rgEins, rgEinsZwei));
	ASSERT_EQ(1*1+2*2, AnzahlWeisserFelder(rgEinsZwei, rgEinsZwei));
}

TEST(Schachbrettkata, VorgegebeneTests)
{
	// cs: [3, 1, 2, 7, 1] , rs : [1, 8, 4, 5, 2] , result : (146, 134)
	std::vector<int> cs1 = { 3, 1, 2, 7, 1 };
	std::vector<int> rs1 = { 1, 8, 4, 5, 2 };
	ASSERT_EQ(146, AnzahlWeisserFelder(cs1, rs1));
	ASSERT_EQ(134, AnzahlSchwarzerFelder(cs1, rs1));

	// cs : [3, 1, 2, 7, 1, 11, 12, 3, 8, 1] , rs : [1, 8, 4, 5, 2, 21, 5, 2, 2, 17] , result : (1583, 1700)
	std::vector<int> cs2 = { 3, 1, 2, 7, 1, 11, 12, 3, 8, 1 };
	std::vector<int> rs2 = { 1, 8, 4, 5, 2, 21, 5, 2, 2, 17 };
	ASSERT_EQ(1583, AnzahlWeisserFelder(cs2, rs2));
	ASSERT_EQ(1700, AnzahlSchwarzerFelder(cs2, rs2));


	// cs : [3] , rs : [2] , result : (6, 0)
	std::vector<int> cs3 = { 3 };
	std::vector<int> rs3 = { 2 };
	ASSERT_EQ(6, AnzahlWeisserFelder(cs3, rs3));
	ASSERT_EQ(0, AnzahlSchwarzerFelder(cs3, rs3));
}

