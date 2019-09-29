#include <include/AudioSystem/AudioSystem.h>

AudioSystem::AudioSystem()
{
    this->m_initialized = true;
}

AudioSystem::~AudioSystem()
{
    std::cout << "Successfully shutdown Audio System!\n";
}