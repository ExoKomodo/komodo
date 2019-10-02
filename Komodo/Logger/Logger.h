#pragma once

#include "ILogger.h"
#include <string>
#include <fstream>
#include <filesystem>
#include <ctime>

class Logger : public ILogger
{
public:
    Logger(const char* log_file_name = nullptr)
    {
        if (log_file_name)
        {
            this->m_log_file.open(log_file_name, std::ios::out | std::ios::trunc);
            if (!this->m_log_file.is_open())
            {
                std::cerr << "Log file did not open!\n";
            }
            else
            {
                //time_t now = time(0);
                //this->m_log_file << "KOMODO GAME ENGINE: " << ctime(&now) << std::endl;
            }
        }
        m_initialized = true;
    }

    ~Logger()
    {
        if (this->m_log_file)
        {
            this->m_log_file.close();
        }
        std::cout << "Successfully shutdown Logger!\n";
    }

    void v_info(const char* message, bool printToConsole = true)
    {
        if (message != nullptr)
        {
            this->write_log(this->m_info_prefix, message, printToConsole);
        }
    }

    void v_warning(const char* message, bool printToConsole = true)
    {
        if (message != nullptr)
        {
            this->write_log(this->m_warning_prefix, message, printToConsole);
        }
    }

    void v_error(const char* message, bool printToConsole = true)
    {
        if (message != nullptr)
        {
            this->write_log(this->m_error_prefix, message, printToConsole);
        }
    }

protected:
    std::ofstream m_log_file;

    const char* m_info_prefix = "INFO: ";
    const char* m_warning_prefix = "WARNING: ";
    const char* m_error_prefix = "ERROR: ";

    void write_log(const char* prefix, const char* message, bool printToConsole = true)
    {
        if (printToConsole)
        {
            std::cout << prefix << message << std::endl;
        }
        if (this->m_log_file)
        {
            this->m_log_file << prefix << message << std::endl;
        }
    }
};