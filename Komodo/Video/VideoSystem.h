#pragma once

#include "IVideoSystem.h"
#include "../Input/IInputManager.h"

#include <GLFW/glfw3.h>

IInputManager* gp_input_manager;

class VideoSystem : public IVideoSystem
{
public:
    GLFWwindow* m_window = nullptr;

    VideoSystem()
    {
        if (glfwInit())
        {
            glfwSetErrorCallback(glfw_error_callback);

            m_initialized = true;
        }
    }

    ~VideoSystem()
    {
        glfwTerminate();
        std::cout << "Successfully shutdown Video System!\n";
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
            glfwSwapInterval(1);
            
            glfwGetFramebufferSize(this->m_window, &this->m_width, &this->m_height);
            on_window_size_change(this->m_window, this->m_width, this->m_height);
            glfwSetFramebufferSizeCallback(this->m_window, on_window_size_change);

            glfwSetWindowUserPointer(this->m_window, this);
            glfwSetKeyCallback(this->m_window, key_callback);
        }
        else
        {
            std::cerr << "Window creation failed!\n";
            return false;
        }
        return true;
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
                glClear(GL_COLOR_BUFFER_BIT);
                glfwSwapBuffers(this->m_window);
                glfwPollEvents();
            }
        }
    }

    static void on_window_size_change(GLFWwindow* window, int width, int height)
    {
        glViewport(0, 0, width, height);
        std::cout << "Resize to " << width << " by " << height << std::endl;
    }

protected:
    static void glfw_error_callback(int error, const char* description)
    {
        std::cerr << "GLFW Error: " << description << std::endl;
    }

    static void key_callback(GLFWwindow* window, int key, int scancode, int actions, int mods)
    {
        gp_input_manager->key_event(key, scancode, actions, mods);
    }
};