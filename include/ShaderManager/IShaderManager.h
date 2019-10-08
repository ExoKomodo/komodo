#pragma once

class IShaderManager
{
public:
    bool m_initialized = false;

    virtual unsigned int v_add_shader(const char* fragment_shader_path, const char* vertex_shader_path) = 0;
    virtual bool v_use_shader(unsigned int shader_id) = 0;
};