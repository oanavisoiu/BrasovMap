#version 330 core

in float Height;
in vec3 Position;

out vec4 FragColor;

void main()
{
    // Define colors
    vec3 blue = vec3(0.0, 0.0, 1.0); // Blue for underwater
    vec3 yellow = vec3(1.0, 1.0, 0.0); // Yellow for beaches
    vec3 brown = vec3(0.6, 0.4, 0.2); // Brown for mountains
    vec3 white = vec3(1.0, 1.0, 1.0); // White for snow caps

    vec3 color;
    if (Height < -50.0) // Below -50, pure blue
    {
        color = blue;
    }
    else if (Height < -20.0) // Between -50 and -20, blend from blue to yellow
    {
        float factor = (Height + 50.0) / 30.0; // Normalize to [0, 1]
        color = mix(blue, yellow, factor);
    }
    else if (Height < 40.0) // Between -20 and 40, blend from yellow to brown
    {
        float factor = (Height + 20.0) / 60.0; // Normalize to [0, 1]
        color = mix(yellow, brown, factor);
    }
    else // Above 40, blend from brown to white
    {
        float factor = min((Height - 40.0) / (191.0 - 40.0), 1.0); // Normalize to [0, 1], don't exceed 1
        color = mix(brown, white, factor);
    }

    FragColor = vec4(color, 1.0);
}