#pragma once

#include <include/vector.h>

class IVideoSystem
{
public:
    bool m_initialized = false;
    bool m_closed = false;
    
    float m_clear_red = 0.2f;
    float m_clear_green = 0.3f;
    float m_clear_blue = 0.3f;
    float m_clear_alpha = 1.0f;

    virtual void v_close_window() = 0;
    virtual bool v_create_window(int width = 0, int height = 0, const char* title = "") = 0;
    virtual Vector2 v_get_screen_size() = 0;
    virtual bool v_get_vsync_enabled() = 0;
    virtual void v_set_vsync_enabled(bool vsynv_enabled) = 0;
    virtual void v_update() = 0;

protected:
    int m_width = 0;
    int m_height = 0;
    
    bool m_vsync_enabled = false;
};