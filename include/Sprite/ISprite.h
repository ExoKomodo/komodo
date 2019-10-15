#pragma once

#include <vector.h>

class ISprite
{
public:
    ISprite(
        unsigned int shader,
        Vector3 color=Vector3(),
        const char* texture_path=nullptr
    )
        : m_shader(shader)
        , m_color(color)
        , m_texture_path(texture_path)
        , m_texture_width(0)
        , m_texture_height(0)
        , m_number_of_color_channels(0)
        , m_texture_data(nullptr)
    {}

    unsigned int m_shader;
    Vector3 m_color;
    const char* m_texture_path;
    int m_texture_width;
    int m_texture_height;
    int m_number_of_color_channels;
    unsigned char* m_texture_data;

    virtual bool v_draw() = 0;
};
