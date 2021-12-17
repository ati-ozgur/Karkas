using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Karkas.Core.ElSql.SqlFragments;

namespace Karkas.Core.ElSql
{
    /**
     * A parse of elsql formatted SQL.
     * <p>
     * The parser reads the file line by line and creates the named fragments of SQL for later use.
     * The format is whitespace-aware, with indentation defining blocks (where curly braces would be used in Java).
     * <p>
     * This class is mutable and intended for use by a single thread.
     */
    public class ElSqlParser
    {

        /**
         * The Regex for @NAME(identifier).
         */
        private static readonly Regex NAME_Regex = new Regex("[ ]*[@]NAME[(]([A-Za-z0-9_]+)[)][ ]*");
        /**
         * The Regex for @AND(identifier).
         */
        private static readonly Regex AND_Regex = new Regex("[ ]*[@]AND[(]([:][A-Za-z0-9_]+(?:@LOOPINDEX)?)" + "([ ]?[=][ ]?[A-Za-z0-9_]+)?" + "[)][ ]*");
        /**
         * The Regex for @OR(identifier).
         */
        private static readonly Regex OR_Regex = new Regex("[ ]*[@]OR[(]([:][A-Za-z0-9_]+(?:@LOOPINDEX)?)" + "([ ]?[=][ ]?[A-Za-z0-9_]+)?" + "[)][ ]*");
        /**
         * The Regex for @IF(identifier).
         */
        private static readonly Regex IF_Regex = new Regex("[ ]*[@]IF[(]([:][A-Za-z0-9_]+(?:@LOOPINDEX)?)" + "([ ]?[=][ ]?[A-Za-z0-9_]+)?" + "[)][ ]*");
        /**
         * The Regex for @LOOP(variable)
         */
        private static readonly Regex LOOP_Regex = new Regex("[ ]*[@]LOOP[(][:]([A-Za-z0-9_]+)[)][ ]*");
        /**
         * The Regex for @INCLUDE(key)
         */
        private static readonly Regex INCLUDE_Regex = new Regex("[@]INCLUDE[(]([:]?[A-Za-z0-9_]+)[)](.*)");
        /**
         * The Regex for @PAGING(offsetVariable,fetchVariable)
         */
        private static readonly Regex PAGING_Regex = new Regex("[@]PAGING[(][:]([A-Za-z0-9_]+)[ ]?[,][ ]?[:]([A-Za-z0-9_]+)[)](.*)");
        /**
         * The Regex for @OFFSETFETCH(offsetVariable,fetchVariable)
         */
        private static readonly Regex OFFSET_FETCH_Regex = new Regex("[@]OFFSETFETCH[(][:]([A-Za-z0-9_]+)[ ]?[,][ ]?[:]([A-Za-z0-9_]+)[)](.*)");
        /**
         * The Regex for @FETCH(fetchVariable)
         */
        private static readonly Regex FETCH_Regex = new Regex("[@]FETCH[(][:]([A-Za-z0-9_]+)[)](.*)");
        /**
         * The Regex for @FETCH(numberRows)
         */
        private static readonly Regex FETCH_ROWS_Regex = new Regex("[@]FETCH[(]([0-9]+)[)](.*)");
        /**
         * The Regex for @VALUE(variable)
         */
        private static readonly Regex VALUE_Regex = new Regex("[@]VALUE[(][:]([A-Za-z0-9_]+(?:@LOOPINDEX)?)[)](.*)");
        /**
         * The Regex for text :variable text
         */
        private static readonly Regex LIKE_VARIABLE_Regex = new Regex("([^:])*([:][A-Za-z0-9_]+(?:@LOOPINDEX)?)(.*)");

        /**
         * The input.
         */
        private List<Line> _lines = new List<Line>();
        /**
         * The parsed output.
         */
        private Dictionary<String, NameSqlFragment> _namedFragments = new Dictionary<String, NameSqlFragment>();

        /**
         * Creates the parser.
         * 
         * @param lines  the lines, not null
         */
        internal ElSqlParser(List<String> lines)
        {
            for (int i = 0; i < lines.Count; i++)
            {
                String line = lines[i];
                _lines.Add(new Line(line, i + 1));
            }
        }

        //-------------------------------------------------------------------------
        /**
         * Parse the input returning the named sections.
         * 
         * @return the map of named sections, keyed by name, not null
         */
        internal Dictionary<String, NameSqlFragment> parse()
        {
            rejectTabs();
            parseNamedSections();
            return _namedFragments;
        }

        /**
         * Ensure that there are no tabs.
         */
        private void rejectTabs()
        {
            foreach (Line line in _lines)
            {
                if (line.containsTab())
                {
                    throw new ArgumentException("Tab character not permitted: " + line);
                }
            }
        }

