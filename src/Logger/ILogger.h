#pragma once

#include <fstream>

class ILogger
{
public:
    bool m_initialized = false;

    virtual ~ILogger()
    {
        
    }

    virtual void v_info(const char* message, bool printToConsole = true) = 0;
    virtual void v_warning(const char* message, bool printToConsole = true) = 0;
    virtual void v_error(const char* message, bool printToConsole = true) = 0;
    virtual bool v_add_output(const char* output_file_name) = 0;
};