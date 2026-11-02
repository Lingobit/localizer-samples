# DB localization workflow

[Guide: Databases](https://www.lingobit.com/guides/database-localization/?mtm_campaign=github&mtm_kwd=localizer-samples&mtm_content=db) · [Download the Lingobit Localizer trial](https://www.lingobit.com/download/?mtm_campaign=github&mtm_kwd=localizer-samples&mtm_content=db) · [All samples](../README.md)

## Open a project

- v1: v1/Sample.loc
- v2, before Scan: v2/Sample.loc
- Native input in each revision: SampleDB.mdb

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

The legacy book tables deliberately retain different German translations for the same English title. Run Validate to find Inconsistent translations. Pick one German translation per English title and apply it to every occurrence, then Validate again. The workflow rows in Books_single_row are separate from those book records. This database uses neutral German and the installed 32-bit Access ODBC driver. SampleDB.mdb sits beside Sample.loc because the connection uses |DataDirectory|.

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
5. Fuzzy is demonstrated in the desktop samples; this parser does not produce it for this pair.
6. Review the translations, Validate and use Create Localized Files.

Use default Match by Value and Fuzzy Match 90%. See workflow.json for resource IDs
and the Scan results verified for this particular pair.

## Carry your own v1 translations to v2

Close the project. Copy your saved v1 Sample.loc over v2/Sample.loc in a separate
working copy, open it and Scan. Keep the v2 source files: only the project model
comes from v1. Preserve your original v1 folder for comparison.

## Source and scope

These are focused examples of the native format.


## Inspect both database localization schemes

The Access database contains more than the added workflow rows. Existing configured tables demonstrate:

- Books_single_row: language columns in one row (the export workflow uses stable IDs 101-109).
- Books_multiple_rows: one language per row.
- Books_multiple_rows_filtered: a configured row filter.
- Books_multiple_rows_grouped and Books_single_row_grouped: key columns organize resources into groups.

Open the table settings to compare the language/column mappings and filter. SQL monitoring is enabled: Scan for Changes and Create Localized Files print statements in Output. Existing book translations deliberately provide an Inconsistent translations exercise; normalize them before delivering localized data. Keep a copy of SampleDB.mdb because Create Localized Files updates it in place.

The project uses `|DataDirectory|` to find SampleDB.mdb beside Sample.loc and requires the 32-bit Microsoft Access ODBC driver. German is neutral `de`. Existing legacy database language rows are retained as data, not a promise that every language is a prepared target in this project.
