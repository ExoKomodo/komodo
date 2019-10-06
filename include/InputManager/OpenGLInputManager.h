#pragma once

#include <include/InputManager/IInputManager.h>
#include <include/Logger/ILogger.h>
#include <include/vector.h>
#include <include/VideoSystem/OpenGLVideoSystem.h>

#include <GLFW/glfw3.h>
#include <string>
#include <iostream>

// Forward declarations
extern ILogger* gp_logger;
extern IVideoSystem* gp_video_system;

class OpenGLInputManager : public IInputManager
{
public:
    bool m_is_shift_held;
    bool m_is_control_held;
    bool m_is_alt_held;
    bool m_is_super_held;

    bool m_is_cursor_focused;

    double m_cursor_x;
    double m_cursor_y;

    OpenGLInputManager();

    ~OpenGLInputManager();

    /*********
    * Cursor *
    **********/

    // Events

    void v_cursor_enter_event(bool didCursorEnter, bool debug = false);

    void v_cursor_position_event(double xPosition, double yPosition, bool debug = false);

    // Getters

    Vector2 v_get_cursor_position();

    /***********
    * Keyboard *
    ************/

    // Events

    void v_key_event(int key, int scancode, int action, int mods, bool debug = false);

    // Getters

    const char* v_get_key_name(int key);

    int v_get_key_state(int key);
};