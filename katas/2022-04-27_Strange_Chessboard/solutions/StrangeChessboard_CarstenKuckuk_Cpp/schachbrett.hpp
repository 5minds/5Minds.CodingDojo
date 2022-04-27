// Projekt: Strange Chessboard Kata, 5Minds Coding Dojo, 27.04.2022, 19:10-20:10, Lösung Carsten Kuckuk, ck@kuckuk.com
// Datei: schachbrett.hpp
// 
// Fachlogik

#ifndef __SCHACHBRETT_HPP__
#define __SCHACHBRETT_HPP__

#include <vector>

bool IstGerade(int nArg);

int Summe(const std::vector<int>& rgInts);

int AnzahlAllerFelder(const std::vector<int>& rgSpaltenbreiten, const std::vector<int>& rgZeilenhoehen);

int AnzahlWeisserFelder(const std::vector<int>& rgSpaltenbreiten, const std::vector<int>& rgZeilenhoehen);

int AnzahlSchwarzerFelder(const std::vector<int>& rgSpaltenbreiten, const std::vector<int>& rgZeilenhoehen);

#endif
