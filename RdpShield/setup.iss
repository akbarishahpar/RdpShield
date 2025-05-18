; RdpShield Installer Script
[Setup]
AppName=RdpShield
AppVersion=1.0
DefaultDirName={pf}\RdpShield
DefaultGroupName=RdpShield
OutputBaseFilename=RdpShieldInstaller
Compression=lzma
SolidCompression=yes
ArchitecturesInstallIn64BitMode=x64

[Files]
Source: "RdpShield.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "RdpShield.pdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "nssm.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "appsettings.json"; DestDir: "{app}"; Flags: ignoreversion
Source: "Install.bat"; DestDir: "{app}"; Flags: ignoreversion
Source: "Start.bat"; DestDir: "{app}"; Flags: ignoreversion
Source: "Stop.bat"; DestDir: "{app}"; Flags: ignoreversion
Source: "Uninstall.bat"; DestDir: "{app}"; Flags: ignoreversion

[Run]
Filename: "{app}\Install.bat"; Flags: runhidden
Filename: "{app}\Start.bat"; Flags: runhidden

[UninstallRun]
Filename: "{app}\Stop.bat"; Flags: runhidden
Filename: "{app}\Uninstall.bat"; Flags: runhidden
