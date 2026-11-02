# Help/HelpAndManual localization workflow

[Guide: Help & Manual](https://www.lingobit.com/guides/help-and-manual-localization/?mtm_campaign=github&mtm_kwd=localizer-samples&mtm_content=help-helpandmanual) · [Download the Lingobit Localizer trial](https://www.lingobit.com/download/?mtm_campaign=github&mtm_kwd=localizer-samples&mtm_content=help-helpandmanual) · [All samples](../../README.md)

## Open a project

- v1: v1/Sample.loc
- v2, before Scan: v2/Sample.loc
- Native input in each revision: Project/Export.hmxp

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


## Translate several linked help topics

The project metadata and three topic XML files are separate inputs. XPath selects text explicitly marked `translate="true"`; IDs and link targets remain unchanged. Create Localized Files writes project metadata under `Localized/de` and topics under `Localized/de/Topics`. Check that all three topic files are present and German text is retained.

The HMXP uses project format 2.2. With the older 1.5 header, Help+Manual 10 omits required WebHelp scripts even though compilation finishes. Both revisions and their German localized results are published to WebHelp and CHM using Help+Manual 10.3.1.7630; emitted topic links, contents and page dependencies are checked. Run Samples/tools/Test-HelpManualSamplePublish.ps1 against Source/Project/Export.hmxp or Localized/de/Export.hmxp, using a fresh OutputRoot and Language en or de. Pass HelpManualPath explicitly for a custom installation. The vendor evaluation compiler returns 99 on successful publication and marks/scrambles trial output; this is recorded separately from compilation errors. Use a licensed compiler for distributable help. German v2 was manually accepted by the user in the editor and compiled CHM. Project title and lcid are included in localization: English en becomes German de, and the published project/window title is Exportübersicht. The publishing test checks HTML lang, CHM LCID and both binary title strings for the umlaut.
