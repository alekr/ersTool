using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using System.IO;

namespace erstool
{
    public partial class virtServList : UserControl
    {
        private enum PressedKeyType { Invalid, AlphaNumeric, Period, Space, BackSpace, Tab, Underscore };

        private ErsToolConfiguration config = null;

        private string serversFile = String.Empty;
        private const string settingsParamColumnWidths = "HostListColumnWidths";
        private string columnWidths = String.Empty;

        private ListViewColumnSorter lvwColumnSorter;

        private List<ListViewItem> hiddenItems = new List<ListViewItem>();

        public ErsToolConfiguration Configuration
        {
            get { return config; }
            set { config = value; }
        }

        public virtServList()
        {
            InitializeComponent();

            lvwColumnSorter = new ListViewColumnSorter();
            this.listView.ListViewItemSorter = lvwColumnSorter;
        }

        public string ServersFile
        {
            get { return serversFile; }
            set
            {
                if (File.Exists(value))
                {
                    serversFile = value;
                    LoadServersFile();
                    LoadSettings();
                }
            }
        }

        public string ApplicationIpAddress
        {
            get
            {
                if (listView.SelectedItems.Count != 1)
                    return String.Empty;
                else
                {
                    ListViewItem item = listView.SelectedItems[0];
                    return item.SubItems[4].Text;
                }
            }
        }

        public string ServerName
        {
            get
            {
                if (listView.SelectedItems.Count != 1)
                    return String.Empty;
                else
                {
                    ListViewItem item = listView.SelectedItems[0];
                    return item.SubItems[1].Text;
                }
            }
        }

        public String CurrentList
        {
            get { return GetCurrentList(","); }
        }

        public String CurrentListWithTabs
        {
            get { return GetCurrentList("\t"); }
        }

        private void LoadServersFile()
        {
            listView.BeginUpdate();
            listView.Clear();

            using (StreamReader reader = new StreamReader(serversFile))
            {
                bool firstLine = true;
                while (reader.EndOfStream == false)
                {
                    string line = reader.ReadLine();
                    if (firstLine)
                    {
                        AddColumns(line);
                        firstLine = false;
                    }
                    else
                        AddRow(line);
                }
                reader.Close();
            }

            listView.EndUpdate();

            toolStripStatusLabel.Text = listView.Items.Count.ToString() + " servers";
        }

        private void AddColumns(string line)
        {
            string[] columnNames = line.Split(new char[] { '\t' });
            foreach (string columnName in columnNames)
            {
                string trimmedColumnName = columnName.Trim();
                listView.Columns.Add(trimmedColumnName);
            }
        }

        private void AddRow(string line)
        {
            bool firstItem = true;
            ListViewItem listViewItem = null;
            string[] items = line.Split(new char[] { '\t' });

            foreach (string item in items)
            {
                string trimmedItem = item.Trim();
                if (firstItem)
                {
                    listViewItem = listView.Items.Add(trimmedItem);
                    listViewItem.Tag = line.ToLower();
                    firstItem = false;
                }
                else
                    listViewItem.SubItems.Add(trimmedItem);
            }
        }

        public void LoadSettings()
        {
            string columnWidths = config.VirtServParamColumnWidths;
            string[] items = columnWidths.Split(new char[] { ',' });

            if (items.Length != listView.Columns.Count)
                return;

            int index = 0;
            foreach (ColumnHeader ch in listView.Columns)
            {
                ch.Width = Convert.ToInt32(items[index++]);
            }
        }

        public void SaveSettings()
        {
            columnWidths = String.Empty;

            foreach (ColumnHeader columnHeader in listView.Columns)
            {
                if (columnWidths == String.Empty)
                    columnWidths = columnHeader.Width.ToString();
                else
                    columnWidths += "," + columnHeader.Width.ToString();
            }

            config.VirtServParamColumnWidths = columnWidths;
        }

        private void listView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                    lvwColumnSorter.Order = SortOrder.Descending;
                else
                    lvwColumnSorter.Order = SortOrder.Ascending;
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.listView.Sort();
        }

        public void FocusOnSearchBox()
        {
            toolStripTextBox1.Focus();
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            string searchString = toolStripTextBox1.Text;
            string[] searchTerms = searchString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            bool firstLine = true;

            ListViewColumnSorter lvwColumnSorter_save = null;

            lvwColumnSorter_save = (ListViewColumnSorter)this.listView.ListViewItemSorter;
            this.listView.ListViewItemSorter = null;

            listView.BeginUpdate();

            listView.Items.Clear();

            using (StreamReader reader = new StreamReader(serversFile))
            {
                while (reader.EndOfStream == false)
                {
                    string line = reader.ReadLine();
                    if (firstLine)
                        firstLine = false;
                    else
                    {
                        if (searchTerms.Length > 0)
                            AddFilteredRow(line, searchTerms);
                        else
                            AddRow(line);
                    }
                }
                reader.Close();
            }

            listView.EndUpdate();

            toolStripStatusLabel.Text = listView.Items.Count.ToString() + " servers";

            this.listView.ListViewItemSorter = lvwColumnSorter_save;
        }

        private void AddFilteredRow(string line, string[] searchTerms)
        {
            string hostString = line.ToLower();
            foreach (string searchTerm in searchTerms)
            {
                string lowerCaseTerm = searchTerm.ToLower();
                if (hostString.IndexOf(searchTerm) < 0)
                    return;
            }

            AddRow(line);
        }

        private String GetCurrentList(String separator)
        {
            String result = String.Empty;

            foreach (ListViewItem item in listView.Items)
            {
                result += GetListRow(item, separator) + "\r\n";
            }

            return GetHeader(separator) + "\r\n" + result;
        }

        private String GetHeader(String separator)
        {
            String result = String.Empty;

            foreach (ColumnHeader column in listView.Columns)
            {
                if (result != String.Empty)
                    result += separator;

                result += column.Text;
            }

            return result;
        }

        private String GetListRow(ListViewItem item, String separator)
        {
            String result = String.Empty;

            if (item != null)
            {
                foreach (ListViewItem.ListViewSubItem subitem in item.SubItems)
                {
                    if (result != String.Empty)
                        result += separator;

                    result += subitem.Text;
                }
            }

            return result;
        }
    }
}
