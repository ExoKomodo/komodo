#version 330 core

layout(location = 0) in vec3 aWorldSpacePosition;
layout(location = 1) in vec3 aColor;
layout(location = 2) in vec2 aTextureCoordinates;

out vec3 color;
out vec2 textureCoordinates;

uniform vec3 worldSpace;

void main() {
    // Translate world coordinates to their proper position within the defined world space
    gl_Position = vec4(
        (aWorldSpacePosition.x - worldSpace.x / 2) / worldSpace.x,
        (aWorldSpacePosition.y - worldSpace.y / 2) / worldSpace.y,
        (aWorldSpacePosition.z - worldSpace.z / 2) / worldSpace.z,
        1.0
    );
    // gl_Position = vec4(aWorldSpacePosition.xyz, 1.0);

    color = aColor;
    textureCoordinates = aTextureCoordinates;
}
