@echo off
title D2kMissionEditor Console
:start
CLS
echo Welcome to D2kMissionEditor Console!
echo.

if not exist "MissionEditor.Console\bin\Debug\MissionEditor.Console.exe" (
  echo MissionEditor.Console is not compiled.
  echo You need to compile MissionEditor.Console before using it.
  pause >NUL
  exit
)

set /P mappath=Enter the path to the map file: 
if not defined mappath (
  echo No path definded!
  pause >NUL
  goto start
)
if not exist %mappath% (
  echo Invalid map path given!
  pause >NUL
  goto start
)

set /P output=Enter a name for the output file. Can be left empty: 

echo MissionEditor.Console\bin\Debug\MissionEditor.Console.exe %mappath% %output%
call MissionEditor.Console\bin\Debug\MissionEditor.Console.exe %mappath% %output%
pause >NUL
goto start
