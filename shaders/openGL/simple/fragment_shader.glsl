#version 330 core

out vec4 fragmentColor;

uniform vec4 color;

void main() {
    fragmentColor = color;
}
