using IronMountainEx2Archiver.Controller;
using IronMountainEx2Archiver.DTO;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace IronMountainEx2Archiver
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string xmlPath { get; set; }
        public ArchivatorDTO archivatorDTO { get; set; }
        public DataGridView GetGridViewStructureXMLLoaded()
        {
            return gridViewStructureXMLLoaded;
        }

        public RichTextBox GetRichTextBoxInfo()
        {
            return textBoxInfo;
        }

        public Button GetCreateArchiveButton()
        {
            return createArchiveButton;
        }

        public Button GetUploadXMLButton()
        {
            return uploadXMLButton;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void uploadXMLButton_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK)
            {
                xmlPath = openFileDialog1.FileName;
                AppController appControllerXMLData = new AppController((Form1)FindForm());
                appControllerXMLData.StartParseXMLEntries();
            }
        }

        private void gridViewStructureXMLLoaded_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gridViewStructureXMLLoaded_RowAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int i = e.RowIndex; i < e.RowCount + e.RowIndex; i++)
            {
                gridViewStructureXMLLoaded.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBoxInfo_TextChanged(object sender, EventArgs e)
        {
        }

        private void createArchiveButton_Click(object sender, EventArgs e)
        {
            AppController appControllerArchiver = new AppController((Form1)FindForm());
            appControllerArchiver.StartBuildArchive();
        }
    }
}
