#pragma once

#include <vector>

#include <include/Sprite/ISprite.h>

class ISpriteManager
{
public:
    bool m_initialized = false;

    virtual void v_add_sprite(ISprite* sprite) = 0;
    virtual void v_draw_sprites() = 0;

protected:
    std::vector<ISprite*> m_sprites;
};