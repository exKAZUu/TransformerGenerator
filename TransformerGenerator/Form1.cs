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
using System.Windows.Forms;
using System.Xml.Linq;
using Code2Xml.Core.CodeToXmls;
using Code2Xml.Core.Plugins;
using Code2Xml.Languages.Java.CodeToXmls;
using Paraiba.Linq;
using Paraiba.Xml.Linq;

namespace TransformerGenerator {
	public partial class Form1 : Form {
		private CodeToXml _activeCodeToXml = JavaCodeToXml.Instance;
		private List<DiffierentLine> _diffLines;
		private List<RelativeElementInfo> _elemInfos;
		private TreeNode _lastTreeNode;

		private readonly Dictionary<XElement, TreeNode> _elementToNode =
				new Dictionary<XElement, TreeNode>();

		public Form1() {
			InitializeComponent();
		}

		private void RemoveAttributes(XElement elem) {
			foreach (var e in elem.DescendantsAndSelf()) {
				e.RemoveAttributes();
			}
		}

		public class Suggestion {
			public string Direction { get; set; }
			public string Element { get; set; }
			public int InsertingCount { get; set; }
			public int CoveringCount { get; set; }
		}

		private void button1_Click(object sender, EventArgs eventArgs) {
			var originalCode = txtOriginalCode.Text;
			var originalXml = _activeCodeToXml.Generate(originalCode);
			txtOriginalXml.Text = originalXml.ToString();
			ShowXmlInTreeView(originalXml, tvOriginal, null);

			var exampleCode = txtExampleCode.Text;
			var exampleXml = _activeCodeToXml.Generate(exampleCode);
			txtExampleXml.Text = exampleXml.ToString();
			ShowXmlInTreeView(exampleXml, tvExample, _elementToNode);

			_diffLines = Analyzer.FindDifferentLines(originalCode, exampleCode);
			var diffElements = Analyzer.FindDifferentElements(exampleXml, _diffLines);
			_elemInfos = diffElements.Select(e => new RelativeElementInfo(e)).ToList();

			lvResult.Items.Clear();
			foreach (var t in _diffLines.Zip(_elemInfos)) {
				var strs = Enumerable.Repeat(t.Item1.Line, 1)
						.Concat(
								t.Item2.GetAllElements()
										.Select(e => e != null ? e.Name.ToString() : "null"));

				lvResult.Items.Add(new ListViewItem(strs.ToArray()));
			}

			if (_elemInfos.Count <= 0) {
				return;
			}

			var firstInfo = _elemInfos[0];
			var element = firstInfo.Element;
			var nextName = firstInfo.Next.Name();
			var prevName = firstInfo.Prev.Name();
			lvSuggestion.Items.Clear();
			if (_elemInfos.Skip(1).All(info => info.Next.Name() == nextName)) {
				var item = new ListViewItem(
						new[] {
								"Prev", nextName, originalXml.DescendantsAndSelf(nextName).Count().ToString(),
								_elemInfos.Count.ToString()
						});
				item.Tag = element;
				lvSuggestion.Items.Add(item);
			}
			if (_elemInfos.Skip(1).All(info => info.Prev.Name() == prevName)) {
				var item = new ListViewItem(
						new[] {
								"Next", prevName, originalXml.DescendantsAndSelf(prevName).Count().ToString(),
								_elemInfos.Count.ToString()
						});
				item.Tag = element;
				lvSuggestion.Items.Add(item);
			}
		}

		private void ShowXmlInTreeView(
				XElement root, TreeView tv, Dictionary<XElement, TreeNode> elementToNode) {
			tv.Nodes.Clear();
			if (elementToNode != null) {
				elementToNode.Clear();
			}

			var rootNode = tv.Nodes.Add(root.Name.LocalName);
			rootNode.ToolTipText = root.Value;
			if (elementToNode != null) {
				elementToNode.Add(root, rootNode);
			}
			ShowXmlInTreeView(root, rootNode, elementToNode);
		}

