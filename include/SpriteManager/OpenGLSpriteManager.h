#pragma once

#include <include/SpriteManager/ISpriteManager.h>

class OpenGLSpriteManager : public ISpriteManager
{
public:
    OpenGLSpriteManager();
    ~OpenGLSpriteManager();

    void v_add_sprite(ISprite* sprite);
    void v_draw_sprites();
};