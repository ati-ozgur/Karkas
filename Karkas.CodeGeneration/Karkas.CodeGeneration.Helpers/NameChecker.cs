using System;
using System.Collections.Generic;
using System.Text;
using Karkas.CodeGeneration.Helpers.Interfaces;

namespace Karkas.CodeGeneration.Helpers
{
    public class NameChecker : INameChecker
    {
        private const string RESERVED_WORD_KEYWORD = "ReservedWord";
        private Dictionary<char, string> nonStandardChars = new Dictionary<char, string>();
        private List<string> reservedWordsForCSharp = new List<string>();
        private CaseHelper caseHelper = new CaseHelper();

        public NameChecker()
        {
            fillNonStandardChars();
            fillReservedWords();
        }

        /// <summary>
        /// Case sensitive reserved words and does not
        /// contain contextual words such as var, select, set etc.
        /// (Updated: November 2007 MSDN)
        /// </summary>
        private void fillReservedWords()
        {
            #region reserved word list
            reservedWordsForCSharp.Add("value");
            reservedWordsForCSharp.Add("abstract");
            reservedWordsForCSharp.Add("event");
            reservedWordsForCSharp.Add("new");
            reservedWordsForCSharp.Add("struct");
            reservedWordsForCSharp.Add("as");
            reservedWordsForCSharp.Add("explicit");
            reservedWordsForCSharp.Add("null");
            reservedWordsForCSharp.Add("switch");
            reservedWordsForCSharp.Add("base");
            reservedWordsForCSharp.Add("extern");
            reservedWordsForCSharp.Add("object");
            reservedWordsForCSharp.Add("this");
            reservedWordsForCSharp.Add("bool");
            reservedWordsForCSharp.Add("false");
            reservedWordsForCSharp.Add("operator");
            reservedWordsForCSharp.Add("throw");
            reservedWordsForCSharp.Add("break");
            reservedWordsForCSharp.Add("finally");
            reservedWordsForCSharp.Add("out");
            reservedWordsForCSharp.Add("true");
            reservedWordsForCSharp.Add("byte");
            reservedWordsForCSharp.Add("fixed");
            reservedWordsForCSharp.Add("override");
            reservedWordsForCSharp.Add("try");
            reservedWordsForCSharp.Add("case");
            reservedWordsForCSharp.Add("float");
            reservedWordsForCSharp.Add("params");
            reservedWordsForCSharp.Add("typeof");
            reservedWordsForCSharp.Add("catch");
            reservedWordsForCSharp.Add("for");
            reservedWordsForCSharp.Add("private");
            reservedWordsForCSharp.Add("uint");
            reservedWordsForCSharp.Add("char");
            reservedWordsForCSharp.Add("foreach");
            reservedWordsForCSharp.Add("protected");
            reservedWordsForCSharp.Add("ulong");
            reservedWordsForCSharp.Add("checked");
            reservedWordsForCSharp.Add("goto");
            reservedWordsForCSharp.Add("public");
            reservedWordsForCSharp.Add("unchecked");
            reservedWordsForCSharp.Add("class");
            reservedWordsForCSharp.Add("if");
            reservedWordsForCSharp.Add("readonly");
            reservedWordsForCSharp.Add("unsafe");
            reservedWordsForCSharp.Add("const");
            reservedWordsForCSharp.Add("implicit");
            reservedWordsForCSharp.Add("ref");
            reservedWordsForCSharp.Add("ushort");
            reservedWordsForCSharp.Add("continue");
            reservedWordsForCSharp.Add("in");
            reservedWordsForCSharp.Add("return");
            reservedWordsForCSharp.Add("using");
            reservedWordsForCSharp.Add("int");
            reservedWordsForCSharp.Add("sbyte");
            reservedWordsForCSharp.Add("virtual");
            reservedWordsForCSharp.Add("default");
            reservedWordsForCSharp.Add("interface");
            reservedWordsForCSharp.Add("sealed");
            reservedWordsForCSharp.Add("volatile");
            reservedWordsForCSharp.Add("delegate");
            reservedWordsForCSharp.Add("internal");
            reservedWordsForCSharp.Add("short");
            reservedWordsForCSharp.Add("void");
            reservedWordsForCSharp.Add("do");
            reservedWordsForCSharp.Add("is");
            reservedWordsForCSharp.Add("sizeof");
            reservedWordsForCSharp.Add("while");
            reservedWordsForCSharp.Add("double");
            reservedWordsForCSharp.Add("lock");
            reservedWordsForCSharp.Add("stackalloc");
            reservedWordsForCSharp.Add("else");
            reservedWordsForCSharp.Add("long");
            reservedWordsForCSharp.Add("static");
            reservedWordsForCSharp.Add("enum");
            reservedWordsForCSharp.Add("namespace");
            reservedWordsForCSharp.Add("string");
            #endregion
        }

