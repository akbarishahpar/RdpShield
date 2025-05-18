@echo off
set SERVICE_NAME=RdpShield
set APP_PATH=%~dp0RdpShield.exe

nssm install %SERVICE_NAME% "%APP_PATH%"
nssm set %SERVICE_NAME% Start SERVICE_AUTO_START
nssm set %SERVICE_NAME% AppDirectory %~dp0
echo Service %SERVICE_NAME% installed successfully.
