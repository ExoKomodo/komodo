#pragma once

class IInputManager
{
public:
    bool m_initialized = false;

    virtual ~IInputManager()
    {
        
    }

    virtual void key_event(int key, int scancode, int actions, int mods) = 0;
};