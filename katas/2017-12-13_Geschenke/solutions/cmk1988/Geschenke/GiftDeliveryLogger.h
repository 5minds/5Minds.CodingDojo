#pragma once
#include <vector>
#include <string>
#include <tuple>

using namespace std;

typedef pair<int, int> Coordinates;
typedef pair<Coordinates, int> GiftsForCoordinate;

class cGiftDeliveryLogger
{
public:
	cGiftDeliveryLogger();
	~cGiftDeliveryLogger();
	void LogGiftReceiversByString(const string& input, int xStart = 0, int yStart = 0);
	int GetDoubleReceivedCount();
	int GetVisitedHousesCount();

private:
	const char GO_UP = '^';
	const char GO_RIGHT = '>';
	const char GO_DOWN = 'v';
	const char GO_LEFT = '<';
	vector<GiftsForCoordinate> m_DispatchedGifts;

	void setCoordinates(const char c, int& x, int& y);
	void addNewDeliveredHouse(int& xStart, int& yStart);
};