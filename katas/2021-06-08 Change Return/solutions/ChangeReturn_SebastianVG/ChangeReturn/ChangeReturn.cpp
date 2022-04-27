#include <iostream>
#include "CalculateChangeReturn.h"
#include "UserComunication.h"

int main()
{
    double cost = 0;
    double paid = 0;

    UserComunication userCom(cost, paid);
    userCom.Intput();
    std::cout << std::endl;

    if (userCom.GetBreak())
    {
        std::cout << "Program End" << std::endl;
        return 0;
    }

    CalculateChangeReturn calculate = CalculateChangeReturn(cost, paid);
    std::map<int, int> returnChangeMap = calculate.GetChangeReturn();

    userCom.Output(returnChangeMap);

    std::cout << "Program End" << std::endl;
    return 0;
}
