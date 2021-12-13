#include "GiftDeliveryLogger.h"
#include <algorithm>


cGiftDeliveryLogger::cGiftDeliveryLogger()
{
}

cGiftDeliveryLogger::~cGiftDeliveryLogger()
{
}

void cGiftDeliveryLogger::LogGiftReceiversByString(const string& input, int xStart, int yStart)
{
	addNewDeliveredHouse(xStart, yStart);
	for (const char& c : input)
	{
		setCoordinates(c, xStart, yStart);
		auto current = find_if(m_DispatchedGifts.begin(), m_DispatchedGifts.end(), [xStart, yStart](const GiftsForCoordinate& pFC)
			{
				return pFC.first.first == xStart && pFC.first.second == yStart;
			});
		if (current != m_DispatchedGifts.end())
			++(*current).second;
		else
			addNewDeliveredHouse(xStart, yStart);
	}
}

void cGiftDeliveryLogger::addNewDeliveredHouse(int& xStart, int& yStart)
{
	GiftsForCoordinate pFC(Coordinates(xStart, yStart), 1);
	m_DispatchedGifts.push_back(pFC);
}

int cGiftDeliveryLogger::GetDoubleReceivedCount()
{
	return count_if(m_DispatchedGifts.begin(), m_DispatchedGifts.end(), [](const  GiftsForCoordinate& pFC) { return pFC.second > 1; });
}

int cGiftDeliveryLogger::GetVisitedHousesCount()
{
	return m_DispatchedGifts.size();
}

void cGiftDeliveryLogger::setCoordinates(const char c, int& x, int& y)
{
	if (c == GO_UP)
		++y;
	else if (c == GO_DOWN)
		--y;
	else if (c == GO_RIGHT)
		++x;
	else if (c == GO_LEFT)
		--x;
}