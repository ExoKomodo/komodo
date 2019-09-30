#pragma once

#include "IDataFiles.h"

class DataFiles : public IDataFiles
{
public:
    DataFiles()
    {
        this->m_initialized = true;
    }

    ~DataFiles()
    {
        std::cout << "Successfully shutdown Data Files!\n";
    }
};