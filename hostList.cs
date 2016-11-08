using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Configuration;

//using Properties.Settings;

namespace erstool
{
    public partial class hostList : UserControl
    {
        public delegate void ItemDoubleClickDelegate(object sender);

        private enum PressedKeyType { Invalid, AlphaNumeric, Period, Space, BackSpace, Tab, Underscore };

        private ErsToolConfiguration config = null;

        private string hostsFile = String.Empty;
        private const string settingsParamColumnWidths = "HostListColumnWidths";
        private string columnWidths = String.Empty;

        private ListViewColumnSorter lvwColumnSorter;

        private List<ListViewItem> hiddenItems = new List<ListViewItem>();

        public event ItemDoubleClickDelegate ItemDoubleClick = null;

        public ErsToolConfiguration Configuration 
        {
            get { return config; }
            set { config = value; } 
        }

        public hostList()
        {
            InitializeComponent();

            lvwColumnSorter = new ListViewColumnSorter();
            this.listView.ListViewItemSorter = lvwColumnSorter;
        }

        public string HostsFile
        {
            get { return hostsFile; }
            set
            {
                if (File.Exists(value))
                {
                    hostsFile = value;
                    LoadHostsFile();
                    LoadSettings();
                }
            }
        }

        public string ManagementIpAddress
        {
            get
            {
                if (listView.SelectedItems.Count != 1)
                    return String.Empty;
                else
                {
                    ListViewItem item = listView.SelectedItems[0];
                    return item.SubItems[3].Text;
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
                    return item.SubItems[2].Text;
                }
            }
        }

        public string HostName
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

        private void LoadHostsFile()
        {
            listView.BeginUpdate();
            listView.Clear();

            using (StreamReader reader = new StreamReader(hostsFile))
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

            toolStripStatusLabel.Text = listView.Items.Count.ToString() + " hosts";
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
            string columnWidths = config.HostParamColumnWidths;
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

            config.HostParamColumnWidths = columnWidths;
        }

        private void listView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            SortByColumn(e.Column);
        }

        private void SortByColumn(int clickedColumn)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (clickedColumn == lvwColumnSorter.SortColumn)
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
                lvwColumnSorter.SortColumn = clickedColumn;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.listView.Sort();
        }

#if false
        private void PerformSearch(PressedKeyType pressedKeyType, char pressedKey, string previousSearchTerm)
        {
            string searchString;

            if (pressedKeyType == PressedKeyType.Invalid)
                return;
            else if (pressedKeyType == PressedKeyType.Space)
                return;
            else if (pressedKeyType == PressedKeyType.BackSpace)
            {
                // bring back some of the hidden items
                previousSearchTerm = previousSearchTerm.Trim();
                if ((previousSearchTerm == null) || (previousSearchTerm == String.Empty))
                //if (String.IsNullOrWhiteSpace(previousSearchTerm))
                    return;

                searchString = previousSearchTerm.Substring(0, previousSearchTerm.Length - 1);
                searchString = searchString.Trim();
                if ((searchString == null) || (searchString == String.Empty))
                //if (String.IsNullOrEmpty(searchString) || String.IsNullOrWhiteSpace(searchString))
                {
                    listView.BeginUpdate();

                    while (hiddenItems.Count > 0)
                    {
                        listView.Items.Add(hiddenItems[0]);
                        hiddenItems.RemoveAt(0);
                    }

                    listView.EndUpdate();

                    toolStripStatusLabel.Text = listView.Items.Count.ToString() + " hosts";

                    return;
                }

                string[] searchTerms = searchString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (searchTerms.Length < 1)
                {
                    listView.BeginUpdate();

                    while (hiddenItems.Count > 0)
                    {
                        listView.Items.Add(hiddenItems[0]);
                        hiddenItems.RemoveAt(0);
                    }

                    listView.EndUpdate();

                    toolStripStatusLabel.Text = listView.Items.Count.ToString() + " hosts";

                    return;
                }

                ReturnHiddenItemsToView(searchTerms);
            }
            else // either a period, an underscore or an alphanumeric character
            {
                searchString = previousSearchTerm + pressedKey;
                string[] searchTerms = searchString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (searchTerms.Length < 1)
                    return;

                string righmostSearchTerm = searchTerms[searchTerms.Length - 1];
                //if (righmostSearchTerm.Length < 2)
                //    return;

                RemoveAllItemsNotMatching(righmostSearchTerm);
            }
        }

        private void RemoveAllItemsNotMatching(string searchTerm)
        {
            string hostString;
            int index = 0;
            bool match;

            searchTerm = searchTerm.ToLower();

            listView.BeginUpdate();

            while (index < listView.Items.Count)
            {
                hostString = listView.Items[index].Tag as String;
                match = hostString.IndexOf(searchTerm) >= 0;

                if (match)
                    index++;
                else
                {
                    hiddenItems.Add(listView.Items[index]);
                    listView.Items.RemoveAt(index);
                }
            }

            listView.EndUpdate();

            toolStripStatusLabel.Text = listView.Items.Count.ToString() + " hosts";
        }

        private void ReturnHiddenItemsToView(string[] searchTerms)
        {
            string hostString;
            int index = 0;
            int matchCount;

            if ((searchTerms == null) || (searchTerms.Length == 0))
                return;

            listView.BeginUpdate();

            while (index < hiddenItems.Count)
            {
                hostString = hiddenItems[index].Tag as String;
                matchCount = 0;

                foreach (string searchTerm in searchTerms)
                {
                    string lowerCaseSearchTerm = searchTerm.ToLower();
                    if (hostString.IndexOf(searchTerm) < 0)
                        break;
                    else
                        matchCount++;
                }

                if (matchCount == searchTerms.Length)
                {
                    listView.Items.Add(hiddenItems[index]);
                    hiddenItems.RemoveAt(index);
                }
                else
                    index++;
            }

            listView.EndUpdate();

            toolStripStatusLabel.Text = listView.Items.Count.ToString() + " hosts";
        }
#endif

        private void hostList_Load(object sender, EventArgs e)
        {
            toolStripTextBox1.Focus();
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

            using (StreamReader reader = new StreamReader(hostsFile))
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

            toolStripStatusLabel.Text = listView.Items.Count.ToString() + " hosts";

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

        private void listView_DoubleClick(object sender, EventArgs e)
        {
            if (ItemDoubleClick != null)
                ItemDoubleClick(this);
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
