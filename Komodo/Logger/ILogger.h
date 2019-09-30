#pragma once

class ILogger
{
public:
    bool m_initialized = false;

    virtual ~ILogger()
    {
        
    }

    virtual void info(const char* message) = 0;
    virtual void warning(const char* message) = 0;
    virtual void error(const char* message) = 0;
};