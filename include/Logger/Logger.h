#pragma once

#include <include/Logger/ILogger.h>
#include <string>
#include <fstream>
#include <filesystem>
#include <ctime>
#include <vector>
#include <iostream>

class Logger : public ILogger
{
public:
    Logger();

    ~Logger();

    void v_info(const char* message, bool printToConsole = true);

    void v_warning(const char* message, bool printToConsole = true);

    void v_error(const char* message, bool printToConsole = true);

    bool v_add_output(const char* output_file_name);

protected:
    void write_log(const char* prefix, const char* message, bool printToConsole = true);
    std::vector<std::ofstream*> m_output_streams;

    const char* m_info_prefix = "INFO: ";
    const char* m_warning_prefix = "WARNING: ";
    const char* m_error_prefix = "ERROR: ";
};