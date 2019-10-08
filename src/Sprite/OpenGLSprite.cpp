#include <include/Sprite/OpenGLSprite.h>

OpenGLSprite::OpenGLSprite(unsigned int shader)
{
    this->m_shader = shader;
    
    glGenVertexArrays(1, &this->m_vertex_array_object);
    glGenBuffers(1, &this->m_vertex_buffer_object);
    
    glBindVertexArray(this->m_vertex_array_object);
    
    // Copy the vertices into an OpenGL buffer
    glBindBuffer(GL_ARRAY_BUFFER, this->m_vertex_buffer_object);
    glBufferData(
        GL_ARRAY_BUFFER,
        sizeof(this->m_vertices),
        this->m_vertices,
        GL_STATIC_DRAW
    );

    glVertexAttribPointer(
        0,
        3,
        GL_FLOAT,
        GL_FALSE,
        3 * sizeof(float),
        (void*)0
    );
    glEnableVertexAttribArray(0);

    glBindBuffer(GL_ARRAY_BUFFER, 0);

    glBindVertexArray(0);
}

bool OpenGLSprite::v_draw()
{
    if (this->m_shader && this->m_vertices)
    {
        gp_shader_manager->v_use_shader(this->m_shader);
        
        glBindVertexArray(this->m_vertex_array_object);
        glDrawArrays(GL_TRIANGLES, 0, 3);

        return true;
    }
    else
    {
        gp_logger->v_error("Failed to draw sprite");
        return false;
    }
}
