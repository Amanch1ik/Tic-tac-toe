@echo off
title Build standalone .exe

echo.
echo Building self-contained .exe (no .NET required for the user)...
echo.

where dotnet >nul 2>nul
if errorlevel 1 (
    echo [ERROR] .NET SDK not found.
    echo Install: https://dotnet.microsoft.com/download
    pause
    exit /b 1
)

cd /d "%~dp0TicTacToe"

dotnet publish -c Release -r win-x64 --self-contained ^
    -p:PublishSingleFile=true ^
    -p:IncludeNativeLibrariesForSelfExtract=true ^
    -o "%~dp0release"

if errorlevel 1 (
    echo [ERROR] Build failed.
    pause
    exit /b 1
)

echo.
echo Done! File: %~dp0release\TicTacToe.exe  (about 70 MB)
echo You can share this .exe with anyone, it runs without .NET installed.
echo.
pause