        /**
         * Parses the top-level named sections.
         */
        private void parseNamedSections()
        {
            ContainerSqlFragment containerFragment = new ContainerSqlFragment();
            parseContainerSection(containerFragment, _lines.GetEnumerator(), -1);
        }

        /**
         * Parses a container section.
         * <p>
         * A container is any section indented to the same amount.
         * 
         * @param container  the container to add to, not null
         * @param lineIterator  the iterator, not null
         * @param indent  the current indent, negative if no indent
         */
        private void parseContainerSection(ContainerSqlFragment container, IEnumerator<Line> lineIterator, int indent)
        {
            while (lineIterator.MoveNext())
            {
                Line line = lineIterator.Current;
                if (line.isComment())
                {
                    // TODO burası ne olacak
                    //lineIterator.Remove();
                    continue;
                }
                if (line.indent() <= indent)
                {
                    // TODO burası ne olacak
                    //lineIterator.previous();
                    return;
                }
                String trimmed = line.lineTrimmed();
                if (trimmed.StartsWith("@NAME"))
                {
                    Match nameMatch = NAME_Regex.Match(trimmed);
                    if (nameMatch.Success == false)
                    {
                        throw new ArgumentException("@NAME found with invalid format: " + line);
                    }
                    NameSqlFragment nameFragment = new NameSqlFragment(nameMatch.Groups[1].Value);
                    parseContainerSection(nameFragment, lineIterator, line.indent());
                    if (nameFragment.getFragments().Count == 0)
                    {
                        throw new ArgumentException("@NAME found with no subsequent indented lines: " + line);
                    }
                    container.addFragment(nameFragment);
                    _namedFragments.Add(nameFragment.getName(), nameFragment);

                }
                else if (indent < 0)
                {
                    throw new ArgumentException("Invalid fragment found at root level, only @NAME is permitted: " + line);

                }
                else if (trimmed.StartsWith("@PAGING"))
                {
                    Match pagingMatch = PAGING_Regex.Match(trimmed);
                    if (pagingMatch.Success == false)
                    {
                        throw new ArgumentException("@PAGING found with invalid format: " + line);
                    }
                    PagingSqlFragment whereFragment = new PagingSqlFragment(pagingMatch.Groups[1].Value, pagingMatch.Groups[2].Value);
                    parseContainerSection(whereFragment, lineIterator, line.indent());
                    if (whereFragment.getFragments().Count == 0)
                    {
                        throw new ArgumentException("@PAGING found with no subsequent indented lines: " + line);
                    }
                    container.addFragment(whereFragment);

                }
                else if (trimmed.StartsWith("@WHERE"))
                {
                    if (trimmed.Equals("@WHERE") == false)
                    {
                        throw new ArgumentException("@WHERE found with invalid format: " + line);
                    }
                    WhereSqlFragment whereFragment = new WhereSqlFragment();
                    parseContainerSection(whereFragment, lineIterator, line.indent());
                    if (whereFragment.getFragments().Count == 0)
                    {
                        throw new ArgumentException("@WHERE found with no subsequent indented lines: " + line);
                    }
                    container.addFragment(whereFragment);

                }
                else if (trimmed.StartsWith("@AND"))
                {
                    Match andMatch = AND_Regex.Match(trimmed);
                    if (andMatch.Success == false)
                    {
                        throw new ArgumentException("@AND found with invalid format: " + line);
                    }
                    AndSqlFragment andFragment = new AndSqlFragment(andMatch.Groups[1].Value, extractVariable(andMatch.Groups[2].Value));
                    parseContainerSection(andFragment, lineIterator, line.indent());
                    if (andFragment.getFragments().Count == 0)
                    {
                        throw new ArgumentException("@AND found with no subsequent indented lines: " + line);
                    }
                    container.addFragment(andFragment);

                }
                else if (trimmed.StartsWith("@OR"))
                {
                    Match orMatch = OR_Regex.Match(trimmed);
                    if (orMatch.Success == false)
                    {
                        throw new ArgumentException("@OR found with invalid format: " + line);
                    }
                    OrSqlFragment orFragment = new OrSqlFragment(orMatch.Groups[1].Value, extractVariable(orMatch.Groups[2].Value));
                    parseContainerSection(orFragment, lineIterator, line.indent());
                    if (orFragment.getFragments().Count == 0)
                    {
                        throw new ArgumentException("@OR found with no subsequent indented lines: " + line);
                    }
                    container.addFragment(orFragment);

                }
                else if (trimmed.StartsWith("@IF"))
                {
                    Match ifMatch = IF_Regex.Match(trimmed);
                    if (ifMatch.Success == false)
                    {
                        throw new ArgumentException("@IF found with invalid format: " + line);
                    }
                    IfSqlFragment ifFragment = new IfSqlFragment(ifMatch.Groups[1].Value, extractVariable(ifMatch.Groups[2].Value));
                    parseContainerSection(ifFragment, lineIterator, line.indent());
                    if (ifFragment.getFragments().Count == 0)
                    {
                        throw new ArgumentException("@IF found with no subsequent indented lines: " + line);
                    }
                    container.addFragment(ifFragment);

                }
                else if (trimmed.StartsWith("@LOOP"))
                {
                    if (trimmed.StartsWith("@LOOPINDEX") || trimmed.StartsWith("@LOOPJOIN"))
                    {
                        parseLine(container, line);
                    }
                    else
                    {
                        Match loopMatch = LOOP_Regex.Match(trimmed);
                        if (loopMatch.Success == false)
                        {
                            throw new ArgumentException("@LOOP found with invalid format: " + line);
                        }
                        LoopSqlFragment loopFragment = new LoopSqlFragment(loopMatch.Groups[1].Value);
                        parseContainerSection(loopFragment, lineIterator, line.indent());
                        if (loopFragment.getFragments().Count == 0)
                        {
                            throw new ArgumentException("@LOOP found with no subsequent indented lines: " + line);
                        }
                        container.addFragment(loopFragment);
                    }

                }
                else
                {
                    parseLine(container, line);
                }
            }
        }

