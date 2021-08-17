#version 330 core
out vec4 FragColor;

void main()
{
  if (int(gl_FragCoord.y / 100.0f) % 2 == 0)
  {
    FragColor = vec4(
      1.0f,
      0.0f,
      0.0f,
      1.0f
    );
  }
  else
  {
    FragColor = vec4(
      0.0f,
      1.0f,
      0.0f,
      1.0f
    );
  }
} 
