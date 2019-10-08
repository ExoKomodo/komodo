#pragma once

#include <iostream>
#include <include/macros.h>

#include <include/AudioSystem/IAudioSystem.h>
#include <include/ConfigManager/IConfigManager.h>
#include <include/InputManager/IInputManager.h>
#include <include/Logger/ILogger.h>
#include <include/ShaderManager/IShaderManager.h>
#include <include/VideoSystem/IVideoSystem.h>

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

#include <include/AudioSystem/AudioSystem.h>
#include <include/ConfigManager/JsonConfigManager.h>
#include <include/InputManager/OpenGLInputManager.h>
#include <include/Logger/Logger.h>
#include <include/ShaderManager/OpenGLShaderManager.h>
#include <include/VideoSystem/OpenGLVideoSystem.h>

int game_loop();
bool initialize_systems();
int komodo_exit(int exit_code = 0);
void shutdown_systems();