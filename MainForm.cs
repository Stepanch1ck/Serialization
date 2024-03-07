using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Serialization
{
    public partial class MainForm : Form
    {
        SkiResort SkiResorts;
        public MainForm()
        {
            InitializeComponent();
        }

        private void LoadTable_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = @"..\";
            openFileDialog.Filter = "JSON files (*.json)|*.json|XML files (*.xml)|*.xml";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                if (Path.GetExtension(filePath) == ".json")
                {
                    LoadEntitiesFromJson(filePath);
                }
                else if (Path.GetExtension(filePath) == ".xml")
                {

                    LoadEntitiesFromXml(filePath);
                }
                else
                {
                    MessageBox.Show("Ошибка загрузки файла, неправильный формат.");
                }
            }
        }

        private void ShowTable_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
            DataGridViewRow row = this.dataGridViewInfo.SelectedRows[0];
            for (int i = 0; i < dataGridViewInfo.Columns.Count; i++)
            {
                String header = dataGridViewInfo.Columns[i].HeaderText;
                var cellText = row.Cells[i].Value.ToString();
                keyValuePairs.Add(header, cellText);
            }
            CreateForm(keyValuePairs);
        }

        private void CreateForm(Dictionary<string, string> keyValuePairs)
        {

            TextBox[] txtBox;
            Label[] lbl;
            DetailForm detailForm = new DetailForm();
            int n = keyValuePairs.Count();
            txtBox = new TextBox[n];
            lbl = new Label[n];

            int space = 10;
            for (int i = 0; i < n; i++)
            {
                txtBox[i] = new TextBox();
                txtBox[i].Text = keyValuePairs.ElementAt(i).Value;

                lbl[i] = new Label();
                lbl[i].Text = keyValuePairs.ElementAt(i).Key;
            }


            for (int i = 0; i < n; i++)
            {
                txtBox[i].Visible = true;
                lbl[i].Visible = true;
                txtBox[i].Location = new Point(100, 40 + space);
                lbl[i].Location = new Point(10, 40 + space);
                detailForm.Controls.Add(txtBox[i]);
                detailForm.Controls.Add(lbl[i]);
                space += 50;
            }
            detailForm.ShowDialog();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MaintreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            dataGridViewInfo.DataSource = null;

            if (MaintreeView.SelectedNode != null)
            {

                var property = SkiResorts[MaintreeView.SelectedNode.Text];
                if (property?.GetType().Name == "String")
                {
                    CreateRow(property);
                }
                else if (property == null)
                {
                    if (int.TryParse(MaintreeView.SelectedNode.Text, out var index))
                    {
                        var all = SkiResorts[MaintreeView.SelectedNode.Parent.Text];
                        dataGridViewInfo.DataSource = all;
                    }
                }

                else
                    dataGridViewInfo.DataSource = property;
                dataGridViewInfo.AutoResizeColumns();
                dataGridViewInfo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                ShowTable.Enabled = true;
            }

        }

        void CreateRow(object property)
        {
            DataTable dt = new DataTable();
            DataColumn dCol1 = new DataColumn(MaintreeView.SelectedNode.Text, typeof(System.String));
            dt.Columns.Add(dCol1);

            DataRow row1 = dt.NewRow();
            row1[MaintreeView.SelectedNode.Text] = property;
            dt.Rows.Add(row1);

            dataGridViewInfo.DataSource = dt;
        }

        private void LoadEntitiesFromJson(string filePath)
        {
            string json = File.ReadAllText(filePath);
            SkiResorts = JsonConvert.DeserializeObject<SkiResort>(json);

            using (var reader = new StreamReader(filePath))
            using (var jsonReader = new JsonTextReader(reader))
            {

                var root = JToken.Load(jsonReader);
                DisplayTreeView(root, Path.GetFileNameWithoutExtension(filePath));
            }
        }

        private void DisplayTreeView(JToken root, string rootName)
        {
            MaintreeView.BeginUpdate();
            try
            {
                MaintreeView.Nodes.Clear();
                var tNode = MaintreeView.Nodes[MaintreeView.Nodes.Add(new TreeNode(rootName))];
                tNode.Tag = root;

                AddNode(root, tNode);
            }
            finally
            {
                MaintreeView.EndUpdate();
            }
        }
        private void AddNode(JToken token, TreeNode inTreeNode)
        {
            if (token == null)
                return;
            if (token is JValue)
            {
                var childNode = inTreeNode.Nodes[inTreeNode.Nodes.Add(new TreeNode(token.ToString()))];
                childNode.Tag = token;
            }
            else if (token is JObject)
            {
                var obj = (JObject)token;
                foreach (var property in obj.Properties())
                {
                    var childNode = inTreeNode.Nodes[inTreeNode.Nodes.Add(new TreeNode(property.Name))];
                    childNode.Tag = property;
                    AddNode(property.Value, childNode);
                }
            }
            else if (token is JArray)
            {
                var array = (JArray)token;
                for (int i = 0; i < array.Count; i++)
                {
                    var childNode = inTreeNode.Nodes[inTreeNode.Nodes.Add(new TreeNode(i.ToString()))];
                    childNode.Tag = array[i];
                    AddNode(array[i], childNode);
                }
            }
            else
            {
                Debug.WriteLine(string.Format("{0} not implemented", token.Type)); // JConstructor, JRaw
            }
        }

        private void LoadEntitiesFromXml(string filePath)
        {
            XmlRootAttribute xRoot = new XmlRootAttribute();
            xRoot.ElementName = "root";
            xRoot.IsNullable = true;
            XmlSerializer serializer = new XmlSerializer(typeof(SkiResort), xRoot);
            using (var reader = new StreamReader(filePath))
            {
                SkiResorts = (SkiResort)serializer.Deserialize(reader);
                var jsonString = JsonConvert.SerializeObject(SkiResorts);

                using (TextReader sr = new StringReader(jsonString))
                {
                    var root = JToken.Load(new JsonTextReader(sr));
                    DisplayTreeView(root, Path.GetFileNameWithoutExtension(filePath));
                }

            }
        }

        object GetProperty(object property)
        {
            if (property == null)
            {
                foreach (var item in SkiResorts.SkiRuns)
                {
                    return GetProperty(item[MaintreeView.SelectedNode.Text]);
                }
                foreach (var item in SkiResorts.Lodges)
                {
                    return GetProperty(item[MaintreeView.SelectedNode.Text]);
                }
            }
            return property;

        }
    }
}