        /**
         * Extracts a variable from the input.
         * 
         * @param text  the text to parse, may be null
         * @return the variable, null if none
         */
        private String extractVariable(String text)
        {
            if (text == null)
            {
                return null;
            }
            text = text.Trim();
            if (text.StartsWith("="))
            {
                return extractVariable(text.Substring(1));
            }
            return text;
        }

        /**
         * Parses a single line, or remainder of a line.
         * 
         * @param container  the container to add to, not null
         * @param line  the line to parse, not null
         */
        private void parseLine(ContainerSqlFragment container, Line line)
        {
            String trimmed = line.lineTrimmed();
            if (trimmed.Length == 0)
            {
                return;
            }
            if (trimmed.Contains("@INCLUDE"))
            {
                parseIncludeTag(container, line);

            }
            else if (trimmed.Contains("@LIKE"))
            {
                parseLikeTag(container, line);

            }
            else if (trimmed.Contains("@OFFSETFETCH"))
            {
                parseOffsetFetchTag(container, line);

            }
            else if (trimmed.Contains("@FETCH"))
            {
                parseFetchTag(container, line);

            }
            else if (trimmed.Contains("@VALUE"))
            {
                parseValueTag(container, line);

            }
            else if (trimmed.Contains("@LOOPJOIN"))
            {
                TextSqlFragment textFragment = new TextSqlFragment(trimmed, line.endOfLine());
                container.addFragment(textFragment);

            }
            else if (trimmed.StartsWith("@"))
            {
                throw new ArgumentException("Unknown tag at start of line: " + line);

            }
            else
            {
                TextSqlFragment textFragment = new TextSqlFragment(trimmed, line.endOfLine());
                container.addFragment(textFragment);
            }
        }

        /**
         * Parse INCLUDE tag.
         * <p>
         * This tag can appear anywhere in a line.
         * It substitutes the entire content of the named section in at this point.
         * The text before is treated as simple text.
         * The text after is parsed.
         * 
         * @param container  the container to add to, not null
         * @param line  the line to parse, not null
         */
        private void parseIncludeTag(ContainerSqlFragment container, Line line)
        {
            Line[] split = line.split(line.lineTrimmed().IndexOf("@INCLUDE"));
            parseLine(container, split[0]);
            String trimmed = split[1].lineTrimmed();

            Match Match = INCLUDE_Regex.Match(trimmed);
            if (Match.Success == false)
            {
                throw new ArgumentException("@INCLUDE found with invalid format: " + line);
            }
            IncludeSqlFragment includeFragment = new IncludeSqlFragment(Match.Groups[1].Value);
            container.addFragment(includeFragment);

            Line subLine = null;
            // TODO
            //subLine= split[1].split(Match.start(2))[1];
            parseLine(container, subLine);
        }

