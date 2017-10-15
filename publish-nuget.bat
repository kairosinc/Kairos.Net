@echo off
if "%1"=="" goto help
if "%2"=="" goto help
@echo on
nuget push %1 %2 -Source https://www.nuget.org/api/v2/package
@echo off
goto end
:help
echo Usage: publish-nuget.bat [path-to-nupkg-file] [nuget-api-key]
:end