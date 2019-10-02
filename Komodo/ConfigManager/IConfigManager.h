#pragma once

class IConfigManager
{
public:
    bool m_initialized = false;

    virtual ~IConfigManager()
    {

    }

    virtual bool v_get_config_value_from_file(const char* config_file_name, const char* config_key, int* config_value) = 0;
    virtual bool v_get_config_value_from_file(const char* config_file_name, const char* config_key, double* config_value) = 0;
    virtual bool v_get_config_value_from_file(const char* config_file_name, const char* config_key, char** config_value) = 0;
};