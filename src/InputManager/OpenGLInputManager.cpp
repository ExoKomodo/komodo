#include <include/InputManager/OpenGLInputManager.h>

OpenGLInputManager::OpenGLInputManager()
{
    this->m_is_shift_held = false;
    this->m_is_control_held = false;
    this->m_is_alt_held = false;
    this->m_is_super_held = false;

    this->m_is_cursor_focused = false;

    this->m_cursor_x = -1;
    this->m_cursor_y = -1;

    this->m_initialized = true;
}

OpenGLInputManager::~OpenGLInputManager()
{
    std::cout << "Successfully shutdown Input Manager!\n";
}

/*********
* Cursor *
**********/

// Events

void OpenGLInputManager::v_cursor_enter_event(bool didCursorEnter, bool debug)
{
    if (debug)
    {
        gp_logger->v_info(didCursorEnter ? "Cursor entered" : "Cursor left", true);
    }
    this->m_is_cursor_focused = didCursorEnter;
}

void OpenGLInputManager::v_cursor_position_event(double xPosition, double yPosition, bool debug)
{
    if (debug)
    {
        std::string mouse_message("Mouse moved to ");
        mouse_message.append("x: " + std::to_string(xPosition) + " y: " + std::to_string(yPosition));
        gp_logger->v_info(mouse_message.c_str(), true);
    }
    this->m_cursor_x = xPosition;
    this->m_cursor_y = yPosition;
}

// Getters

Vector2 OpenGLInputManager::v_get_cursor_position()
{
    return Vector2(this->m_cursor_x, this->m_cursor_y);
}

/***********
* Keyboard *
************/

// Events

void OpenGLInputManager::v_key_event(int key, int scancode, int action, int mods, bool debug)
{
    m_is_shift_held = (mods & GLFW_MOD_SHIFT) == GLFW_MOD_SHIFT;
    m_is_control_held = (mods & GLFW_MOD_CONTROL) == GLFW_MOD_CONTROL;
    m_is_alt_held = (mods & GLFW_MOD_ALT) == GLFW_MOD_ALT;
    m_is_super_held = (mods & GLFW_MOD_SUPER) == GLFW_MOD_SUPER;

    switch (key)
    {
        case GLFW_KEY_LEFT_SHIFT:
        case GLFW_KEY_RIGHT_SHIFT:
        case GLFW_KEY_LEFT_ALT:
        case GLFW_KEY_RIGHT_ALT:
        case GLFW_KEY_LEFT_CONTROL:
        case GLFW_KEY_RIGHT_CONTROL:
        case GLFW_KEY_LEFT_SUPER:
        case GLFW_KEY_RIGHT_SUPER:
            break;
        default:
            if (debug)
            {
                std::string key_message;
                switch (action)
                {
                case GLFW_PRESS:
                    key_message = "Pressed  - ";
                    break;
                case GLFW_REPEAT:
                    key_message = "Repeated - ";
                    break;
                case GLFW_RELEASE:
                    key_message = "Released - ";
                    break;
                }
                key_message.append(glfwGetKeyName(key, scancode));
                gp_logger->v_info(key_message.c_str(), true);
            }
            break;
    }
}

// Getters

const char* OpenGLInputManager::v_get_key_name(int key)
{
    return glfwGetKeyName(key, 0);
}

int OpenGLInputManager::v_get_key_state(int key)
{
    GLFWwindow* window = static_cast<OpenGLVideoSystem*>(gp_video_system)->m_window;
    return glfwGetKey(window, key);
}