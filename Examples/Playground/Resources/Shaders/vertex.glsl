#version 330 core
layout (location = 0) in vec3 position;   // the position variable has attribute position 0

void main()
{
    gl_Position = vec4(position.x, position.y, position.z, 1.0);
}
