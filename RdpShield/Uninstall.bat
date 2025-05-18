@echo off
set SERVICE_NAME=RdpShield
nssm stop %SERVICE_NAME%
nssm remove %SERVICE_NAME% confirm
echo Service %SERVICE_NAME% uninstalled.
