#pragma once

#include "ILogger.h"
#include <string>
#include <pugixml.hpp>
#include <fstream>
#include <filesystem>

class Logger : public ILogger
{
public:
    Logger(const char* log_file_name = nullptr)
    {
        if (log_file_name)
        {
            std::filesystem::path full_path = std::filesystem::current_path() / log_file_name;
            this->m_log_file.open(full_path.string(), std::ios::out | std::ios::trunc);
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

    virtual void info(const char* message)
    {
        if (message != nullptr)
        {
            this->write_log(this->m_info_prefix, message);
        }
    }

    virtual void warning(const char* message)
    {
        if (message != nullptr)
        {
            this->write_log(this->m_warning_prefix, message);
        }
    }

    virtual void error(const char* message)
    {
        if (message != nullptr)
        {
            this->write_log(this->m_error_prefix, message);
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

    void write_log(const char* prefix, const char* message)
    {
        std::string log_message(prefix);
        log_message.append(": ");
        log_message.append(message);
        std::cout << log_message << std::endl;
        if (this->m_log_file)
        {
            this->write_to_xml(prefix, log_message.c_str());
        }
    }
};