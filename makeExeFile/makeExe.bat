@echo off
rem deterrence command output in standard output
setlocal

rem move makeExe.txt directory
pushd "%~dp0"

set csc=C:\Windows\Microsoft.NET\Framework64\v3.5\csc.exe
set id=%1
set month=%2

rem compile cs file
%csc% dummy.cs

rem rename exe file
ren dummy.exe "%id%""%month%".exe

rem withdrawal
popd

rem stop screen
pause