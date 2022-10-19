// Projekt: Strange Chessboard Kata, 5Minds Coding Dojo, 27.04.2022, 19:10-20:10, Lösung Carsten Kuckuk, ck@kuckuk.com
// Datei: schachbrett.cpp
// 
// Fachlogik

#include "schachbrett.hpp"

bool IstGerade(int nArg)
{
	bool bIstGerade = nArg % 2 == 0;
	return bIstGerade;
}

int Summe(const std::vector<int>& rgInts)
{
	int nErg = 0;
	for (int i : rgInts)
	{
		nErg += i;
	}
	return nErg;
}

int AnzahlAllerFelder(const std::vector<int>& rgSpaltenbreiten, const std::vector<int>& rgZeilenhoehen)
{
	int nSummeAllerSpaltenbreiten = Summe(rgSpaltenbreiten);
	int nSummeAllerZeilenhoehen = Summe(rgZeilenhoehen);
	int nErg = nSummeAllerSpaltenbreiten * nSummeAllerZeilenhoehen;
	return nErg;
}

int AnzahlWeisserFelder(const std::vector<int>& rgSpaltenbreiten, const std::vector<int>& rgZeilenhoehen)
{
	int nSummeAllerWeissenFelder = 0;
	for (int nSpalte = 0; nSpalte < rgSpaltenbreiten.size(); nSpalte++)
	{
		for (int nZeile = 0; nZeile < rgZeilenhoehen.size(); nZeile++)
		{
			bool bIstWeissesFeld = IstGerade(nSpalte + nZeile);
			if (bIstWeissesFeld)
			{
				int nFeldgroesse = rgSpaltenbreiten[nSpalte] * rgZeilenhoehen[nZeile];
				nSummeAllerWeissenFelder += nFeldgroesse;
			}
		}
	}
	return nSummeAllerWeissenFelder;
}

int AnzahlSchwarzerFelder(const std::vector<int>& rgSpaltenbreiten, const std::vector<int>& rgZeilenhoehen)
{
	int nAnzahlAllerFelder = AnzahlAllerFelder(rgSpaltenbreiten, rgZeilenhoehen);
	int nAnzahlWeisserFelder = AnzahlWeisserFelder(rgSpaltenbreiten, rgZeilenhoehen);
	int nAnzahlSchwarzerFelder = nAnzahlAllerFelder - nAnzahlWeisserFelder;
	return nAnzahlSchwarzerFelder;
}
