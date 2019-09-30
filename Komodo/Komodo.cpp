#include "Komodo.h"

int main()
{
    if (!initialize_systems())
    {
        return 1;
    }

	gp_logger->info("Welcome to Komodo game engine!");

    gp_video_system->v_create_window(640, 480, "Komodo");

    bool done = false;
    while (!done)
    {
        gp_video_system->v_update();
        if (gp_video_system->m_closed)
        {
            done = true;
        }
    }

    shutdown_systems();

	return 0;
}

bool initialize_systems()
{
    gp_logger = new Logger("log.xml");
    if (!gp_logger || !gp_logger->m_initialized)
    {
        std::cerr << "Logger failed to initialize!";
        return false;
    }

    gp_data_files = new DataFiles();
    if (!gp_data_files || !gp_data_files->m_initialized)
    {
        std::cerr << "Data Files failed to initialize!";
        return false;
    }

    gp_input_manager = new InputManager();
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
    
    gp_video_system = new VideoSystem();
    if (!gp_video_system || !gp_video_system->m_initialized)
    {
        std::cerr << "Video System failed to initialize!";
        return false;
    }

    return true;
}

void shutdown_systems()
{
    gp_logger->info("Shutting down systems...");

    SAFE_DELETE(gp_video_system);
    SAFE_DELETE(gp_audio_system);
    SAFE_DELETE(gp_input_manager);
    SAFE_DELETE(gp_data_files);

    SAFE_DELETE(gp_logger);
}