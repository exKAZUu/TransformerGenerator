using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace TransformerGenerator {
    public class DiffierentLine {
        public string Line { get; set; }
        public int LineNumber { get; set; }
    }

    public class RelativeElementInfo {
        public XElement PrevElement { get; set; }
        public XElement NextElement { get; set; }
        public XElement ParentElement { get; set; }

        public IEnumerable<XElement> GetAllElements() {
            yield return PrevElement;
            yield return NextElement;
            yield return ParentElement;
        }
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

        public static XElement GetXElementFromLineNumber(XElement root, int lineNumber) {
            return root.DescendantsAndSelf()
                .First(element => AnalyzeLineNumber(element) == lineNumber);
        }

        public static IEnumerable<RelativeElementInfo> GetRelativeXElementsLists(
                XElement root, List<XElement> targetElements) {
            return targetElements.Select(e => GetRelativeXElements(root, e));
        }

        public static RelativeElementInfo GetRelativeXElements(XElement root, XElement targetElement) {
            return new RelativeElementInfo {
                    PrevElement = (XElement)targetElement.PreviousNode,
                    NextElement = (XElement)targetElement.NextNode,
                    ParentElement = targetElement.Parent,
            };
        }
    }
}