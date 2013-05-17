#region License

// Copyright (C) 2012-2013 Kazunori Sakamoto
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Paraiba.Xml.Linq;

namespace TransformerGenerator {
    public class DiffierentLine {
        public string Line { get; set; }
        public int LineNumber { get; set; }
    }

    public class RelativeElementInfo {
        public RelativeElementInfo(XElement target) {
            Element = target;
        }

        public XElement Element { get; set; }

        public XElement Prev {
            get { return Element.PreviousElement(); }
        }

        public XElement Next {
            get { return Element.NextElement(); }
        }

        public XElement Parent {
            get { return Element.Parent; }
        }

        public IEnumerable<XElement> GetAllElements() {
            yield return Parent;
            yield return Prev;
            yield return Next;
        }
    }

    public static class Analyzer {
        public static IEnumerable<XElement> GetSiblingElements(
                XElement target, int previousCount, int nextCount) {
            var prevs = target.PreviousElements().Take(previousCount).Reverse();
            var nexts = target.NextElements().Take(nextCount);
            return prevs.Concat(new[] { target }).Concat(nexts);
        }

        public static bool IsSameElementNameSequence(
                List<XElement> elemSeq1, List<XElement> elemSeq2) {
            var count = elemSeq1.Count;
            if (count != elemSeq2.Count) {
                return false;
            }
            for (int i = 0; i < count; i++) {
                if (elemSeq1[i].Name() != elemSeq2[i].Name()) {
                    return false;
                }
            }
            return true;
        }

        public static bool HasSameElementNameSequence(XElement target, List<XElement> exElemSeq) {
            for (int i = 0; i < exElemSeq.Count; i++) {
                var elems2 = GetSiblingElements(target, i, exElemSeq.Count - i - 1);
                if (IsSameElementNameSequence(exElemSeq, elems2.ToList())) {
                    return true;
                }
            }
            return false;
        }

        private static string RemoveAllWhiteSpaces(string text) {
            return new string(text.Where(c => !char.IsWhiteSpace(c)).ToArray());
        }

        public static List<List<XElement>> FindElementsBySelectedLines(
                XElement root, int startLine, int endLine) {
            var result = new Stack<List<XElement>>();
            foreach (var elem in root.DescendantsAndSelf()) {
                if (AnalyzeFirstLineNumberOrDefault(elem) == startLine) {
                    var candidate = GetSequenceElements(elem, endLine);
                    if (candidate != null) {
                        result.Push(candidate);
                    }
                }
            }
            return result.ToList();
        }

        private static List<XElement> GetSequenceElements(XElement elem, int endLine) {
            var result = new List<XElement> { elem };
            var maxLine = 0;
            foreach (var elem2 in elem.NextElements()) {
                var line = AnalyzeLastLineNumberOrDefault(elem2);
                if (line > endLine) {
                    break;
                }
                maxLine = Math.Max(maxLine, line);
                result.Add(elem2);
            }
            return maxLine == endLine ? result : null;
        }

        public static List<DiffierentLine> FindDifferentLines(string original, string modified) {
            var originalLines = original.Split('\n');
            var modifiedLines = modified.Split('\n');
            var diffLines = new List<DiffierentLine>();
            for (int i = 0; i < originalLines.Length; i++) {
                if (i + diffLines.Count >= modifiedLines.Length) {
                    throw new Exception();
                }
                if (originalLines[i] != modifiedLines[i + diffLines.Count]) {
                    diffLines.Add(
                            new DiffierentLine {
                                    LineNumber = i + diffLines.Count + 1,
                                    Line = modifiedLines[i + diffLines.Count].Trim(),
                            });
                }
            }
            return diffLines;
        }

        public static int AnalyzeFirstLineNumberOrDefault(XElement elem) {
            foreach (var e in elem.DescendantsAndSelf()) {
                var attr = e.Attribute("startline");
                if (attr != null) {
                    return int.Parse(attr.Value);
                }
            }
            return 0;
        }

        public static int AnalyzeLastLineNumberOrDefault(XElement elem) {
            var lastLine = 0;
            foreach (var e in elem.DescendantsAndSelf()) {
                var attr = e.Attribute("startline");
                if (attr != null) {
                    lastLine = int.Parse(attr.Value);
                }
            }
            return lastLine;
        }

        public static List<XElement> FindDifferentElements(
                XElement modified, List<DiffierentLine> diffLines) {
            var iLines = 0;
            var ret = new List<XElement>();
            foreach (var elem in modified.DescendantsAndSelf()) {
                if (AnalyzeFirstLineNumberOrDefault(elem) == diffLines[iLines].LineNumber) {
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