#pragma once

class IShaderManager
{
public:
    bool m_initialized = false;

    virtual bool add_shaders(const char* fragment_shader_path, const char* vertex_shader_path) = 0;
};