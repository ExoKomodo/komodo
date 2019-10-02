#pragma once

#include <iostream>

#include <Komodo/include/macros.h>

#include "Audio/AudioSystem.h"

#include "ConfigManager/IConfigManager.h"
#include "ConfigManager/JsonConfigManager.h"

#include "Input/IInputManager.h"
#include "Input/OpenGLInputManager.h"

#include "Logger/ILogger.h"
#include "Logger/Logger.h"

#include "Video/IVideoSystem.h"
#include "Video/OpenGLVideoSystem.h"

extern IAudioSystem* gp_audio_system = nullptr;
extern IConfigManager* gp_config_manager = nullptr;
extern IInputManager* gp_input_manager = nullptr;
extern ILogger* gp_logger = nullptr;
extern IVideoSystem* gp_video_system = nullptr;

bool initialize_systems();
void shutdown_systems();