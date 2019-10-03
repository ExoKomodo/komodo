#include "Komodo.h"

int main()
{
    int return_code = 0;
    if (!initialize_systems())
    {
        return_code = 1;
    }
    else
    {
        gp_logger->v_add_output("komodo.log");
        gp_logger->v_info("Welcome to Komodo game engine!");

        if (gp_video_system->v_create_window(640, 480, "Komodo"))
        {
            bool done = false;
            if (
                !gp_shader_manager->add_shaders(
                    "shaders/openGL/simple/fragment_shader.glsl",
                    "shaders/openGL/simple/vertex_shader.glsl"
                )
            )
            {
                return_code = 3;
                done = true;
            }
            while (!done)
            {
                gp_video_system->v_update();
                if (gp_video_system->m_closed)
                {
                    done = true;
                }
            }
        }
        else
        {
            return_code = 2;
        }
        
    }
    shutdown_systems();

	return return_code;
}

bool initialize_systems()
{
    gp_logger = new Logger();
    if (!gp_logger || !gp_logger->m_initialized)
    {
        std::cerr << "Logger failed to initialize!";
        return false;
    }

    gp_config_manager = new JsonConfigManager();
    if (!gp_config_manager || !gp_config_manager->m_initialized)
    {
        std::cerr << "Config Manager failed to initialize!";
        return false;
    }

    gp_input_manager = new OpenGLInputManager();
    if (!gp_input_manager || !gp_input_manager->m_initialized)
    {
        std::cerr << "Input Manager failed to initialize!";
        return false;
    }
    
    gp_audio_system = new AudioSystem();
    if (!gp_audio_system || !gp_audio_system->m_initialized)
    {
        std::cerr << "Audio System failed to initialize!";
        return false;
    }
    
    gp_video_system = new OpenGLVideoSystem();
    if (!gp_video_system || !gp_video_system->m_initialized)
    {
        std::cerr << "Video System failed to initialize!";
        return false;
    }

    gp_shader_manager = new OpenGLShaderManager();
    if (!gp_shader_manager || !gp_shader_manager->m_initialized)
    {
        std::cerr << "Shader Manager failed to initialize!";
        return false;
    }

    return true;
}

void shutdown_systems()
{
    gp_logger->v_info("Shutting down systems...");

    SAFE_DELETE(gp_shader_manager);
    SAFE_DELETE(gp_video_system);
    SAFE_DELETE(gp_audio_system);
    SAFE_DELETE(gp_input_manager);
    SAFE_DELETE(gp_config_manager);

    SAFE_DELETE(gp_logger);
}