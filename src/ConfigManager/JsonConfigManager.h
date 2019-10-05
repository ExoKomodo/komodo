#pragma once

#include "IConfigManager.h"

#include <map>
#include <nhlomann/single_include/nlohmann/json.hpp>
#include <fstream>
#include <string>
#include <iostream>

// Forward declarations
extern ILogger* gp_logger;

class JsonConfigManager : public IConfigManager
{
public:
    JsonConfigManager()
    {
        this->m_initialized = true;
    }

    ~JsonConfigManager()
    {
        std::cout << "Successfully shutdown Json Config Manager!\n";
    }

    bool v_get_config_value_from_file(const char* config_file_name, const char* config_key, int* config_value)
    {
        auto json = this->get_json_from_config_file(config_file_name);
        if (json)
        {
            *config_value = json->value(config_key, -1);
            return true;
        }
        return false;
    }
    
    bool v_get_config_value_from_file(const char* config_file_name, const char* config_key, double* config_value)
    {
        auto json = this->get_json_from_config_file(config_file_name);
        if (json)
        {
            *config_value = json->value(config_key, -1);
            return true;
        }
        return false;
    }

    bool v_get_config_value_from_file(const char* config_file_name, const char* config_key, char** config_value)
    {
        auto json = this->get_json_from_config_file(config_file_name);
        if (json)
        {
            char* value = json->value(config_key, nullptr);

            if (value != nullptr)
            {
                *config_value = value;
                return true;
            }
        }
        return false;
    }

protected:
    std::map<const char*, nlohmann::json*> m_config_file_to_json;

    nlohmann::json* get_json_from_config_file(const char* config_file_name)
    {
        if (this->m_config_file_to_json.count(config_file_name) == 0)
        {
            std::ofstream config_file;
            config_file.open(config_file_name);
            if (!config_file.is_open())
            {
                std::string error_message("Failed to open config file ");
                error_message.append(config_file_name);
                gp_logger->v_error(error_message.c_str());
                return nullptr;
            }
            nlohmann::json config_json;
            this->m_config_file_to_json[config_file_name] = &config_json;
        }

        return this->m_config_file_to_json[config_file_name];
    }
};