# CMakeList.txt : Top-level CMake project file, do global configuration
# and include sub-projects here.
#
cmake_minimum_required (VERSION 3.8)
cmake_policy(SET CMP0079 NEW)

set(CMAKE_CXX_STANDARD 17)
set(CMAKE_CXX_STANDARD_REQUIRED ON)

project (Komodo)

# Include sub-projects.
add_subdirectory (Komodo)

list(APPEND CMAKE_MODULE_PATH ${PROJECT_SOURCE_DIR}/cmake)

# GLFW
find_package(glfw3 3.3 REQUIRED)
target_link_libraries(Komodo glfw3)

find_package(OpenGL REQUIRED)
target_include_directories(Komodo PUBLIC ${OPENGL_INCLUDE_DIR})
target_link_libraries(Komodo ${OPENGL_gl_LIBRARY})
target_link_libraries(Komodo ${OPENGL_glu_LIBRARY})

# GLM
find_package(glm REQUIRED)
target_include_directories(Komodo PUBLIC ${GLM_INCLUDE_DIR})

# json
set(JSON_BuildTests OFF CACHE INTERNAL "")
add_subdirectory(nhlomann)
#add_library(komodo ...)
#target_link_libraries(komodo PRIVATE nlohmann_json::nlohmann_json)