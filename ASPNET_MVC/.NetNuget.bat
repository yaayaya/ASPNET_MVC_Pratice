@echo off
echo Installing Visual Studio 2022 Extensions...

REM ASP.NET MVC Snippet Pack
dotnet add package ASP.NET_MVC_Snippet_Pack

REM Bundler & Minifier 2022+
dotnet add package Bundler.Minifier

REM Image Optimizer (64-bit)
dotnet add package ImageOptimizer

REM EF Core Power Tools
dotnet add package EFCorePowerTools

REM Markdown Editor v2
dotnet add package MarkdownEditor

REM T4 Language
dotnet add package T4Language

REM Productivity Power Tools 2022
dotnet add package ProductivityPowerTools

REM Snippet Designer 2022
dotnet add package SnippetDesigner

REM Toggle Comment 2022
dotnet add package ToggleComment

REM Solution Colors
dotnet add package SolutionColors

REM Output Enhancer
dotnet add package OutputEnhancer

REM Rainbow Braces
dotnet add package RainbowBraces

REM Trailing Whitespace Visualizer
dotnet add package TrailingWhitespaceVisualizer

echo All extensions have been queued for installation.
pause
