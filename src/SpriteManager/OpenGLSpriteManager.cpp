#include <include/SpriteManager/OpenGLSpriteManager.h>

#include <include/macros.h>

OpenGLSpriteManager::OpenGLSpriteManager()
{
    this->m_initialized = true;
}

OpenGLSpriteManager::~OpenGLSpriteManager()
{
    for (auto sprite : this->m_sprites)
    {
        SAFE_DELETE(sprite);
    }
}

void OpenGLSpriteManager::v_add_sprite(ISprite* sprite)
{
    this->m_sprites.push_back(sprite);
}

void OpenGLSpriteManager::v_draw_sprites()
{
    for (auto sprite : this->m_sprites)
    {
        sprite->v_draw();
    }
}