#version 330 core

out vec4 fragmentColor;

in vec3 color;
in vec2 textureCoordinates;

uniform sampler2D textureSampler;

void main() {
    fragmentColor = texture(textureSampler, textureCoordinates) * vec4(color, 1.0);
}
