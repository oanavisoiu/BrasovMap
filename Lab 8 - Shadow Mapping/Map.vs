#version 330 core
layout (location = 0) in vec3 aPos;

out float Height;
out vec3 Position;

uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;

void main()
{
    float exaggerationFactor = 4.0;  // increase this for more exaggeration
    Height = aPos.y * exaggerationFactor;
    Position = (view * model * vec4(aPos, 1.0)).xyz;
    gl_Position = projection * view * model * vec4(aPos * vec3(1.0, exaggerationFactor, 1.0), 1.0);
}