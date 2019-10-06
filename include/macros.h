#pragma once

#define SAFE_DELETE(p) { if (p) { delete (p); (p) = nullptr; } }