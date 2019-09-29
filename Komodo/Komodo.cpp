#include "Komodo.h"

IDataFiles* gp_data_files = nullptr;
IAudioSystem* gp_audio_system = nullptr;
IVideoSystem* gp_video_system = nullptr;
ILogger* gp_logger = nullptr;

int main()
{
    if (!initialize_systems())
    {
        return 1;
    }

	gp_logger->info("Welcome to Komodo game engine!\n");

    gp_video_system->create_window(640, 480, "Komodo");

    bool done = false;
    while (!done)
    {
        done = true;
    }

    shutdown_systems();

	return 0;
}

bool initialize_systems()
{
    gp_logger = new Logger();
    if (!gp_logger || !gp_logger->Initialized)
    {
        std::cerr << "Logger failed to initialize!\n";
        return false;
    }

    gp_data_files = new DataFiles();
    if (!gp_data_files || !gp_data_files->Initialized)
    {
        std::cerr << "Data Files failed to initialize!\n";
        return false;
    }
    gp_audio_system= new AudioSystem();
    if (!gp_audio_system || !gp_audio_system->Initialized)
    {
        std::cerr << "Audio System failed to initialize!\n";
        return false;
    }
    gp_video_system = new VideoSystem();
    if (!gp_video_system || !gp_video_system->Initialized)
    {
        std::cerr << "Video System failed to initialize!\n";
        return false;
    }

    return true;
}

void shutdown_systems()
{
    gp_logger->info("Shutting down systems...\n");

    SAFE_DELETE(gp_video_system);
    SAFE_DELETE(gp_audio_system);
    SAFE_DELETE(gp_data_files);

    SAFE_DELETE(gp_logger);
}