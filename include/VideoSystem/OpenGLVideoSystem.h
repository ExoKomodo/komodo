#pragma once

#include <glad/glad.h>
#include <GLFW/glfw3.h>
#include <string>

// Forward declarations
#include <include/VideoSystem/IVideoSystem.h>
#include <include/Logger/ILogger.h>
#include <include/InputManager/IInputManager.h>
#include <include/SpriteManager/OpenGLSpriteManager.h>
extern IInputManager* gp_input_manager;
extern ILogger* gp_logger;
extern ISpriteManager* gp_sprite_manager;

class OpenGLVideoSystem : public IVideoSystem
{
public:
    GLFWwindow* m_window = nullptr;

    OpenGLVideoSystem();

    ~OpenGLVideoSystem();

    void v_close_window();

    bool v_create_window(int width = 0, int height = 0, const char* title = "");

    Vector2 v_get_screen_size();

    bool v_get_vsync_enabled();

    void v_set_vsync_enabled(bool vsync_enabled);

    void v_update();

    static void on_window_size_change(GLFWwindow* window, int width, int height);
   
protected:
    void setup_input_callbacks();

    static void glfw_error_callback(int error, const char* description);

    /*********
    * Cursor *
    **********/

    static void cursor_enter_callback(GLFWwindow* window, int didCursorEnter);

    static void cursor_position_callback(GLFWwindow* window, double xPosition, double yPosition);

    /***********
    * Keyboard *
    ************/
    static void key_callback(GLFWwindow* window, int key, int scancode, int actions, int mods);
};