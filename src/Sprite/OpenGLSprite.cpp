#include <include/Sprite/OpenGLSprite.h>

OpenGLSprite::OpenGLSprite(
    unsigned int shader,
    float vertices[],
    int number_of_vertices,
    unsigned int indices[],
    int number_of_indices
)
{
    this->m_number_of_vertices = number_of_vertices;
    this->m_vertices = new float[this->m_number_of_vertices];
    for (size_t i = 0; i < this->m_number_of_vertices; ++i)
    {
        this->m_vertices[i] = vertices[i];
    }
    this->m_number_of_indices = number_of_indices;
    this->m_indices = new unsigned int[this->m_number_of_indices];
    for (size_t i = 0; i < this->m_number_of_indices; ++i)
    {
        this->m_indices[i] = indices[i];
    }
    this->m_shader = shader;
    
    // Generate buffers
    glGenVertexArrays(1, &this->m_vertex_array_object);
    glGenBuffers(1, &this->m_vertex_buffer_object);
    glGenBuffers(1, &this->m_element_buffer_object);
    
    glBindVertexArray(this->m_vertex_array_object);
    
    // Copy the vertices into an OpenGL buffer
    glBindBuffer(GL_ARRAY_BUFFER, this->m_vertex_buffer_object);
    glBufferData(
        GL_ARRAY_BUFFER,
        sizeof(float) * this->m_number_of_vertices,
        this->m_vertices,
        GL_STATIC_DRAW
    );

    // Copy the elements into an OpenGL buffer
    glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, this->m_element_buffer_object);
    glBufferData(
        GL_ELEMENT_ARRAY_BUFFER,
        sizeof(unsigned int) * this->m_number_of_indices,
        this->m_indices,
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
        glDrawElements(
            GL_TRIANGLES,
            this->m_number_of_indices,
            GL_UNSIGNED_INT,
            0
        );
        glBindVertexArray(0);

        return true;
    }
    else
    {
        gp_logger->v_error("Failed to draw sprite");
        return false;
    }
}
