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
    OpenGLSprite(
        unsigned int shader,
        float vertices[],
        int number_of_vertices,
        unsigned int indices[],
        int number_of_indices
    );
    bool v_draw();

protected:
    size_t m_number_of_vertices;
    float* m_vertices;

    size_t m_number_of_indices;
    unsigned int* m_indices;

    unsigned int m_vertex_array_object;
    unsigned int m_vertex_buffer_object;
    unsigned int m_element_buffer_object;
};
