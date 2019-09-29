#pragma once

#include "ILogger.h"
#include <string>

class Logger : public ILogger
{
public:
    Logger()
    {
        Initialized = true;
    }

    ~Logger()
    {
        std::cout << "Successfully shutdown Logger!\n";
    }

    virtual void info(const char* message)
    {
        if (message != nullptr)
        {
            std::cout << "INFO: " << message;
        }
    }

    virtual void warning(const char* message)
    {
        if (message != nullptr)
        {
            std::cerr << "WARNING: " << message;
        }
    }

    virtual void error(const char* message)
    {
        if (message != nullptr)
        {
            std::cerr << "ERROR: " << message;
        }
    }
};