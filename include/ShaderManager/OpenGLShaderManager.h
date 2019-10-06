#include <include/ShaderManager/IShaderManager.h>

#include <include/Logger/ILogger.h>

#include <map>
#include <vector>
#include <fstream>
#include <sstream>

#include <glad/glad.h>
#include <GLFW/glfw3.h>

// Forward declarations
extern ILogger* gp_logger;

class OpenGLShaderManager : public IShaderManager
{
public:
    OpenGLShaderManager();

    ~OpenGLShaderManager();

    bool add_shaders(const char* fragment_shader_path, const char* vertex_shader_path);

protected:
    std::map<const char*, GLuint> m_shader_name_to_program_id;

    bool compile_shader(const char* shader_path, GLuint shader_id);

    bool link_shaders(GLuint program_id, GLuint fragment_shader_id, GLuint vertex_shader_id);
};