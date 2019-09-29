#pragma once

#include <include/ConfigManager/IConfigManager.h>

#include <include/Logger/Logger.h>

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
    JsonConfigManager();

    ~JsonConfigManager();

    bool v_get_config_value_from_file(const char* config_file_name, const char* config_key, int* config_value);
    
    bool v_get_config_value_from_file(const char* config_file_name, const char* config_key, double* config_value);

    bool v_get_config_value_from_file(const char* config_file_name, const char* config_key, char** config_value);

protected:
    std::map<const char*, nlohmann::json*> m_config_file_to_json;

    nlohmann::json* get_json_from_config_file(const char* config_file_name);
};