		private void ShowXmlInTreeView(
				XElement root, TreeNode node, Dictionary<XElement, TreeNode> elementToNode) {
			foreach (var elem in root.Elements()) {
				var child = node.Nodes.Add(elem.Name.LocalName);
				child.ToolTipText = elem.Value;
				if (elementToNode != null) {
					elementToNode.Add(elem, child);
				}
				if (elem.HasElement()) {
					ShowXmlInTreeView(elem, child, elementToNode);
				} else {
					child.Nodes.Add(elem.Value);
				}
			}
		}

		private void tabOriginal_SelectedIndexChanged(object sender, EventArgs e) {
			var tab = sender as TabControl;
			if (tab.SelectedIndex == 1) {} else if (tab.SelectedIndex == 2) {}
		}

		private void tabExample_SelectedIndexChanged(object sender, EventArgs e) {
			var tab = sender as TabControl;
			if (tab.SelectedIndex == 1) {
				var xml = _activeCodeToXml.Generate(txtExampleCode.Text);
			} else if (tab.SelectedIndex == 2) {
				var xml = _activeCodeToXml.Generate(txtExampleCode.Text);
			}
		}

		private void tabResult_SelectedIndexChanged(object sender, EventArgs e) {
			//var tab = sender as TabControl;
			//if (tab.SelectedIndex == 1) {
			//    var xml = _activeCodeToXml.Generate(txtResultCode.Text);
			//    txtResultXml.Text = xml.ToString();
			//}
		}

