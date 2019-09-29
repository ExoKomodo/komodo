#pragma once

class IVideoSystem
{
public:
    bool Initialized = false;

    virtual ~IVideoSystem()
    {

    }

    virtual bool create_window(int width = 0, int height = 0, const char* title = "") = 0;
};