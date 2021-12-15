using System;
using System.Collections.Generic;
using System.Text;
using Karkas.CodeGenerationHelper.Interfaces;

namespace Karkas.CodeGenerationHelper
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

        public string SetPascalCase(string degistirilecekString)
        {
            string result = solveLanguageSpecificProblems(degistirilecekString, false);
            result = solveReservedWordIssues(result);
            result = caseHelper.SetPascalCase(result);
            return result;
        }

        public string SetCamelCase(string degistirilecekString)
        {
            string result = solveLanguageSpecificProblems(degistirilecekString, false);
            result = solveReservedWordIssues(result);
            result = caseHelper.SetCamelCase(result);
            return result;
        }

        private string solveLanguageSpecificProblems(string degistirilecekString, bool isCamelCase)
        {
            return cleanNonStandardChars(degistirilecekString);
        }


        private string cleanNonStandardChars(string degistirilecekString)
        {
            bool isCapitalFlag = false;
            StringBuilder temizlenmisHali = new StringBuilder();
            foreach (char c in degistirilecekString)
            {
                if (nonStandardChars.ContainsKey(c))
                {   // Non standard char seen
                    temizlenmisHali.Append(nonStandardChars[c] + "_");
                    isCapitalFlag = true;
                }
                else
                {
                    if (isCapitalFlag)
                    {
                        temizlenmisHali.Append(Char.ToUpperInvariant(c));
                        isCapitalFlag = false;
                    }
                    else
                    {
                        temizlenmisHali.Append(c);
                    }
                }
            }

            addInitialLetterForNumericInitialLetteredVariables(temizlenmisHali);

            return temizlenmisHali.ToString();
        }

        private string solveReservedWordIssues(string degistirilecekString)
        {
            string reservedWordControl = degistirilecekString.ToLowerInvariant();
            string sonuc = (reservedWordsForCSharp.Contains(reservedWordControl)) ? reservedWordControl + RESERVED_WORD_KEYWORD : degistirilecekString;
            return sonuc;
        }

        /// <summary>
        /// Add initial letter if it starts with number.
        /// </summary>
        /// <param name="cleanName">Cleaned name from non standard chars.</param>
        /// <param name="isPascalCase">PascalCase or camelCase</param>
        private void addInitialLetterForNumericInitialLetteredVariables(StringBuilder cleanName)
        {
            if (Char.IsNumber(cleanName[0]))
            {
                cleanName.Insert(0, "D_");
            }
        }



        private class CaseHelper
        {
            public string SetCamelCase(string degistirilecekString)
            {
                string text = SetPascalCase(degistirilecekString);
                char[] arr = text.ToCharArray();
                arr[0] = char.ToLowerInvariant(arr[0]);
                return new string(arr);
            }

            public const char degisicekChar = '_';
            private string kotuKarakterlerdenAyir(string degistirilecekString)
            {
                degistirilecekString = degistirilecekString.Replace('-', degisicekChar);
                degistirilecekString = degistirilecekString.Replace('(', degisicekChar);
                degistirilecekString = degistirilecekString.Replace(')', degisicekChar);
                degistirilecekString = degistirilecekString.Replace('/', degisicekChar);
                return degistirilecekString;
            }

            public string SetPascalCase(string degistirilecekString)
            {
                degistirilecekString = kotuKarakterlerdenAyir(degistirilecekString);
                List<string> kelimeler = kelimelereAyir(degistirilecekString);

                string sonKelime = "";

                foreach (var kelime in kelimeler)
                {
                    char[] cList = kelime.ToCharArray();
                    for (int i = 0; i < cList.Length; i++)
                    {
                        cList[i] = char.ToLowerInvariant(cList[i]);
                    }
                    if (cList.Length > 0)
                    {
                        cList[0] = char.ToUpperInvariant(cList[0]);
                    }
                    sonKelime += new string(cList);
                }
                return sonKelime;
            }

            private char? simdikiChariAl(string degistirilecekString, int i)
            {
                if (i >= 0 && i < degistirilecekString.Length)
                {
                    return degistirilecekString[i];
                }
                else
                {
                    return null;
                }
            }

            private List<string> kelimelereAyir(string degistirilecekString)
            {
                List<int> kelimelerinYerleri = new List<int>();


                for (int i = 0; i < degistirilecekString.Length; i++)
                {
                    char? birOncekiChar = birOncekiChariAl(i, degistirilecekString);
                    char? simdikiChar = simdikiChariAl(degistirilecekString, i);
                    char? birSonrakiChar = GetBirSonrakiChariAl(i, degistirilecekString);
                    // UKullaniciKey gibi kelimeler icin kontrol

                    if (i == 0
                        && simdikiChar.HasValue
                        && birSonrakiChar.HasValue
                        && char.IsUpper(simdikiChar.Value)
                        && char.IsUpper(birSonrakiChar.Value)
                        )
                    {
                        char? ucuncuChar = simdikiChariAl(degistirilecekString, 2);
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
                        i = tumKucukOlanCharlarIcinIlerle(degistirilecekString, i);
                        birOncekiChar = birOncekiChariAl(i, degistirilecekString);
                        simdikiChar = simdikiChariAl(degistirilecekString, i);
                        birSonrakiChar = GetBirSonrakiChariAl(i, degistirilecekString);
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
                        i = tumBuyukOlanCharlarIcinIlerle(degistirilecekString, i);
                        birOncekiChar = birOncekiChariAl(i, degistirilecekString);
                        simdikiChar = simdikiChariAl(degistirilecekString, i);
                        birSonrakiChar = GetBirSonrakiChariAl(i, degistirilecekString);
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
                        i = tumKucukOlanCharlarIcinIlerle(degistirilecekString, i);
                        birOncekiChar = birOncekiChariAl(i, degistirilecekString);
                        simdikiChar = simdikiChariAl(degistirilecekString, i);
                        birSonrakiChar = GetBirSonrakiChariAl(i, degistirilecekString);
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
                        tumNumaraOlanCharlarIcinIlerle(degistirilecekString, i);
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

                kelimelerinYerleri.Add(degistirilecekString.Length);
                int kesmeBaslangic = 0;
                List<String> parcalanmisKelimeler = new List<string>();

                for (int i = 0; i < kelimelerinYerleri.Count; i++)
                {
                    string s = degistirilecekString.Substring(kesmeBaslangic, kelimelerinYerleri[i] - kesmeBaslangic);
                    s = s.Replace("_", "");
                    parcalanmisKelimeler.Add(s);
                    kesmeBaslangic = kelimelerinYerleri[i];
                }


                return parcalanmisKelimeler;
            }


            private char? birOncekiChariAl(int i, string degistirilecekString)
            {
                char? birOncekiChar = null;
                if (i != 0)
                {
                    birOncekiChar = degistirilecekString[i - 1];
                }
                return birOncekiChar;
            }

            private char? GetBirSonrakiChariAl(int i, string degistirilecekString)
            {
                char? birSonrakiChar = null;
                if ((i < degistirilecekString.Length-1))
                {
                    birSonrakiChar = degistirilecekString[i + 1];
                }
                return birSonrakiChar;
            }

            private int tumNumaraOlanCharlarIcinIlerle(string degistirilecekString, int charYeri)
            {
                int i = charYeri;
                for (; i < degistirilecekString.Length; i++)
                {
                    char simdikiChar = degistirilecekString[i];
                    if (char.IsNumber(simdikiChar))
                    {
                        continue;
                    }
                }
                return i;
            }


            private int tumKucukOlanCharlarIcinIlerle(string degistirilecekString, int charYeri)
            {
                int i = charYeri;
                char simdikiChar = ' ';
                for (; i < degistirilecekString.Length; i++)
                {
                    simdikiChar = degistirilecekString[i];
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
            private int tumBuyukOlanCharlarIcinIlerle(string degistirilecekString, int charYeri)
            {
                int i = charYeri;
                char simdikiChar = ' ';
                for (; i < degistirilecekString.Length; i++)
                {
                    simdikiChar = degistirilecekString[i];
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

