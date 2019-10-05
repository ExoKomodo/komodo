#include "IShaderManager.h"

#include <set>
#include <fstream>
#include <sstream>

#include <glad/glad.h>
#include <GLFW/glfw3.h>

#include "../Logger/ILogger.h"

// Forward declarations
extern ILogger* gp_logger;

class OpenGLShaderManager : public IShaderManager
{
public:
    OpenGLShaderManager()
    {
        this->m_initialized = true;
    }

    ~OpenGLShaderManager()
    {
        gp_logger->v_info("Successfully shutdown OpenGL Shader Manager!");
    }

    bool add_shaders(const char* fragment_shader_path, const char* vertex_shader_path)
    {
        GLuint fragment_shader_id = glCreateShader(GL_FRAGMENT_SHADER);

        bool result = this->compile_shader(fragment_shader_path, fragment_shader_id);
        if (result)
        {
            GLuint vertex_shader_id = glCreateShader(GL_VERTEX_SHADER);

            result = this->compile_shader(vertex_shader_path, vertex_shader_id);
            if (result)
            {
                GLuint program_id = glCreateProgram();
                result = this->link_shaders(program_id, fragment_shader_id, vertex_shader_id);
                if (result)
                {
                    this->m_shader_name_to_program_id[fragment_shader_path] = program_id;
                    this->m_shader_name_to_program_id[vertex_shader_path] = program_id;
                }
                return result;
            }
            else
            {
                return false;   
            }
        }
        else
        {
            return false;
        }
    }

protected:
    std::map<const char*, GLuint> m_shader_name_to_program_id;

    bool compile_shader(const char* shader_path, GLuint shader_id)
    {
        std::string shader_contents;
        std::ifstream shader_stream(shader_path, std::ios::in);
        if (shader_stream.is_open())
        {
            std::stringstream sstr;
            sstr << shader_stream.rdbuf();
            shader_contents = sstr.str();
            shader_stream.close();
        }
        else
        {
            std::string message("Could not open shader ");
            message.append(shader_path);
            gp_logger->v_error(message.c_str());
            return false;
        }
        std::string message("Compiling shader: ");
        message.append(shader_path);
        gp_logger->v_info(message.c_str());

        char const* vertex_source = shader_contents.c_str();
        glShaderSource(shader_id, 1, &vertex_source , nullptr);
        glCompileShader(shader_id);

        // Check Shader
        GLint result = GL_FALSE;
        glGetShaderiv(shader_id, GL_COMPILE_STATUS, &result);

        int info_log_length;
        glGetShaderiv(shader_id, GL_INFO_LOG_LENGTH, &info_log_length);
        if (info_log_length > 0 )
        {
            std::vector<char> shader_error_message(info_log_length + 1);
            glGetShaderInfoLog(shader_id, info_log_length, nullptr, &shader_error_message[0]);
            gp_logger->v_error(&shader_error_message[0]);
            
            return false;
        }
        return true;
    }

    bool link_shaders(GLuint program_id, GLuint fragment_shader_id, GLuint vertex_shader_id)
    {
	    glAttachShader(program_id, fragment_shader_id);
        glAttachShader(program_id, vertex_shader_id);
        glLinkProgram(program_id);

        // Check Program
        GLint result = GL_FALSE;
        glGetProgramiv(program_id, GL_LINK_STATUS, &result);

        int info_log_length;
        glGetProgramiv(program_id, GL_INFO_LOG_LENGTH, &info_log_length);
        if (info_log_length > 0)
        {
            std::vector<char> program_error_message(info_log_length + 1);
            glGetProgramInfoLog(program_id, info_log_length, NULL, &program_error_message[0]);
            gp_logger->v_error(&program_error_message[0]);

            return false;
        }
        
        glDetachShader(program_id, fragment_shader_id);
        glDeleteShader(fragment_shader_id);
        
        glDetachShader(program_id, vertex_shader_id);
        glDeleteShader(vertex_shader_id);

        return true;
    }
};