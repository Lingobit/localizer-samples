import java.util.*;
import java.text.MessageFormat;
public class ExportSample {
 public static void main(String[] args) {
  Locale locale = args.length == 0 ? Locale.ENGLISH : Locale.forLanguageTag(args[0]);
  ResourceBundle resources = ResourceBundle.getBundle("Messages", locale);
  if (!locale.getLanguage().equals("en") && !resources.getLocale().getLanguage().equals(locale.getLanguage()))
   throw new IllegalStateException("Requested bundle was not loaded: " + locale);
  for (String key : new TreeSet<String>(resources.keySet())) System.out.println(key + ": " + resources.getString(key));
  System.out.println(MessageFormat.format(resources.getString("formatted"), "report.pdf"));
 }
}
