#pragma once

#include <iostream>
#include <map>

class UserComunication
{
private:
    double* _cost = nullptr;
    double* _paid = nullptr;
    bool _break;

public:
    UserComunication(double& cost, double& paid);

    void Intput();
    void Output(std::map<int, int>& returnChangeMap);
    bool GetBreak();

private:
    void CheckInputValues();
    double ValidateInputValueFormat(std::string value);
};

