#pragma once

#include "ILogger.h"
#include <string>
#include <pugixml.hpp>
#include <fstream>

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
                this->m_xml_document = new pugi::xml_document();
                this->m_root_node = this->m_xml_document->append_child("logs");
            }
        }
        m_initialized = true;
    }

    ~Logger()
    {
        if (this->m_log_file)
        {
            if (this->m_xml_document)
            {
                this->m_xml_document->save(this->m_log_file);
            }
            this->m_log_file.close();
        }
        if (this->m_xml_document)
        {
            SAFE_DELETE(this->m_xml_document);
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
    pugi::xml_document* m_xml_document = nullptr;
    pugi::xml_node m_root_node;
    std::ofstream m_log_file;

    const char* m_info_prefix = "INFO";
    const char* m_warning_prefix = "WARNING";
    const char* m_error_prefix = "ERROR";

    void write_to_xml(const char* node_name, const char* message)
    {
        auto new_node = this->m_root_node.append_child(node_name);
        new_node.append_child(pugi::node_pcdata).set_value(message);
    }

    void write_log(const char* prefix, const char* message, bool printToConsole = true)
    {
        std::string log_message(prefix);
        log_message.append(": ");
        log_message.append(message);
        if (printToConsole)
        {
            std::cout << log_message << std::endl;
        }
        if (this->m_log_file)
        {
            this->write_to_xml(prefix, log_message.c_str());
        }
    }
};