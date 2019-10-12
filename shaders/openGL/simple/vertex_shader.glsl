#version 330 core

layout(location = 0) in vec3 position_in_world_space;

uniform vec3 world_space;

void main() {
    // Translate world coordinates to their proper position within the defined world space
    gl_Position = vec4(
        (position_in_world_space.x - world_space.x / 2) / world_space.x,
        (position_in_world_space.y - world_space.y / 2) / world_space.y,
        (position_in_world_space.z - world_space.z / 2) / world_space.z,
        1.0
    );
}
