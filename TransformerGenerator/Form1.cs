using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using Code2Xml.Languages.Java.CodeToXmls;
using Paraiba.Core;

namespace TransformerGenerator {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            textBox1.Text =
                    @"class Test {
  void main() {
    int a = 0;
    a++;
  }
}";
            textBox2.Text =
                    @"class Test {
  void main() {
    stmt();
    int a = 0;
    stmt();
    a++;
  }
}";
        }

        private void RemoveAttributes(XElement elem) {
            foreach (var e in elem.DescendantsAndSelf()) {
                e.RemoveAttributes();
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            var xml1 = JavaCodeToXml.Instance.Generate(textBox1.Text);
            var xml2 = JavaCodeToXml.Instance.Generate(textBox2.Text);
            //RemoveAttributes(xml1);
            //RemoveAttributes(xml2);
            textBox3.Text = xml1.ToString();
            textBox4.Text = xml2.ToString();
            File.WriteAllText("file1.xml", textBox3.Text);
            File.WriteAllText("file2.xml", textBox4.Text);
            var processorPath = "java";
            var arguments = new[] {
                    "-Djava.ext.dirs=jar",
                    "-cp",
                    "jar/xmldiff.jar",
                    "fc.xml.diff.Diff",
                    "file1.xml",
                    "file2.xml",
                    "diff.xml"
            };
            var info = new ProcessStartInfo {
                    FileName = processorPath,
                    Arguments = arguments.JoinString(" "),
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    //WorkingDirectory = WorkingDirectory,
            };
            using (var p = Process.Start(info)) p.WaitForExit();

            var extractedElement = "nil";
            var modified = new XElement("stmt");
            var difflines = Analyzer.Analyze(textBox1.Text, textBox2.Text);
            var extractedElementList = Analyzer.Find(xml2, difflines);
            extractedElement =
                    extractedElementList.Select((x) => x.ToString()).Aggregate((x, y) => x + y);
            textBox5.Text = extractedElement;
        }
    }
}