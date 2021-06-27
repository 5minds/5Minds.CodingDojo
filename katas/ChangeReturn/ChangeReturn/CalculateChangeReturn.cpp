#include "CalculateChangeReturn.h"

CalculateChangeReturn::CalculateChangeReturn(double cost, double paid)
{
    // change from Euro to Euro-Cent!
    _cost = cost * 100;
    _paid = paid * 100;
    _changeReturnMap =
    {
        {50000,0},
        {20000,0},
        {10000,0},
        {5000,0},
        {2000,0},
        {1000,0},
        {500,0},
        {200,0},
        {100,0},
        {50,0},
        {20,0},
        {10,0},
        {5,0},
        {2,0},
        {1,0}
    };

    this->Calculate();
}

void CalculateChangeReturn::Calculate()
{
    int calc = 0;
    _deltaResult = _paid - _cost;

    for (std::map<int, int>::reverse_iterator changeReturnReverseIterartor = _changeReturnMap.rbegin(); changeReturnReverseIterartor != _changeReturnMap.rend(); ++changeReturnReverseIterartor)
    {
        calc = _deltaResult / changeReturnReverseIterartor->first;
        if (calc > 0)
        {
            changeReturnReverseIterartor->second = calc;
            _deltaResult = _deltaResult - calc * changeReturnReverseIterartor->first;
        }
    }
}

PairMap& CalculateChangeReturn::GetChangeReturn()
{
    return _changeReturnMap;
}