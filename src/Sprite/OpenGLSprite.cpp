#include <include/Sprite/OpenGLSprite.h>

OpenGLSprite::OpenGLSprite(
    unsigned int shader,
    float vertices[],
    int number_of_vertices,
    unsigned int indices[],
    int number_of_indices,
    Vector3 color,
    const char* texture_path
)
    : ISprite(
        shader,
        color,
        texture_path
    )
    , m_number_of_vertices(number_of_vertices)
    , m_number_of_indices(number_of_indices)
{
    this->m_vertices = new float[this->m_number_of_vertices];
    for (size_t i = 0; i < this->m_number_of_vertices; ++i)
    {
        this->m_vertices[i] = vertices[i];
    }
    this->m_indices = new unsigned int[this->m_number_of_indices];
    for (size_t i = 0; i < this->m_number_of_indices; ++i)
    {
        this->m_indices[i] = indices[i];
    }

    size_t number_of_element_vertices =
        this->m_number_of_vertices // Vertices
        * 2                        // Colors
        + (                        // Texture coordinates
            this->m_number_of_vertices * 2 / 3
        );
    this->m_element_vertices = new float[number_of_element_vertices];
    for (size_t i = 0; i < this->m_number_of_vertices; i++)
    {
        size_t index = (i % 3) + (8 * (i / 3));
        this->m_element_vertices[index] = this->m_vertices[i];
    }
    for (size_t i = 0; i < this->m_number_of_vertices / 3; i++)
    {
        this->m_element_vertices[0 + 3 + i*8] = this->m_color.x;
        this->m_element_vertices[1 + 3 + i*8] = this->m_color.y;
        this->m_element_vertices[2 + 3 + i*8] = this->m_color.z;
    }

    this->m_element_vertices[6] = 1.0f;
    this->m_element_vertices[7] = 1.0f;

    this->m_element_vertices[14] = 1.0f;
    this->m_element_vertices[15] = 0.0f;

    this->m_element_vertices[22] = 0.0f;
    this->m_element_vertices[23] = 0.0f;

    this->m_element_vertices[30] = 0.0f;
    this->m_element_vertices[31] = 1.0f;
    
    // Generate buffers
    glGenVertexArrays(1, &this->m_vertex_array_object);
    glGenBuffers(1, &this->m_vertex_buffer_object);
    glGenBuffers(1, &this->m_element_buffer_object);
    
    glBindVertexArray(this->m_vertex_array_object);
    
    // Copy the vertices into an OpenGL buffer
    glBindBuffer(GL_ARRAY_BUFFER, this->m_vertex_buffer_object);
    glBufferData(
        GL_ARRAY_BUFFER,
        sizeof(float) * number_of_element_vertices,
        this->m_element_vertices,
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

    // Position pointer
    glVertexAttribPointer(
        0,
        3,
        GL_FLOAT,
        GL_FALSE,
        8 * sizeof(float),
        (void*)0
    );
    glEnableVertexAttribArray(0);

    // Color pointer
    glVertexAttribPointer(
        1,
        3,
        GL_FLOAT,
        GL_FALSE,
        8 * sizeof(float),
        (void*)(3 * sizeof(float))
    );
    glEnableVertexAttribArray(1);
    
    // Texture Coordinate pointer
    glVertexAttribPointer(
        2,
        2,
        GL_FLOAT,
        GL_FALSE,
        8 * sizeof(float),
        (void*)(6 * sizeof(float))
    );
    glEnableVertexAttribArray(2);

    if (this->m_texture_path)
    {
        this->m_texture_data = stbi_load(
            this->m_texture_path,
            &this->m_texture_width,
            &this->m_texture_height,
            &this->m_number_of_color_channels,
            0
        ); 
        if (this->m_texture_data)
        {
            glGenTextures(1, &this->m_texture);
            glBindTexture(GL_TEXTURE_2D, this->m_texture);

            glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, GL_REPEAT);
            glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, GL_REPEAT);

            glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR);
            glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR);

            glTexImage2D(
                GL_TEXTURE_2D,
                0,                      // Mipmap level
                GL_RGB,                 // Storage format
                this->m_texture_width,
                this->m_texture_height,
                0,                      // Should always be 0
                GL_RGB,                 // What storage format?
                GL_UNSIGNED_BYTE,       // What storage data type?
                this->m_texture_data
            );
            glGenerateMipmap(GL_TEXTURE_2D);
        }
        else
        {
            gp_logger->v_error("Failed to load texture file\n");
        }
        stbi_image_free(this->m_texture_data);
    }
}

OpenGLSprite::~OpenGLSprite()
{
    delete this->m_vertices;
    this->m_vertices = nullptr;

    delete this->m_indices;
    this->m_indices = nullptr;

    delete this->m_element_vertices;
    this->m_element_vertices = nullptr;
}

bool OpenGLSprite::v_draw()
{
    if (this->m_shader && this->m_vertices)
    {
        float timeValue = glfwGetTime();
        this->m_color.x = 1.0f;
        this->m_color.y = 1.0f;
        this->m_color.z = 1.0f;
        
        if (this->m_texture)
        {
            glBindTexture(GL_TEXTURE_2D, this->m_texture);
        }
        gp_shader_manager->v_use_shader(this->m_shader);
        glBindVertexArray(this->m_vertex_array_object);
        glDrawElements(
            GL_TRIANGLES,
            this->m_number_of_indices,
            GL_UNSIGNED_INT,
            0
        );

        return true;
    }
    else
    {
        gp_logger->v_error("Failed to draw sprite");
        return false;
    }
}
