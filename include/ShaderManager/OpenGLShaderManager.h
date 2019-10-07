#include <include/ShaderManager/IShaderManager.h>

#include <set>
#include <vector>
#include <fstream>
#include <sstream>

#include <glad/glad.h>
#include <GLFW/glfw3.h>

// Forward declarations
#include <include/Logger/ILogger.h>
extern ILogger* gp_logger;

class OpenGLShaderManager : public IShaderManager
{
public:
    OpenGLShaderManager();

    ~OpenGLShaderManager();

    unsigned int add_shader(const char* fragment_shader_path, const char* vertex_shader_path);
    bool use_shader(unsigned int shader_id);

protected:
    std::set<GLuint> m_shaders;

    bool compile_shader(const char* shader_path, GLuint shader_id);

    bool link_shaders(GLuint program_id, GLuint fragment_shader_id, GLuint vertex_shader_id);
};