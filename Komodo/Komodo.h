#pragma once

#include <iostream>

#include "macros.h"

#include "Audio/AudioSystem.h"
#include "DataFiles/DataFiles.h"
#include "Video/VideoSystem.h"
#include "Logger/Logger.h"

bool initialize_systems();
void shutdown_systems();
