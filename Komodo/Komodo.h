#pragma once

#include <iostream>

#include <Komodo/include/macros.h>

#include "Audio/AudioSystem.h"

#include "DataFiles/DataFiles.h"

#include "Input/IInputManager.h"
#include "Input/OpenGLInputManager.h"

#include "Logger/Logger.h"

#include "Video/IVideoSystem.h"
#include "Video/OpenGLVideoSystem.h"

extern IDataFiles* gp_data_files = nullptr;
extern IAudioSystem* gp_audio_system = nullptr;
extern IVideoSystem* gp_video_system = nullptr;
extern IInputManager* gp_input_manager = nullptr;
extern ILogger* gp_logger = nullptr;

bool initialize_systems();
void shutdown_systems();