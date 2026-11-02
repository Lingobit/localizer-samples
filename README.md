# Lingobit Localizer samples

Sample projects for [Lingobit Localizer](https://www.lingobit.com/?mtm_campaign=github&mtm_kwd=localizer-samples&mtm_content=readme), a desktop localization tool for Windows software teams. The samples cover Win32 and MFC, .NET WinForms and WPF, Delphi, and resource formats from RESX and Java properties to Qt TS, XLIFF, help projects and databases.

Each sample contains the application or resource files, a ready Localizer project (`Sample.loc`) with German translations, and a second revision (v2) of the same application for practising Scan for Changes. These are the samples installed with Lingobit Localizer 10.0.

## Get started

1. [Download the Lingobit Localizer trial](https://www.lingobit.com/download/?mtm_campaign=github&mtm_kwd=localizer-samples&mtm_content=readme). It is a 90-day evaluation with up to two target languages per project. Localized files created by the trial contain a Trial marker: up to two translated strings in each file end in `_Trial`.
2. Clone this repository or download it as a ZIP, and copy the sample folder you need to a writable working folder.
3. Open the sample's README and its `v1/Sample.loc` in Localizer.

The project files were saved by Localizer 10.0 for the trial, so they open in the trial and in every licensed edition of Localizer 10. Keep `Sample.loc` next to its `Source` and `App` folders: the project uses relative paths.

## Samples

| Sample | What it shows | Edition | Guide |
|---|---|---|---|
| [WinForms (.NET 8, .NET 10)](WinForms/README.md) | Translate menus, dialogs, messages and embedded HTML/XML resources; preview the interface and switch languages in the running sample. | Standard | [.NET WinForms](https://www.lingobit.com/guides/dotnet-winforms-localization/?mtm_campaign=github&mtm_kwd=localizer-samples&mtm_content=readme) |
| [MFC (x64, static)](MFC/README.md) | Translate menus, dialogs, messages and embedded HTML/XML resources; preview the interface and switch languages in the running sample. | Standard | [Win32 / MFC](https://www.lingobit.com/guides/win32-mfc-localization/?mtm_campaign=github&mtm_kwd=localizer-samples&mtm_content=readme) |
| [MFC Resource-only DLL (x64)](MFC/README.md) | Create a German resource-only DLL and Run Localized without changing settings. | Standard | [Resource-only DLLs](https://www.lingobit.com/guides/resource-only-dll-localization/?mtm_campaign=github&mtm_kwd=localizer-samples&mtm_content=readme) |
| [MFC Multilingual EXE (x64)](MFC/README.md) | Create one executable containing English and German resources, then Run Localized. | Standard | [Win32 / MFC](https://www.lingobit.com/guides/win32-mfc-localization/?mtm_campaign=github&mtm_kwd=localizer-samples&mtm_content=readme) |
| [WPF (.NET 8, .NET 10)](WPF/README.md) | Translate menus, dialogs, messages and embedded HTML/XML resources; preview the interface and switch languages in the running sample. | Standard | [WPF / BAML](https://www.lingobit.com/guides/dotnet-wpf-baml-localization/?mtm_campaign=github&mtm_kwd=localizer-samples&mtm_content=readme) |
| [ASP.NET (ResX)](ASPNetWebAppUsingResX/README.md) | Translate global and local ASP.NET RESX resources used by the included page, master page and user control. | Standard | [.NET resources](https://www.lingobit.com/guides/dotnet-resx-resource-localization/?mtm_campaign=github&mtm_kwd=localizer-samples&mtm_content=readme) |
| [HTML Content Website](HTMLWebSite/README.md) | Translate three linked HTML pages as a folder, including image alternative text and link titles; preserve shared CSS and images. | Enterprise | [HTML / web templates](https://www.lingobit.com/guides/html-web-template-localization/?mtm_campaign=github&mtm_kwd=localizer-samples&mtm_content=readme) |
| [Java ResourceBundle](Java/README.md) | Translate a Java ResourceBundle with comments, continued values, escaped characters and formatted messages; run the included Java console source. | Standard | [Java](https://www.lingobit.com/guides/java-localization/?mtm_campaign=github&mtm_kwd=localizer-samples&mtm_content=readme) |
| [Help & Manual](Help/HelpAndManual/README.md) | Translate project metadata and three linked Help & Manual XML topics. | Professional | [Help & Manual](https://www.lingobit.com/guides/help-and-manual-localization/?mtm_campaign=github&mtm_kwd=localizer-samples&mtm_content=readme) |
| [CHM HTML Help](Help/CHM/README.md) | Translate compiled help with three linked topics, contents, a keyword index and an illustration. | Enterprise | [Help documentation](https://www.lingobit.com/guides/help-documentation-localization/?mtm_campaign=github&mtm_kwd=localizer-samples&mtm_content=readme) |
| [INI file](INI/README.md) | Translate keyed INI export settings. | Professional | [INI files](https://www.lingobit.com/guides/ini-file-localization/?mtm_campaign=github&mtm_kwd=localizer-samples&mtm_content=readme) |
| [SQL Server Reporting Services](SQL%20Server%20Reporting%20Services/README.md) | Translate a self-contained SQL Server Reporting Services RDL report with no external database connection. | Professional | [SSRS reports](https://www.lingobit.com/guides/ssrs-rdl-report-localization/?mtm_campaign=github&mtm_kwd=localizer-samples&mtm_content=readme) |
| [Database Localization](DB/README.md) | Translate an Access database through its configured ODBC source. | Enterprise | [Databases](https://www.lingobit.com/guides/database-localization/?mtm_campaign=github&mtm_kwd=localizer-samples&mtm_content=readme) |
| [XSL Localization](XSL/README.md) | Translate selected XML fields and XSL text with XPath, preserve IDs and numeric values, and render the localized result to HTML. | Professional | [XML / XPath](https://www.lingobit.com/guides/xml-localization/?mtm_campaign=github&mtm_kwd=localizer-samples&mtm_content=readme) |
| [Qt Localization](Qt/README.md) | Translate a Qt TS resource, create German QM with the bundled lrelease, and run the included Qt Widgets application through Run Localized. | Professional | [Qt TS](https://www.lingobit.com/guides/qt-ts-localization/?mtm_campaign=github&mtm_kwd=localizer-samples&mtm_content=readme) |
| [Symbian Localization](Symbian/README.md) | Translate keyed Symbian RLS resources. | Professional | [Supported formats](https://www.lingobit.com/features/supported-formats/?mtm_campaign=github&mtm_kwd=localizer-samples&mtm_content=readme#legacy-formats) |
| [XLIFF Localization](Xliff/README.md) | Translate XLIFF 1.2 as a source-file format, preserving trans-unit IDs. | Professional | [XLIFF and TMX](https://www.lingobit.com/guides/xliff-tmx-exchange/?mtm_campaign=github&mtm_kwd=localizer-samples&mtm_content=readme) |
| [Customizable Format](Customizable/README.md) | Translate a small keyed proprietary text format using the configured Customizable parser regex. | Professional | [Supported formats](https://www.lingobit.com/features/supported-formats/?mtm_campaign=github&mtm_kwd=localizer-samples&mtm_content=readme#custom-parsers) |
| [JAR Localization](Jar/README.md) | Translate ResourceBundle properties packaged inside a runnable Java JAR. | Standard | [Java](https://www.lingobit.com/guides/java-localization/?mtm_campaign=github&mtm_kwd=localizer-samples&mtm_content=readme) |
| [Android Resources](Android/README.md) | Translate an Android values/strings.xml resource set. | Professional | [XML / XPath](https://www.lingobit.com/guides/xml-localization/?mtm_campaign=github&mtm_kwd=localizer-samples&mtm_content=readme) |
| [Apple Property List](ApplePropList/README.md) | Translate XML, binary and OpenStep/text property lists; preserve nested values and non-string types. | Standard | [Apple resources](https://www.lingobit.com/guides/apple-xib-localization/?mtm_campaign=github&mtm_kwd=localizer-samples&mtm_content=readme) |
| [Delphi compiled EXE](Delphi/README.md) | Localize a prebuilt Delphi Win32 application with German translations of every form, menu and dialog. | Standard | [Delphi / C++Builder](https://www.lingobit.com/guides/delphi-cppbuilder-localization/?mtm_campaign=github&mtm_kwd=localizer-samples&mtm_content=readme) |
| [Delphi DFM form resources](DFM/README.md) | Localize standalone Delphi form resources, preview controls and create German DFM files. | Standard | [Delphi / C++Builder](https://www.lingobit.com/guides/delphi-cppbuilder-localization/?mtm_campaign=github&mtm_kwd=localizer-samples&mtm_content=readme) |

The Edition column names the lowest Localizer edition with that format or feature. In the trial you choose Standard, Professional, or Enterprise. See [Compare editions](https://www.lingobit.com/pricing/compare-editions/?mtm_campaign=github&mtm_kwd=localizer-samples&mtm_content=readme).

## Folder layout

- `v1/` and `v2/`: two revisions of the same application or resource set.
- `Source/`: the source files; `App/`: the built application where the sample has one.
- `Sample.loc`: the Localizer project. In the desktop samples, `v2/Sample.loc` is ready to localize and `v2/BeforeScan.loc` keeps the v1 project for the Scan for Changes exercise. In the other samples, `v2/Sample.loc` still holds the v1 project until you run Scan for Changes.
- `workflow.json` and `sample.json`: resource IDs and expected results that the README of each sample refers to.

## Start without the sample project

You can also build the project yourself: create a new project in Localizer, add the input file that the sample README names (for example `App/MfcApp.exe`), add German as the target language, translate or use the supplied translations as a reference, and run Create Localized Files.

## About this repository

This repository is generated from the Lingobit Localizer sources for each release, and each release is tagged (`v10.0`). Issues and pull requests about the samples are welcome. Accepted changes are applied upstream and appear here with the next release.

Questions about Lingobit Localizer itself go to the [contact page](https://www.lingobit.com/contact/?mtm_campaign=github&mtm_kwd=localizer-samples&mtm_content=readme).

## License

The samples are released under the [MIT License](LICENSE). Some sample applications include third-party runtime components under their own licenses; see [THIRD-PARTY-NOTICES.md](THIRD-PARTY-NOTICES.md).
