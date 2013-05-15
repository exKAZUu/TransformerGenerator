using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace TransformerGenerator {
    public class DiffierentLine {
        public string Line { get; set; }
        public int LineNumber { get; set; }
    }

    public static class Analyzer {
        public static List<DiffierentLine> Analyze(string original, string modified) {
            var originalLines = original.Split('\n');
            var modifiedLines = modified.Split('\n');
            var diffLines = new List<DiffierentLine>();
            for (int i = 0; i < originalLines.Length; i++) {
                if (i + diffLines.Count >= modifiedLines.Length) {
                    throw new Exception();
                }
                if (originalLines[i] != modifiedLines[i + diffLines.Count]) {
                    diffLines.Add(new DiffierentLine {
                            LineNumber = i + diffLines.Count + 1,
                            Line = modifiedLines[i + diffLines.Count].Trim(),
                    });
                }
            }
            return diffLines;
        }

        public static int AnalyzeLineNumber(XElement elem) {
            foreach (var e in elem.DescendantsAndSelf()) {
                var attr = e.Attribute("startline");
                if (attr != null) {
                    return int.Parse(attr.Value);
                }
            }
            throw new Exception();
        }

        public static List<XElement> Find(XElement modified, List<DiffierentLine> diffLines) {
            var iLines = 0;
            var ret = new List<XElement>();
            foreach (var elem in modified.DescendantsAndSelf()) {
                if (elem.Value == diffLines[iLines].Line
                        && AnalyzeLineNumber(elem) == diffLines[iLines].LineNumber) {
                    ret.Add(elem);
                    iLines++;
                    if (iLines == diffLines.Count) {
                        break;
                    }
                }
            }
            return ret;
        }
    }
}