        private void fillNonStandardChars()
        {
            nonStandardChars.Add(' ', "");
            nonStandardChars.Add('.', "");
            nonStandardChars.Add('#', "");
            nonStandardChars.Add('-', "");
            nonStandardChars.Add('+', "");
            nonStandardChars.Add('/', "");
            nonStandardChars.Add('(', "");
            nonStandardChars.Add(')', "");
        }

        public string SetPascalCase(string pValue)
        {
            string result = solveLanguageSpecificProblems(pValue, false);
            result = solveReservedWordIssues(result);
            result = caseHelper.SetPascalCase(result);
            return result;
        }

        public string SetCamelCase(string pValue)
        {
            string result = solveLanguageSpecificProblems(pValue, false);
            result = solveReservedWordIssues(result);
            result = caseHelper.SetCamelCase(result);
            return result;
        }

        private string solveLanguageSpecificProblems(string pValue, bool isCamelCase)
        {
            return cleanNonStandardChars(pValue);
        }


        private string cleanNonStandardChars(string pValue)
        {
            bool isCapitalFlag = false;
            StringBuilder clearedValues = new StringBuilder();
            foreach (char c in pValue)
            {
                if (nonStandardChars.ContainsKey(c))
                {   // Non standard char seen
                    clearedValues.Append(nonStandardChars[c] + "_");
                    isCapitalFlag = true;
                }
                else
                {
                    if (isCapitalFlag)
                    {
                        clearedValues.Append(Char.ToUpperInvariant(c));
                        isCapitalFlag = false;
                    }
                    else
                    {
                        clearedValues.Append(c);
                    }
                }
            }

            addInitialLetterForNumericInitialLetteredVariables(clearedValues);

            return clearedValues.ToString();
        }

        private string solveReservedWordIssues(string pValue)
        {
            string reservedWordControl = pValue.ToLowerInvariant();
            string result = (reservedWordsForCSharp.Contains(reservedWordControl)) ? reservedWordControl + RESERVED_WORD_KEYWORD : pValue;
            return result;
        }

        /// <summary>
        /// Add initial letter if it starts with number.
        /// </summary>
        /// <param name="cleanName">Cleaned name from non standard chars.</param>
        private void addInitialLetterForNumericInitialLetteredVariables(StringBuilder cleanName)
        {
            if (Char.IsNumber(cleanName[0]))
            {
                cleanName.Insert(0, "D_");
            }
        }



        private class CaseHelper
        {
            public string SetCamelCase(string pValue)
            {
                string text = SetPascalCase(pValue);
                char[] arr = text.ToCharArray();
                arr[0] = char.ToLowerInvariant(arr[0]);
                return new string(arr);
            }

            public const char degisicekChar = '_';
            private string removedBadCharacters(string pValue)
            {
                pValue = pValue.Replace('-', degisicekChar);
                pValue = pValue.Replace('(', degisicekChar);
                pValue = pValue.Replace(')', degisicekChar);
                pValue = pValue.Replace('/', degisicekChar);
                return pValue;
            }

