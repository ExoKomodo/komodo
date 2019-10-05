#pragma once

#include <iostream>
#include <src/include/macros.h>

#include "AudioSystem/IAudioSystem.h"
#include "ConfigManager/IConfigManager.h"
#include "InputManager/IInputManager.h"
#include "Logger/ILogger.h"
#include "ShaderManager/IShaderManager.h"
#include "VideoSystem/IVideoSystem.h"

/*
    Need to be declared and defined before including implementations.
    Implementations contain forward declarations that will prevent compilation.
*/
IAudioSystem* gp_audio_system = nullptr;
IConfigManager* gp_config_manager = nullptr;
IInputManager* gp_input_manager = nullptr;
ILogger* gp_logger = nullptr;
IShaderManager* gp_shader_manager = nullptr;
IVideoSystem* gp_video_system = nullptr;

#include "AudioSystem/AudioSystem.h"
#include "ConfigManager/JsonConfigManager.h"
#include "InputManager/OpenGLInputManager.h"
#include "Logger/Logger.h"
#include "ShaderManager/OpenGLShaderManager.h"
#include "VideoSystem/OpenGLVideoSystem.h"

bool initialize_systems();
void shutdown_systems();
