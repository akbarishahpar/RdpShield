# RdpShield

RdpShield is a lightweight Windows security tool designed to protect your server from unauthorized Remote Desktop Protocol (RDP) access attempts. It monitors login attempts, logs suspicious activity, and provides easy-to-use scripts for installation and management.

---

## Features

- Real-time protection against unauthorized RDP access
- Logging of suspicious connection attempts
- Uses a simple database for persistent tracking
- Includes batch scripts for installation, startup, stopping, and uninstallation
- Integrates with NSSM for Windows service management
- Easy deployment with a GUI installer (Inno Setup)

---

## Requirements

- Windows 10 or later (64-bit recommended)
- Administrative privileges to install and run
- .NET runtime (if applicable, depending on your executable)

---

## Installation

1. Run the installer executable (`RdpShieldInstaller_x64.exe`) as Administrator.
2. The installer will copy all files to `C:\Program Files\RdpShield` by default.
3. The `Install.bat` script will run automatically during installation to configure the service.
4. The `Start.bat` script will be executed to start protection.

---

## Usage

- To manually start RdpShield, run `Start.bat`.
- To stop the service, run `Stop.bat`.
- To uninstall, run the uninstaller from Control Panel or execute `Uninstall.bat`.

---

## File Overview

| File             | Description                               |
|------------------|-------------------------------------------|
| `RdpShield.exe`  | Main executable                           |
| `appsettings.json` | Configuration file                       |
| `Jail.db` & `Jail-log.db` | Database files for logging          |
| `logs.txt`       | Runtime log file                          |
| `Install.bat`    | Script to install and configure service  |
| `Start.bat`      | Script to start the service               |
| `Stop.bat`       | Script to stop the service                |
| `Uninstall.bat`  | Script to uninstall the service and clean up |
| `nssm.exe`       | NSSM executable to manage service         |

---

## Contributing

Contributions and feedback are welcome! Please open issues or submit pull requests on the GitHub repository.

---

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

---

## Contact

For questions or support, please open an issue on GitHub or contact the maintainer.

---

*Thank you for using RdpShield!*
