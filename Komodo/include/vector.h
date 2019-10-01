#pragma once

struct Vector2
{
    double x;
    double y;

    Vector2(double x = 0, double y = 0)
    {
        this->x = x;
        this->y = y;
    }
};

struct Vector3
{
    double x;
    double y;
    double z;

    Vector3(double x = 0, double y = 0, double z = 0)
    {
        this->x = x;
        this->y = y;
        this->z = z;
    }
};