            public string SetPascalCase(string pValue)
            {
                pValue = removedBadCharacters(pValue);
                List<string> words = splitToWords(pValue);

                string lastWord = "";

                foreach (var word in words)
                {
                    char[] cList = word.ToCharArray();
                    for (int i = 0; i < cList.Length; i++)
                    {
                        cList[i] = char.ToLowerInvariant(cList[i]);
                    }
                    if (cList.Length > 0)
                    {
                        cList[0] = char.ToUpperInvariant(cList[0]);
                    }
                    lastWord += new string(cList);
                }
                return lastWord;
            }

            private char? getCurrentChar(string pValue, int i)
            {
                if (i >= 0 && i < pValue.Length)
                {
                    return pValue[i];
                }
                else
                {
                    return null;
                }
            }

            private List<string> splitToWords(string pValue)
            {
                List<int> kelimelerinYerleri = new List<int>();


                for (int i = 0; i < pValue.Length; i++)
                {
                    char? birOncekiChar = birOncekiChariAl(i, pValue);
                    char? simdikiChar = getCurrentChar(pValue, i);
                    char? birSonrakiChar = GetBirSonrakiChariAl(i, pValue);
                    // UKullaniciKey gibi kelimeler icin kontrol

                    if (i == 0
                        && simdikiChar.HasValue
                        && birSonrakiChar.HasValue
                        && char.IsUpper(simdikiChar.Value)
                        && char.IsUpper(birSonrakiChar.Value)
                        )
                    {
                        char? ucuncuChar = getCurrentChar(pValue, 2);
                        if (ucuncuChar.HasValue
                            && !char.IsPunctuation(ucuncuChar.Value)
                            && !char.IsNumber(ucuncuChar.Value)
                            && char.IsLower(ucuncuChar.Value)
                            )
                        {
                            i = 3;
                            continue;
                        }


                    }

                    if (!simdikiChar.HasValue)
                    {
                        break;
                    }


                    if (!char.IsPunctuation(simdikiChar.Value)
                        && !char.IsNumber(simdikiChar.Value)
                        && char.IsUpper(simdikiChar.Value)
                        && birSonrakiChar.HasValue
                        && char.IsLower(birSonrakiChar.Value)
                        )
                    {
                        i++;
                        i = tumKucukOlanCharlarIcinIlerle(pValue, i);
                        birOncekiChar = birOncekiChariAl(i, pValue);
                        simdikiChar = getCurrentChar(pValue, i);
                        birSonrakiChar = GetBirSonrakiChariAl(i, pValue);
                        if (birOncekiChar.HasValue
                                && simdikiChar.HasValue
                                && !char.IsPunctuation(simdikiChar.Value)
                                && char.IsLower(birOncekiChar.Value)
                                && char.IsUpper(simdikiChar.Value))
                        {
                            kelimelerinYerleri.Add(i);
                            continue;
                        }

                    }
                    if (!simdikiChar.HasValue)
                    {
                        break;
                    }


                    if (!char.IsPunctuation(simdikiChar.Value)
                        && !char.IsNumber(simdikiChar.Value)
                        && char.IsUpper(simdikiChar.Value))
                    {
                        i = tumBuyukOlanCharlarIcinIlerle(pValue, i);
                        birOncekiChar = birOncekiChariAl(i, pValue);
                        simdikiChar = getCurrentChar(pValue, i);
                        birSonrakiChar = GetBirSonrakiChariAl(i, pValue);
                        if (birOncekiChar.HasValue
                                && simdikiChar.HasValue
                                && !char.IsPunctuation(simdikiChar.Value)
                                && char.IsUpper(birOncekiChar.Value)
                                && char.IsLower(simdikiChar.Value))
                        {
                            kelimelerinYerleri.Add(i);
                        }

                    }
                    if (!simdikiChar.HasValue)
                    {
                        break;
                    }




                    if (!char.IsPunctuation(simdikiChar.Value)
                        && !char.IsNumber(simdikiChar.Value)
                        && char.IsLower(simdikiChar.Value))
                    {
                        i = tumKucukOlanCharlarIcinIlerle(pValue, i);
                        birOncekiChar = birOncekiChariAl(i, pValue);
                        simdikiChar = getCurrentChar(pValue, i);
                        birSonrakiChar = GetBirSonrakiChariAl(i, pValue);
                        if (birOncekiChar.HasValue
                            && simdikiChar.HasValue
                            && !char.IsPunctuation(simdikiChar.Value)
                            && char.IsLower(birOncekiChar.Value)
                            && char.IsUpper(simdikiChar.Value))
                        {
                            kelimelerinYerleri.Add(i);
                        }

                    }

                    if (!simdikiChar.HasValue)
                    {
                        break;
                    }

                    if (simdikiChar == '_')
                    {
                        if (birOncekiChar.HasValue
                            && birOncekiChar != simdikiChar
                            )
                        {
                            kelimelerinYerleri.Add(i);
                        }
                        i++;
                        continue;
                    }

                    if (char.IsNumber(simdikiChar.Value))
                    {
                        tumNumaraOlanCharlarIcinIlerle(pValue, i);
                        if (birOncekiChar.HasValue
                            && !char.IsNumber(birOncekiChar.Value)
                            )
                        {
                            kelimelerinYerleri.Add(i);
                        }
                        i++;
                        continue;
                    }
                    if (
                        birSonrakiChar.HasValue &&
                        (
                        char.IsUpper(birSonrakiChar.Value)
                        &&
                        char.IsLower(simdikiChar.Value)
                        )
                       )
                    {
                        kelimelerinYerleri.Add(i + 1);
                    }
                    if (
                        birSonrakiChar.HasValue &&
                        (
                        char.IsUpper(birSonrakiChar.Value)
                        &&
                        char.IsUpper(simdikiChar.Value)
                        )
                       )
                    {
                        kelimelerinYerleri.Add(i);
                    }
                }

                kelimelerinYerleri.Add(pValue.Length);
                int kesmeBaslangic = 0;
                List<String> parcalanmisKelimeler = new List<string>();

                for (int i = 0; i < kelimelerinYerleri.Count; i++)
                {
                    string s = pValue.Substring(kesmeBaslangic, kelimelerinYerleri[i] - kesmeBaslangic);
                    s = s.Replace("_", "");
                    parcalanmisKelimeler.Add(s);
                    kesmeBaslangic = kelimelerinYerleri[i];
                }


                return parcalanmisKelimeler;
            }


