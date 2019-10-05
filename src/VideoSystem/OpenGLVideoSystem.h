#pragma once

#include <glad/glad.h>
#include <GLFW/glfw3.h>

#include "IVideoSystem.h"
#include "../Logger/ILogger.h"
#include "../InputManager/IInputManager.h"

// Forward declarations
extern IInputManager* gp_input_manager;
extern ILogger* gp_logger;

class OpenGLVideoSystem : public IVideoSystem
{
public:
    GLFWwindow* m_window = nullptr;

    OpenGLVideoSystem()
    {
        if (glfwInit())
        {
            glfwSetErrorCallback(glfw_error_callback);
            
            glfwWindowHint(GLFW_CONTEXT_VERSION_MAJOR, 3);
            glfwWindowHint(GLFW_CONTEXT_VERSION_MINOR, 3);
            glfwWindowHint(GLFW_OPENGL_PROFILE, GLFW_OPENGL_CORE_PROFILE);
            glfwWindowHint(GLFW_OPENGL_FORWARD_COMPAT, GL_TRUE);

            this->m_initialized = true;
        }
    }

    ~OpenGLVideoSystem()
    {
        glfwTerminate();
        gp_logger->v_info("Successfully shutdown OpenGL Video System!");
    }

    void v_close_window()
    {
        glfwDestroyWindow(this->m_window);
        this->m_window = nullptr;
        this->m_closed = true;
    }

    bool v_create_window(int width = 0, int height = 0, const char* title = "")
    {
        this->m_window = glfwCreateWindow(width, height, title, NULL, NULL);
        if (this->m_window)
        {
            glfwMakeContextCurrent(this->m_window);
            if (!gladLoadGLLoader((GLADloadproc) glfwGetProcAddress))
            {
                gp_logger->v_error("Failed to initialize GLAD");
                return false;
            }
            glfwSwapInterval(this->m_vsync_enabled ? 1 : 0);
            
            glfwGetFramebufferSize(this->m_window, &this->m_width, &this->m_height);
            on_window_size_change(this->m_window, this->m_width, this->m_height);
            glfwSetFramebufferSizeCallback(this->m_window, on_window_size_change);

            setup_input_callbacks();
        }
        else
        {
            gp_logger->v_error("Window creation failed!");
            return false;
        }
        return true;
    }

    Vector2 v_get_screen_size()
    {
        return Vector2(this->m_width, this->m_height);
    }

    bool v_get_vsync_enabled()
    {
        return this->m_vsync_enabled;
    }

    void v_set_vsync_enabled(bool vsync_enabled)
    {
        this->m_vsync_enabled = vsync_enabled ? 1 : 0;
    }

    void v_update()
    {
        if (this->m_window)
        {
            if (glfwWindowShouldClose(this->m_window))
            {
                this->v_close_window();
            }
            else
            {
                glClearColor(m_clear_red, m_clear_green, m_clear_blue, m_clear_alpha);
                glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
                glfwSwapBuffers(this->m_window);
                glfwPollEvents();
            }
        }
    }

    static void on_window_size_change(GLFWwindow* window, int width, int height)
    {
        glViewport(0, 0, width, height);
        
        std::string message("Resizing window to ");
        message.append(std::to_string(width));
        message.append(" by ");
        message.append(std::to_string(height));

        gp_logger->v_info(message.c_str());
    }
   
protected:
    void setup_input_callbacks()
    {
        glfwSetWindowUserPointer(this->m_window, this);
        
        glfwSetCursorEnterCallback(this->m_window, cursor_enter_callback);
        glfwSetCursorPosCallback(this->m_window, cursor_position_callback);

        glfwSetKeyCallback(this->m_window, key_callback);
    }

    static void glfw_error_callback(int error, const char* description)
    {
        std::string message("GLFW Error: ");
        message.append(description);

        gp_logger->v_error(message.c_str());
    }

    /*********
    * Cursor *
    **********/

    static void cursor_enter_callback(GLFWwindow* window, int didCursorEnter)
    {
        gp_input_manager->v_cursor_enter_event(didCursorEnter);
    }

    static void cursor_position_callback(GLFWwindow* window, double xPosition, double yPosition)
    {
        gp_input_manager->v_cursor_position_event(xPosition, yPosition);
    }

    /***********
    * Keyboard *
    ************/
    static void key_callback(GLFWwindow* window, int key, int scancode, int actions, int mods)
    {
        gp_input_manager->v_key_event(key, scancode, actions, mods);
    }
};