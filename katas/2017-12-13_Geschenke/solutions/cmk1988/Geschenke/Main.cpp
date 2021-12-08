#include <fstream>
#include <iostream>
#include "GiftDeliveryLogger.h"

int main(int argc, char** argv)
{
	vector<string> args(&argv[0], &argv[0 + argc]);
	if (args.size() < 2)
	{
		cout << "Bitte geben sie eine Inputdatei als Kommandozeilenparameter an." << endl;
		return EXIT_FAILURE;
	}
	ifstream file(args[1]);
	if (!file.good() || !file.is_open())
	{
		cout << "Die angegebene Datei konnte nicht ge\x94\bffnet werden (" << args[1] << ")" << endl;
		return EXIT_FAILURE;
	}
	for (size_t i = 1 ;; i++)
	{
		string line;
		if (!getline(file, line))
			break;
		cGiftDeliveryLogger logger;
		logger.LogGiftReceiversByString(line);
		cout << "Route " << i << ": Es wurden " << logger.GetVisitedHousesCount() << " H\x84user besucht." << endl;
	}
	return EXIT_SUCCESS;
}