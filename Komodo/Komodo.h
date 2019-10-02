#pragma once

#include <iostream>
#include <Komodo/include/macros.h>

#include "Audio/IAudioSystem.h"
#include "ConfigManager/IConfigManager.h"
#include "Input/IInputManager.h"
#include "Logger/ILogger.h"
#include "Video/IVideoSystem.h"

/*
    Need to be declared and defined before including implementations.
    Implementations contain forward declarations that will prevent compilation.
*/
IAudioSystem* gp_audio_system = nullptr;
IConfigManager* gp_config_manager = nullptr;
IInputManager* gp_input_manager = nullptr;
ILogger* gp_logger = nullptr;
IVideoSystem* gp_video_system = nullptr;

#include "Audio/AudioSystem.h"
#include "ConfigManager/JsonConfigManager.h"
#include "Input/OpenGLInputManager.h"
#include "Logger/Logger.h"
#include "Video/OpenGLVideoSystem.h"

bool initialize_systems();
void shutdown_systems();
