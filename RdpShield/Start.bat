@echo off
set SERVICE_NAME=RdpShield
nssm start %SERVICE_NAME%
echo Service %SERVICE_NAME% started.
