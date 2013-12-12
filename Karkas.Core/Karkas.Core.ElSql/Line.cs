using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karkas.Core.ElSql
{
  internal class Line {
    private  String _line;
    private  String _trimmed;
    private  int _lineNumber;
    private  bool _endOfLine;

    internal Line(String line, int lineNumber) {
      _line = line;
      int commentPos = line.IndexOf("--");
      if (commentPos >= 0) {
        _trimmed = line.Substring(0, commentPos).Trim();
      } else {
        _trimmed = line.Trim();
      }
      _lineNumber = lineNumber;
      _endOfLine = true;
    }

    internal Line(String line, String trimmed, int lineNumber, bool endOfLine) {
      _line = line;
      _trimmed = trimmed;
      _lineNumber = lineNumber;
      _endOfLine = endOfLine;
    }

    internal String line()
    {
      return _line;
    }

    internal String lineTrimmed()
    {
      return _trimmed;
    }

    internal int lineNumber()
    {
      return _lineNumber;
    }

    internal  bool endOfLine()
    {
      return _endOfLine;
    }

    internal bool containsTab() {
      return _line.Contains("\t");
    }

    internal bool isComment()
    {
      return _trimmed.StartsWith("--") || _trimmed.Length == 0;
    }

    internal int indent()
    {
      for (int i = 0; i < _line.Length; i++) {
        if (_line[i] != ' ') {
          return i;
        }
      }
      return _line.Length;
    }

    internal Line[] split(int trimmedIndex)
    {
      String before = _trimmed.Substring(0, trimmedIndex);
      String after = _trimmed.Substring(trimmedIndex);
      return new Line[] {new Line(before, before, _lineNumber, false), new Line(after, after, _lineNumber, _endOfLine)};
    }

    public override String ToString() {
      return "Line " + lineNumber();
    }
  }
}
