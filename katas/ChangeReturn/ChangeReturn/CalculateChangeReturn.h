#pragma once
#include<iostream>
#include <map>

typedef std::map<int, int> PairMap;

class CalculateChangeReturn
{
private:
    double _cost;
    double _paid;
    PairMap _changeReturnMap;
    int _deltaResult;

public:
    CalculateChangeReturn(double cost, double paid);

    PairMap& GetChangeReturn();

private:
    void Calculate();
};
