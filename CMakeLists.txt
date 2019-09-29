# CMakeList.txt : Top-level CMake project file, do global configuration
# and include sub-projects here.
#
cmake_minimum_required (VERSION 3.8)
cmake_policy(SET CMP0079 NEW)

project ("Komodo")

# Include sub-projects.
add_subdirectory ("Komodo")

# GLFW
list(APPEND CMAKE_MODULE_PATH ${PROJECT_SOURCE_DIR}/cmake)
find_package(glfw3 3.3 REQUIRED)

target_link_libraries(Komodo glfw3)
find_package(OpenGL REQUIRED)
target_include_directories(Komodo PUBLIC ${OPENGL_INCLUDE_DIR})
target_link_libraries(Komodo ${OPENGL_gl_LIBRARY})
target_link_libraries(Komodo ${OPENGL_glu_LIBRARY})