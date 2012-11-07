SpellChecker
============

SpellChecker is a lightweight .NET library that checks and corrects spelling errors in any human language (dictionaries for English and Russian languages are provided for now).
The following functionality is provided:
- Different word parts are considered (such as suffixes and prefixes) during the spell check.
- Auto-detection of the checking text language
- Correction options are suggested for misspelled words for the following cases:
 - merged words (missed space character)
 - missed character in a word
 - replaced character
 - extra character
 - swapped neighbor characters
- No database is required: all dictionaries are stored in plain text files
- New languages can be easily added just by adding dictionary files
