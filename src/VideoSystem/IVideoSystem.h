#pragma once

class IVideoSystem
{
public:
    bool m_initialized;
    bool m_closed;
    
    float m_clear_red;
    float m_clear_green;
    float m_clear_blue;
    float m_clear_alpha;

    IVideoSystem()
    {
        this->m_initialized = false;
        this->m_closed = false;

        this->m_clear_red = 0;
        this->m_clear_green = 0;
        this->m_clear_blue = 0;
        this->m_clear_alpha = 1;

        this->m_width = 0;
        this->m_height = 0;
        this->m_vsync_enabled = false;
    }

    virtual ~IVideoSystem()
    {
        
    }

    virtual void v_close_window() = 0;
    virtual bool v_create_window(int width = 0, int height = 0, const char* title = "") = 0;
    virtual Vector2 v_get_screen_size() = 0;
    virtual bool v_get_vsync_enabled() = 0;
    virtual void v_set_vsync_enabled(bool vsynv_enabled) = 0;
    virtual void v_update() = 0;

protected:
    int m_width;
    int m_height;
    
    bool m_vsync_enabled;
};