		private void Form1_Load(object sender, EventArgs e) {
			var menuItems = new List<ToolStripMenuItem>();
			foreach (var codeToXml in PluginManager.CodeToXmls) {
				var menuItem = menuLanguage.DropDownItems.Add(codeToXml.ParserName) as ToolStripMenuItem;
				menuItems.Add(menuItem);
				var codeToXmlForClosure = codeToXml;
				menuItem.Click += (o, args) => {
					_activeCodeToXml = codeToXmlForClosure;
					foreach (var item in menuItems) {
						item.Checked = false;
					}
					menuItem.Checked = true;
				};
			}

			txtOriginalCode.Text =
					@"class Sample {
  void main() {
    int a = 0;
    if (a == 0) {
      System.out.println(0);
    } else {
      System.out.println(1);
    }
    try {
      throw new Exception();
      a++;
    }
    finally {
      a--;
    }
  }
}".Replace("\r\n", "\n").Replace("\n", Environment.NewLine);
			txtExampleCode.Text =
					@"class Sample {
  void main() {
    stmt();
    int a = 0;
    stmt();
    if (a == 0) {
      System.out.println(0);
    } else {
      System.out.println(1);
    }
    try {
      throw new Exception();
      a++;
    }
    finally {
      a--;
    }
  }
}".Replace("\r\n", "\n").Replace("\n", Environment.NewLine);
		}

		private void tvOriginal_AfterSelect(object sender, TreeViewEventArgs e) {}

		private void lvResult_MouseDoubleClick(object sender, MouseEventArgs e) {
			if (lvResult.SelectedIndices.Count > 0) {
				var index = lvResult.SelectedIndices[0];
				var node = _elementToNode[_elemInfos[index].Element];
				tabExample.SelectedIndex = 2;
				tvExample.SelectedNode = node;
				tvExample.Focus();
			}
		}

		private void tvExample_MouseMove(object sender, MouseEventArgs e) {
			var treeView = sender as TreeView;
			// Get the node at the current mouse pointer location.
			var node = treeView.GetNodeAt(e.X, e.Y);

			// Set a ToolTip only if the mouse pointer is actually paused on a node.
			if (node != null) {
				// Verify that the tag property is not "null".
				if (node.ToolTipText != null) {
					// Change the ToolTip only if the pointer moved to a new node.
					if (node != _lastTreeNode) {
						toolTip1.SetToolTip(treeView, node.ToolTipText);
						_lastTreeNode = node;
					}
				} else {
					toolTip1.SetToolTip(treeView, "");
				}
			} else // Pointer is not over a node so clear the ToolTip.
			{
				toolTip1.SetToolTip(treeView, "");
			}
		}

		private void lvSuggestion_MouseDoubleClick(object sender, MouseEventArgs e) {
			if (lvSuggestion.SelectedItems.Count > 0) {
				foreach (ListViewItem item in lvSuggestion.SelectedItems) {
					lvAccepted.Items.Add((ListViewItem)item.Clone());
				}
				ChangedAcceptedListView();
			}
		}

		private void lvAccepted_MouseDoubleClick(object sender, MouseEventArgs e) {
			if (lvAccepted.SelectedItems.Count > 0) {
				foreach (ListViewItem item in lvAccepted.SelectedItems) {
					lvAccepted.Items.Remove(item);
				}
				ChangedAcceptedListView();
			}
		}

		private bool IsExcluded(XElement target, List<List<XElement>> exElemSeqList) {
			foreach (var elems in exElemSeqList) {
				if (Analyzer.HasSameElementNameSequence(target, elems)) {
					return true;
				}
			}
			return false;
		}

		private void ChangedAcceptedListView() {
			var xml = _activeCodeToXml.Generate(txtOriginalCode.Text);

			var exElemSeqList = lvAccepted.Items.Cast<ListViewItem>()
					.Where(item => item.SubItems[0].Text == "Delete")
					.Select(item => item.Tag).Cast<List<XElement>>().ToList();
			foreach (var e in xml.DescendantsAndSelf()) {
				if (IsExcluded(e, exElemSeqList)) {
					foreach (var e2 in e.DescendantsAndSelf()) {
						e2.SetAttributeValue("exclusion", "true");
					}
				}
			}

			foreach (ListViewItem item in lvAccepted.Items) {
				var dir = item.SubItems[0].Text;
				if (dir == "Delete") {
					continue;
				}
				var name = item.SubItems[1].Text;
				var newElem = item.Tag as XElement;
				var elems = xml.DescendantsAndSelf(name);
				switch (dir) {
				case "Prev":
					foreach (var elem in elems) {
						if (elem.Attribute("exclusion") == null) {
							elem.AddBeforeSelf(newElem);
						}
					}
					break;
				case "Next":
					foreach (var elem in elems) {
						if (elem.Attribute("exclusion") == null) {
							elem.AddAfterSelf(newElem);
						}
					}
					break;
				default:
					throw new IndexOutOfRangeException();
				}
			}
			txtResultCode.Text = _activeCodeToXml.XmlToCode.Generate(xml);
			txtResultXml.Text = xml.ToString();
		}

		private void button2_Click(object sender, EventArgs e) {
			ChangedAcceptedListView();
		}

		private void button3_Click(object sender, EventArgs eventArgs) {
			if (txtOriginalCode.SelectionLength == 0) {
				return;
			}
			var originalCode = txtOriginalCode.Text;
			var originalXml = _activeCodeToXml.Generate(originalCode);
			var startLine =
					txtOriginalCode.Text.Substring(0, txtOriginalCode.SelectionStart)
							.Count(ch => ch == Environment.NewLine[0]) + 1;
			var endLine =
					txtOriginalCode.Text.Substring(
							0, txtOriginalCode.SelectionStart + txtOriginalCode.SelectionLength - 1)
							.Count(ch => ch == Environment.NewLine[0]) + 1;
			var exclusions = Analyzer.FindElementsBySelectedLines(originalXml, startLine, endLine);
			lvSuggestion.Items.Clear();
			foreach (var exclusion in exclusions) {
				var item = new ListViewItem(
						new[] {
								"Delete", string.Join(", ", exclusion.Select(e => e.Name()))
						});
				item.Tag = exclusion;
				lvSuggestion.Items.Add(item);
			}
		}
	}
}