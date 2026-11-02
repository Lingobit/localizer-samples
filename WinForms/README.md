# WinForms localization sample

[Guide: .NET WinForms](https://www.lingobit.com/guides/dotnet-winforms-localization/?mtm_campaign=github&mtm_kwd=localizer-samples&mtm_content=winforms) · [Download the Lingobit Localizer trial](https://www.lingobit.com/download/?mtm_campaign=github&mtm_kwd=localizer-samples&mtm_content=winforms) · [All samples](../README.md)

## Open a project

- net8 v1: net8/v1/Sample.loc
- net8 v2, ready to localize: net8/v2/Sample.loc
- net10 v1: net10/v1/Sample.loc
- net10 v2, ready to localize: net10/v2/Sample.loc

v1 and v2 contain reviewed German translations matching their applications.
Open Sample.loc, Create Localized Files, then Run Localized without changing settings.
v2/BeforeScan.loc separately preserves the v1 model for the Scan exercise.

Before starting, copy the complete revision folder to a writable working folder.
Keep Source, App and Sample.loc together; project input paths are relative.
Install the matching Windows Desktop Runtime (.NET 8 or 10). The runtime is shared, not copied into every sample.

## Translation states in v1

- Complete: Ready for preview.
- Imported: Export guide.
- For Review: Include document properties.
- In Process: the export summary message.
- Additional strings have reviewed German translations for a usable interface.

These translation states are independent of the flags produced by Scan.

## Validate and fix the training translation

The supplied translations have valid format arguments. To practise validation, change {1} to {2} in the German export summary, Validate, then restore {1}.

Run Project > Validate & Fix, review the reported issues in Output, edit the
translation and validate again. Wrong argument numbers need a manual correction;
an automatic formatting fix cannot choose the intended argument for you.

## Send and receive translations

1. Save your v1 project and use the Exchange Wizard to send German to a translator.
2. Choose the items to send. The default For Translator preset excludes Complete
   and Locked items; those items may remain visible as context in an LTP package.
3. Edit the available translations in the translator project, validate and save it.
4. Receive the returned translations in your saved owner project. Review the
   overwrite and status options; these options determine which results are accepted.
5. Validate the owner project again before creating localized files.

## Create and run

1. Close the sample application before Create Localized or replacing existing files.
2. Use Create Localized Files in Localizer.
3. Choose Run Localized. The project starts App/WinFormsBinary.exe with German selected.
   You can also run the application yourself and select German from its Language menu.
   Only available matching translations are listed.
4. Use the sample's commands to open dialogs, display messages and inspect its
   embedded HTML/XML resources. You can also select those resources in Localizer.

## Scan the updated application

1. Open v2/BeforeScan.loc for your target and run Scan for Changes.
   v2/Sample.loc is already updated and ready to localize.
2. Save profile becomes Save export profile: review Updated items.
3. Review New options and resources.
4. The profile-saved message has a new resource ID and slightly different text.
   Its old translation is carried over by Fuzzy match and needs review.
5. Play a sound when complete is Removed. Its translation is reported in Output;
   the removed row disappears from the current resource tree.
6. Review the carried translations, Validate, then Create Localized again.

Use the default Scan settings: Match by Value enabled, Fuzzy Match 90%.

After Scan, ExportSummaryFormat has three arguments: Export {0} pages to {1} using the {2} preset. A correct German example is: {0} Seiten mit dem Profil {2} nach {1} exportieren. Keep all three arguments.

## Carry your own v1 work to v2

From this family folder, run the following command with your saved v1 project and
an empty workspace. Quote paths containing spaces.

    powershell -File Demo/Prepare.ps1 -Target net8 -V1Project "C:\My Samples\v1\Sample.loc" -Workspace "C:\My Samples\v2"

The helper copies your project beside v2 Source/App. It preserves v1, refuses a
nonempty workspace, and leaves Scan for you to run after opening the copied project.
To move a project later, copy its entire revision/workspace folder.


