#pragma once

class ISprite
{
public:
    unsigned int m_shader;

    virtual bool v_draw() = 0;
};
