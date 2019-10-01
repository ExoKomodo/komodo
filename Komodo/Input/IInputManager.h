#pragma once

#include <Komodo/include/vector.h>

class IInputManager
{
public:
    bool m_initialized = false;

    virtual ~IInputManager()
    {
        
    }

    /*********
    * Cursor *
    **********/

    // Events
    virtual void v_cursor_enter_event(bool didCursorEnter, bool debug = false) = 0;
    virtual void v_cursor_position_event(double xPosition, double yPosition, bool debug = false) = 0;

    // Getters
    virtual Vector2 v_get_cursor_position() = 0;

    /***********
    * Keyboard *
    ************/

    // Events
    virtual void v_key_event(int key, int scancode, int actions, int mods, bool debug = false) = 0;

    // Getters
    virtual const char* v_get_key_name(int key) = 0;
    virtual int v_get_key_state(int key) = 0;
};