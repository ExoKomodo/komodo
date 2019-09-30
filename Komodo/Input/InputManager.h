#pragma once

#include "IInputManager.h"
#include "../Logger/ILogger.h"
#include <GLFW/glfw3.h>
#include <string>

ILogger* gp_logger;

class InputManager : public IInputManager
{
public:
    InputManager()
    {
        this->m_initialized = true;
    }

    ~InputManager()
    {
        std::cout << "Successfully shutdown Input Manager!\n";
    }

    void key_event(int key, int scancode, int action, int mods)
    {
        std::string key_message(action == GLFW_PRESS ? "Pressed - " : "Released - ");
        switch (scancode)
        {
            /*case GLFW_KEY_LEFT_SHIFT:
            case GLFW_KEY_RIGHT_SHIFT:
                key_message.append("Shift");
                break;
            case GLFW_KEY_LEFT_ALT:
            case GLFW_KEY_RIGHT_ALT:
                key_message.append("Alt");
                break;
            case GLFW_KEY_LEFT_CONTROL:
            case GLFW_KEY_RIGHT_CONTROL:
                key_message.append("Control");
                break;
            case GLFW_KEY_LEFT_SUPER:
            case GLFW_KEY_RIGHT_SUPER:
                key_message.append("Super");
                break;*/
            default:
                key_message.append(glfwGetKeyName(key, scancode));
                break;
        }
        gp_logger->info(key_message.c_str());
    }
};