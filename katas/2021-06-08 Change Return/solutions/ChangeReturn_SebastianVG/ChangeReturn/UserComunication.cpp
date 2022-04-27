#include <string>
#include "UserComunication.h"


UserComunication::UserComunication(double& cost, double& paid)
{
    _cost = &cost;
    _paid = &paid;
    _break = false;
}


void UserComunication::Intput()
{
    std::string cost, paid;
    std::cout << "Please enter the total price:" << std::endl;
    std::cin >> cost;
    *_cost = ValidateInputValueFormat(cost);

    std::cout << "Please enter the total amount paid:" << std::endl;
    std::cin >> paid;
    *_paid = ValidateInputValueFormat(paid);

    CheckInputValues();
}

void UserComunication::Output(std::map<int, int>& returnChangeMap)
{
    std::cout << "Change return:" << std::endl;
    std::cout << std::endl;

    for (std::map<int, int>::reverse_iterator changeReturnReverseIterartor = returnChangeMap.rbegin(); changeReturnReverseIterartor != returnChangeMap.rend(); ++changeReturnReverseIterartor)
    {
        if (changeReturnReverseIterartor->second > 0)
        {
            double result = (double)changeReturnReverseIterartor->first / 100;

            if (result > 10)
            {
                std::cout << "You became from " << result << " Euro -- number(s): " << changeReturnReverseIterartor->second << " Bank Note(s)." << std::endl;
            }
            else
            {
                if (result < 10 && result > 1)
                {
                    std::cout << "You became from " << result << " Euro -- number(s): " << changeReturnReverseIterartor->second << " coint(s)." << std::endl;
                }
                else
                {
                    if (result < 1)
                    {
                        std::cout << "You became from " << result * 100 << " Euro-Cent -- number(s): " << changeReturnReverseIterartor->second << " coint(s)." << std::endl;
                    }
                }
            }
        }
    }
}

void UserComunication::CheckInputValues()
{
    if (*_cost > *_paid)
    {
        std::cout << "You paid too little!" << std::endl;
        _break = true;
        return;
    }

    if ((*_cost == *_paid) && ((*_cost > 0) && (*_paid > 0)))
    {
        std::cout << "You paid exactly!" << std::endl;
        _break = true;
        return;
    }

    if ((*_cost == 0) && (*_paid == 0))
    {
        std::cout << "Error Wrong Format! Calculation break!" << std::endl;
        _break = true;
        return;
    }
}

bool UserComunication::GetBreak()
{
    return _break;
}

double UserComunication::ValidateInputValueFormat(std::string value)
{
    if (value.find(",") != std::string::npos)
    {
        std::cout << "Wrong Format! Change decimal separator automaticly from ',' to '.'" << std::endl;
        value.replace(value.find(","), sizeof(",") - 1, ".");
    }
    return atof(value.c_str());
}