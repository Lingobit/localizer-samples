# Third-party components

The MIT License in [LICENSE](LICENSE) covers the sample sources, projects and documentation written by Lingobit. The built sample applications contain or need these third-party components, which keep their own licenses.

| Component | Where | License |
|---|---|---|
| Qt 6 (Qt Core, Qt Gui, Qt Widgets, the `qwindows` platform plugin and the `qmodernwindowsstyle` style plugin) | `Qt/v1/App`, `Qt/v2/App` | GNU Lesser General Public License v3 (LGPL-3.0). The libraries are dynamically linked and unmodified. [License, exact Qt version, source and rebuild instructions](Qt/v1/App/LICENSE.Qt.txt). Full LGPL and GPL texts accompany both revisions. |
| Qt `lrelease` tool | `Qt/v1/App/lrelease.exe`, `Qt/v2/App/lrelease.exe` | GPL-3.0 with the [Qt GPL exception 1.0](Qt/v1/App/LICENSE.Qt-GPL-exception-1.0.txt). [Corresponding Qt source](Qt/v1/App/LICENSE.Qt.txt). |
| Microsoft Foundation Classes and the Visual C++ runtime, statically linked | `MFC/*/App/MfcApp.exe` | Microsoft Visual Studio redistributable code |
| Delphi run-time library and VCL, compiled in | `Delphi/*/App/DfmLocSample.exe` | Embarcadero RAD Studio redistributable code |

The .NET samples need the Windows Desktop Runtime (.NET 8 or .NET 10), which is not included. The Java samples need a Java runtime, and the database sample needs the 32-bit Microsoft Access ODBC driver; neither is included.
