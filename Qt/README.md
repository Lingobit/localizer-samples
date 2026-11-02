# Qt localization workflow

[Guide: Qt TS](https://www.lingobit.com/guides/qt-ts-localization/?mtm_campaign=github&mtm_kwd=localizer-samples&mtm_content=qt) · [Download the Lingobit Localizer trial](https://www.lingobit.com/download/?mtm_campaign=github&mtm_kwd=localizer-samples&mtm_content=qt) · [All samples](../README.md)

## Open a project

- v1: v1/Sample.loc
- v2, before Scan: v2/Sample.loc
- Native input in each revision: Export.ts

Copy the complete revision folder to a writable working folder before experimenting.
Keep Sample.loc and its Source files together. The project uses relative paths.
v2 already has updated inputs, but its project model is still v1 until you run Scan.

## Translation states in v1

- Complete: Open export guide
- Imported: Select output folder
- For Review: Include document properties
- In Process: Number of copies
- Updated candidate: Save profile
- Not Translated: Choose paper size
- Format-string resource: Exported {0} pages to {1}.
- Profile-saved message: The export profile has been saved successfully.
- Removed candidate: Play a sound when complete

Complete, Imported, For Review and In Process are translation workflow states.
They are independent of New, Updated and Fuzzy flags from Scan.

## Validate the translation

Select the German target and run Project > Validate & Fix. Review Output and edit
reported translations, then validate again before Create Localized.

This sample starts with valid German translations. Placeholder-error exercises are provided in the .NET samples.

## Send and receive translations

Use the Exchange Wizard to send German from your saved owner project. Select the
items to send; the default For Translator preset excludes Complete and Locked items.
In an LTP package, protected items can remain visible as context. Edit the available
translations, validate and save the translator project, then receive it in the owner
project. Review the receive overwrite/status settings and validate the result.

## Scan v2

1. Open v2/Sample.loc and run Project > Scan for Changes.
2. Save profile becomes Save export profile (Updated).
3. Create accessible PDF is New.
4. Play a sound when complete is Removed: its translation appears in Output and
   the row leaves the current tree.
5. The renamed profile-saved message also demonstrates Fuzzy; review its carried translation.
6. Review the translations, Validate and use Create Localized Files.

Use default Match by Value and Fuzzy Match 90%. See workflow.json for resource IDs
and the Scan results verified for this particular pair.

## Carry your own v1 translations to v2

Close the project. Copy your saved v1 Sample.loc over v2/Sample.loc in a separate
working copy, open it and Scan. Keep the v2 source files: only the project model
comes from v1. Preserve your original v1 folder for comparison.

## Source and scope

These are focused examples of the native format.


## Launch the localized Qt application

1. Select German and use Create Localized Files to write `Source/Export_de.ts`.
2. Use Run Localized. The supplied PowerShell launcher calls the bundled Qt 6.8 lrelease, writes `App/Export_de.qm` and starts QtExport with `--culture de`.
3. Confirm the German window title and option labels.

The sample includes a ready x64 application, Qt Widgets runtime, platform/style plugins and lrelease. The source `CMakeLists.txt` can be rebuilt using Qt 6 for MSVC x64, Visual Studio C++ and CMake. No Qt SDK is needed to run the prepared sample or compile its localized TS file. Windows PowerShell is used for the launch script. If local execution policy is centrally restricted, run the displayed commands in your approved environment.

The application deliberately reports a missing requested translation. An English launch uses `App/QtExport.exe --culture en`.
