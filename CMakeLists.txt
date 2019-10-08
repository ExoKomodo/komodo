# CMakeList.txt : Top-level CMake project file, do global configuration
# and include sub-projects here.
#
cmake_minimum_required (VERSION 3.10)

set(CMAKE_CXX_STANDARD 17)
set(CMAKE_CXX_STANDARD_REQUIRED ON)

# Project setup
project(Komodo)
add_executable(Komodo 
    ${PROJECT_SOURCE_DIR}/src/Komodo.cpp
)

# Add includes
target_include_directories(Komodo
    PRIVATE ${PROJECT_SOURCE_DIR}/include
)

# Add sources

## Audio System
target_sources(Komodo
    PRIVATE ${PROJECT_SOURCE_DIR}/src/AudioSystem/AudioSystem.cpp
)

## Config Manager
target_sources(Komodo
    PRIVATE ${PROJECT_SOURCE_DIR}/src/ConfigManager/JsonConfigManager.cpp
)

## Input Manager
target_sources(Komodo
    PRIVATE ${PROJECT_SOURCE_DIR}/src/InputManager/OpenGLInputManager.cpp
)

## Logger
target_sources(Komodo
    PRIVATE ${PROJECT_SOURCE_DIR}/src/Logger/Logger.cpp
)

## Shader Manager
target_sources(Komodo
    PRIVATE ${PROJECT_SOURCE_DIR}/src/ShaderManager/OpenGLShaderManager.cpp
)

## Sprite
target_sources(Komodo
    PRIVATE ${PROJECT_SOURCE_DIR}/src/Sprite/OpenGLSprite.cpp
)

## Sprite Manager
target_sources(Komodo
    PRIVATE ${PROJECT_SOURCE_DIR}/src/SpriteManager/OpenGLSpriteManager.cpp
)

## Video System
target_sources(Komodo
    PRIVATE ${PROJECT_SOURCE_DIR}/src/VideoSystem/OpenGLVideoSystem.cpp
)

list(APPEND CMAKE_MODULE_PATH ${PROJECT_SOURCE_DIR}/cmake)

# Add third-party tools

## GLFW
add_subdirectory(glfw)
include_directories(glfw/include)

target_link_libraries(Komodo glfw ${GLFW_LIBRARIES} ${OPENGL_glu_LIBRARY})

## GLAD
set(GLAD_DIR "glad")
add_library("glad" "${GLAD_DIR}/src/glad.c")
target_include_directories("glad" PRIVATE "${GLAD_DIR}/include")
target_include_directories(Komodo PRIVATE "${GLAD_DIR}/include")
target_link_libraries(Komodo "glad" "${CMAKE_DL_LIBS}")

## OpenGL
find_package(OpenGL REQUIRED)
target_include_directories(Komodo PUBLIC ${OPENGL_INCLUDE_DIR})
target_link_libraries(Komodo ${OPENGL_gl_LIBRARY})

## GLM
find_package(glm REQUIRED)
target_include_directories(Komodo PUBLIC ${GLM_INCLUDE_DIR})

## nhlomann json
set(JSON_BuildTests OFF CACHE INTERNAL "")
add_subdirectory(nhlomann)