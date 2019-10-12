#pragma once

#include <vector.h>

class ISprite
{
public:
    ISprite(
        unsigned int shader,
        Vector4 color=Vector4()
    )
        : m_shader(shader)
        , m_color(color)
    {}

    unsigned int m_shader;
    Vector4 m_color;

    virtual bool v_draw() = 0;
};
