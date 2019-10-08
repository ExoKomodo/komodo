#pragma once

#include <include/Sprite/ISprite.h>

#include <glad/glad.h>
#include <GLFW/glfw3.h>

// Forward declarations
#include <include/Logger/ILogger.h>
#include <include/ShaderManager/IShaderManager.h>
extern ILogger* gp_logger;
extern IShaderManager* gp_shader_manager;

class OpenGLSprite : public ISprite
{
public:
    OpenGLSprite(unsigned int shader = 0);
    bool v_draw();

protected:
    float m_vertices[9] = {
        -0.5f, -0.5f, 0.0f,
        0.5f, -0.5f, 0.0f,
        0.0f,  0.5f, 0.0f
    };
    unsigned int m_vertex_array_object;
    unsigned int m_vertex_buffer_object;
};
