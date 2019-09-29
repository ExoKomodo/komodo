#pragma once

#include "IVideoSystem.h"

#include <GLFW/glfw3.h>

class VideoSystem : public IVideoSystem
{
public:
    GLFWwindow* window = nullptr;

    VideoSystem()
    {
        if (glfwInit())
        {
            glfwSetErrorCallback(glfw_error_callback);
            Initialized = true;
        }
    }

    ~VideoSystem()
    {
        glfwTerminate();
        std::cout << "Successfully shutdown Video System!\n";
    }

    bool create_window(int width = 0, int height = 0, const char* title = "")
    {
        this->window = glfwCreateWindow(width, height, title, NULL, NULL);
        if (!this->window)
        {
            std::cerr << "Window creation failed!\n";
            return false;
        }
        return true;
    }

protected:
    static void glfw_error_callback(int error, const char* description)
    {
        std::cerr << "GLFW Error: " << description << std::endl;
    }
};