        /**
         * Parse LIKE/ENDLIKE tag.
         * <p>
         * This tag can appear anywhere in a line.
         * The text before is treated as simple text.
         * The text after is parsed.
         * 
         * @param container  the container to add to, not null
         * @param line  the line to parse, not null
         */
        private void parseLikeTag(ContainerSqlFragment container, Line line)
        {
            Line[] split = line.split(line.lineTrimmed().IndexOf("@LIKE"));
            parseLine(container, split[0]);
            String trimmed = split[1].lineTrimmed();

            String content = trimmed.Substring(5);
            int end = trimmed.IndexOf("@ENDLIKE");
            int remainderIndex = trimmed.Length;
            if (end >= 0)
            {
                content = trimmed.Substring(5, end);
                remainderIndex = end + 8;
            }
            TextSqlFragment contentTextFragment = new TextSqlFragment(content, line.endOfLine());
            Match Match = LIKE_VARIABLE_Regex.Match(content);
            if (Match.Success == false)
            {
                throw new ArgumentException("@LIKE found with invalid format: " + line);
            }
            LikeSqlFragment likeFragment = new LikeSqlFragment(Match.Groups[2].Value);
            container.addFragment(likeFragment);
            likeFragment.addFragment(contentTextFragment);

            Line subLine = split[1].split(remainderIndex)[1];
            parseLine(container, subLine);
        }

        /**
         * Parse OFFSET/FETCH tag.
         * <p>
         * This tag can appear anywhere in a line.
         * The text before is treated as simple text.
         * The text after is parsed.
         * 
         * @param container  the container to add to, not null
         * @param line  the line to parse, not null
         */
        private void parseOffsetFetchTag(ContainerSqlFragment container, Line line)
        {
            Line[] split = line.split(line.lineTrimmed().IndexOf("@OFFSETFETCH"));
            parseLine(container, split[0]);
            String trimmed = split[1].lineTrimmed();

            String offsetVariable = "paging_offset";
            String fetchVariable = "paging_fetch";
            int remainderIndex = 12;
            if (trimmed.StartsWith("@OFFSETFETCH("))
            {
                Match match = OFFSET_FETCH_Regex.Match(trimmed);
                if (match.Success == false)
                {
                    throw new ArgumentException("@OFFSETFETCH found with invalid format: " + line);
                }
                offsetVariable = match.Groups[1].Value;
                fetchVariable = match.Groups[2].Value;
                // TODO
                //remainderIndex = match.start(3);
            }
            OffsetFetchSqlFragment pagingFragment = new OffsetFetchSqlFragment(offsetVariable, fetchVariable);
            container.addFragment(pagingFragment);

            Line subLine = split[1].split(remainderIndex)[1];
            parseLine(container, subLine);
        }

        /**
         * Parse FETCH tag.
         * <p>
         * This tag can appear anywhere in a line.
         * The text before is treated as simple text.
         * The text after is parsed.
         * 
         * @param container  the container to add to, not null
         * @param line  the line to parse, not null
         */
        private void parseFetchTag(ContainerSqlFragment container, Line line)
        {
            Line[] split = line.split(line.lineTrimmed().IndexOf("@FETCH"));
            parseLine(container, split[0]);
            String trimmed = split[1].lineTrimmed();

            String fetchVariable = "paging_fetch";
            int remainderIndex = 6;
            if (trimmed.StartsWith("@FETCH("))
            {
                Match MatchVariable = FETCH_Regex.Match(trimmed);
                Match MatchRows = FETCH_ROWS_Regex.Match(trimmed);
                if (MatchVariable.Success)
                {
                    fetchVariable = MatchVariable.Groups[1].Value;
                    // TODO
                    //remainderIndex = MatchVariable.start(2);
                }
                else if (MatchRows.Success)
                {
                    fetchVariable = MatchRows.Groups[1].Value;
                    // TODO
                    //remainderIndex = MatchRows.start(2);
                }
                else
                {
                    throw new ArgumentException("@FETCH found with invalid format: " + line);
                }
            }
            OffsetFetchSqlFragment pagingFragment = new OffsetFetchSqlFragment(fetchVariable);
            container.addFragment(pagingFragment);

            Line subLine = split[1].split(remainderIndex)[1];
            parseLine(container, subLine);
        }

        /**
         * Parse VALUE tag.
         * <p>
         * This tag can appear anywhere in a line.
         * The text before is treated as simple text.
         * The text after is parsed.
         * 
         * @param container  the container to add to, not null
         * @param line  the line to parse, not null
         */
        private void parseValueTag(ContainerSqlFragment container, Line line)
        {
            Line[] split = line.split(line.lineTrimmed().IndexOf("@VALUE"));
            parseLine(container, split[0]);
            String trimmed = split[1].lineTrimmed();

            Match match = VALUE_Regex.Match(trimmed);
            if (match.Success == false)
            {
                throw new ArgumentException("@VALUE found with invalid format: " + line);
            }
            ValueSqlFragment valueFragment = new ValueSqlFragment(match.Groups[1].Value);
            container.addFragment(valueFragment);

            Line subLine = null;
            // TODO 
            //subLine = split[1].split(match.start(2))[1];
            parseLine(container, subLine);
        }

        //-------------------------------------------------------------------------
        /**
         * Representation of a single line in the input.
         */


    }

}
