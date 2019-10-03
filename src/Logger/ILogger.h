#pragma once

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
};