#include <QApplication>
#include <QDialog>
#include <QVBoxLayout>
#include <QLabel>
#include <QLineEdit>
#include <QCheckBox>
#include <QTranslator>
#include <QLocale>
#include <QFile>
#include <QJsonDocument>
#include <QJsonObject>
#include <QDir>
#include <cstdio>
struct Text { const char* context; const char* source; };
static const Text labels[] = {
    {"complete", "Open export guide"},
    {"imported", "Select output folder"},
    {"review", "Include document properties"},
    {"inprocess", "Number of copies"},
    {"updated", "Save export profile"},
    {"untranslated", "Choose paper size"},
    {"validation", "Exported {0} pages to {1}."},
    {"export_profile_saved", "Your export profile has been saved successfully."},
    {"added", "Create accessible PDF"},
};
int main(int argc, char** argv) {
    QApplication app(argc, argv);
    const QStringList args = app.arguments();
    const int cultureIndex = args.indexOf("--culture");
    const QString culture = cultureIndex >= 0 && cultureIndex + 1 < args.size() ? args.at(cultureIndex + 1) : QLocale::system().name().section('_', 0, 0);
    QTranslator translator;
    const bool loaded = translator.load("Export_" + culture, QCoreApplication::applicationDirPath());
    if (culture != "en" && !loaded) { std::fprintf(stderr, "Requested translation was not loaded\n"); return 2; }
    if (loaded) app.installTranslator(&translator);
    QDialog window;
    window.setWindowTitle(QCoreApplication::translate("Window", "Export window"));
    auto* layout = new QVBoxLayout(&window);
    layout->addWidget(new QLabel(QCoreApplication::translate("Window", "Print and export")));
    layout->addWidget(new QLineEdit(QCoreApplication::translate("Window", "Choose a destination folder.")));
    QJsonObject smoke;
    smoke["culture"] = culture; smoke["translatorLoaded"] = loaded;
    smoke["title"] = window.windowTitle();
    for (const auto& text : labels) {
        const QString translated = QCoreApplication::translate(text.context, text.source);
        layout->addWidget(new QCheckBox(translated));
        smoke[QString::fromLatin1(text.context)] = translated;
    }
    const int smokeIndex = args.indexOf("--smoke");
    if (smokeIndex >= 0 && smokeIndex + 1 < args.size()) {
        QFile file(args.at(smokeIndex + 1));
        if (!file.open(QIODevice::WriteOnly)) return 3;
        file.write(QJsonDocument(smoke).toJson()); return 0;
    }
    window.resize(560, 480); window.show(); return app.exec();
}
