#include <include/Logger/Logger.h>

Logger::Logger()
{
    this->m_initialized = true;
}

Logger::~Logger()
{
    for (auto it = this->m_output_streams.begin(); it != this->m_output_streams.end(); ++it)
    {
        if ((*it)->is_open())
        {
            (*it)->close();
        }
    }
    
    std::cout << "Successfully shutdown Logger!\n";
}

void Logger::v_info(const char* message, bool printToConsole)
{
    if (message != nullptr)
    {
        this->write_log(this->m_info_prefix, message, printToConsole);
    }
}

void Logger::v_warning(const char* message, bool printToConsole)
{
    if (message != nullptr)
    {
        this->write_log(this->m_warning_prefix, message, printToConsole);
    }
}

void Logger::v_error(const char* message, bool printToConsole)
{
    if (message != nullptr)
    {
        this->write_log(this->m_error_prefix, message, printToConsole);
    }
}

bool Logger::v_add_output(const char* output_file_name)
{
    std::ofstream* output_stream = new std::ofstream();
    output_stream->open(output_file_name, std::ios::out | std::ios::trunc);
    if (output_stream->is_open())
    {
        this->m_output_streams.push_back(output_stream);
        this->v_info("Successfully added new logging output");
        return true;
    }
    else
    {
        this->v_error("Failed in adding new logging output");
        return false;
    }
}

void Logger::write_log(const char* prefix, const char* message, bool printToConsole)
{
    if (prefix == this->m_info_prefix || prefix == this->m_warning_prefix)
    {
        std::cout << prefix << message << std::endl;
    }
    else
    {
        std::cerr << prefix << message << std::endl;
    }
    for (auto it = this->m_output_streams.begin(); it != this->m_output_streams.end(); ++it)
    {
        (**it) << message << std::endl;
    }
}