            private char? birOncekiChariAl(int i, string pValue)
            {
                char? birOncekiChar = null;
                if (i != 0)
                {
                    birOncekiChar = pValue[i - 1];
                }
                return birOncekiChar;
            }

            private char? GetBirSonrakiChariAl(int i, string pValue)
            {
                char? birSonrakiChar = null;
                if ((i < pValue.Length-1))
                {
                    birSonrakiChar = pValue[i + 1];
                }
                return birSonrakiChar;
            }

            private int tumNumaraOlanCharlarIcinIlerle(string pValue, int charYeri)
            {
                int i = charYeri;
                for (; i < pValue.Length; i++)
                {
                    char simdikiChar = pValue[i];
                    if (char.IsNumber(simdikiChar))
                    {
                        continue;
                    }
                }
                return i;
            }


            private int tumKucukOlanCharlarIcinIlerle(string pValue, int charYeri)
            {
                int i = charYeri;
                char simdikiChar = ' ';
                for (; i < pValue.Length; i++)
                {
                    simdikiChar = pValue[i];
                    if (char.IsPunctuation(simdikiChar)
                        ||
                        char.IsNumber(simdikiChar)
                        ||
                        char.IsUpper(simdikiChar))
                    {
                        break;
                    }
                }
                return i;
            }
            private int tumBuyukOlanCharlarIcinIlerle(string pValue, int charYeri)
            {
                int i = charYeri;
                char simdikiChar = ' ';
                for (; i < pValue.Length; i++)
                {
                    simdikiChar = pValue[i];
                    if (char.IsPunctuation(simdikiChar)
                        ||
                        char.IsNumber(simdikiChar)
                        ||
                        char.IsLower(simdikiChar))
                    {
                        break;
                    }
                }
                return i;
            }


        }
    }


}

