@echo off
title Tic-Tac-Toe
 
where dotnet >nul 2>nul
if errorlevel 1 (
    echo.
    echo [ERROR] .NET SDK not found.
    echo Install .NET SDK 8.0 or newer from:
    echo     https://dotnet.microsoft.com/download
    echo.
    pause
    exit /b 1
)

echo Building and running...
echo.

cd /d "%~dp0TicTacToe"
dotnet run -c Release

if errorlevel 1 (
    echo.
    echo [ERROR] Failed to start the application.
    pause
    exit /b 1
)
