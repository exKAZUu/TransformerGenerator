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
			Target = target;
		}

		public XElement Target { get; set; }

		public XElement Previous {
			get { return Target.PreviousElement(); }
		}

		public XElement Next {
			get { return Target.NextElement(); }
		}

		public XElement Parent {
			get { return Target.Parent; }
		}

		public IEnumerable<XElement> GetAllElements() {
			yield return Parent;
			yield return Previous;
			yield return Next;
		}
	}

	public static class Analyzer {
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

		public static int AnalyzeLineNumber(XElement elem) {
			foreach (var e in elem.DescendantsAndSelf()) {
				var attr = e.Attribute("startline");
				if (attr != null) {
					return int.Parse(attr.Value);
				}
			}
			throw new Exception();
		}

		public static List<XElement> FindDifferentElements(
				XElement modified, List<DiffierentLine> diffLines) {
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

		public static XElement GetElementByLineNumber(XElement root, int lineNumber) {
			return root.DescendantsAndSelf()
					.First(element => AnalyzeLineNumber(element) == lineNumber);
		}
	}
}