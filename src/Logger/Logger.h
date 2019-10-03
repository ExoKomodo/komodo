#pragma once

#include "ILogger.h"
#include <string>
#include <fstream>
#include <filesystem>
#include <ctime>
#include <vector>

class Logger : public ILogger
{
public:
    Logger()
    {
        m_initialized = true;
    }

    ~Logger()
    {
        for (auto it = this->m_output_streams.begin(); it != this->m_output_streams.end(); ++it)
        {
            if ((*it)->is_open())
            {
                (*it)->close();
            }
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

    bool v_add_output(const char* output_file_name)
    {
        std::ofstream* output_stream = new std::ofstream();
        output_stream->open(output_file_name, std::ios::out | std::ios::trunc);
        if (output_stream->is_open())
        {
            this->m_output_streams.push_back(output_stream);
            this->v_info("Successfully added new logging output");
            return true;
        }
        else
        {
            this->v_error("Failed in adding new logging output");
            return false;
        }
    }

protected:
    std::vector<std::ofstream*> m_output_streams;

    const char* m_info_prefix = "INFO: ";
    const char* m_warning_prefix = "WARNING: ";
    const char* m_error_prefix = "ERROR: ";

    void write_log(const char* prefix, const char* message, bool printToConsole = true)
    {
        if (prefix == this->m_info_prefix || prefix == this->m_warning_prefix)
        {
            std::cout << prefix << message << std::endl;
        }
        else
        {
            std::cerr << prefix << message << std::endl;
        }
        for (auto it = this->m_output_streams.begin(); it != this->m_output_streams.end(); ++it)
        {
            (**it) << message << std::endl;
        }
    }
};