@echo off
set SERVICE_NAME=RdpShield
nssm stop %SERVICE_NAME%
echo Service %SERVICE_NAME% stopped.
