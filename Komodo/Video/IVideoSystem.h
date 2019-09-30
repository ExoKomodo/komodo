#pragma once

class IVideoSystem
{
public:
    bool m_initialized = false;
    bool m_closed = false;
    
    float m_clear_red = 0;
    float m_clear_green = 0;
    float m_clear_blue = 0;
    float m_clear_alpha = 1;

    virtual ~IVideoSystem()
    {

    }

    virtual void v_close_window() = 0;
    virtual bool v_create_window(int width = 0, int height = 0, const char* title = "") = 0;
    virtual void v_update() = 0;

protected:
    int m_width = 0;
    int m_height = 0;
};