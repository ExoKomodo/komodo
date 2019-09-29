#pragma once

#include "IDataFiles.h"

class DataFiles : public IDataFiles
{
public:
    DataFiles()
    {
        this->Initialized = true;
    }

    ~DataFiles()
    {
        std::cout << "Successfully shutdown Data Files!\n";
    }
};