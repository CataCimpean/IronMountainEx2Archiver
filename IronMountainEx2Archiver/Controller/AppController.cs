using IronMountainEx2Archiver.DTO;
using IronMountainEx2Archiver.Utils.Components;
using System.Drawing;
using System.IO;

namespace IronMountainEx2Archiver.Controller
{
    public class AppController
    {
        private Form1 form1;
        private ArchivatorDTO archivatorDTO = null;

        public AppController(Form1 form1)
        {
            this.form1 = form1;
        }

        public void StartParseXMLEntries()
        {
            //load xml structure in an object
            XMLController xmlCtrl = new XMLController(form1);
            archivatorDTO = xmlCtrl.ConvertXMLToObject();

            if (archivatorDTO != null)
            {
                //show XML data loaded in a gridView
                DataGridViewController.FillGridViewWithDataLoaded(form1);

                //made visible CreateArchive button
                ComponentsUtil.SetButtonVisibility(form1.GetCreateArchiveButton());

                //message to createArchive
                ComponentsUtil.AppendTextToRichTextBox(form1.GetRichTextBoxInfo(), "\tPress CreateArchive to build archive..", Color.Green, true);

                //maintain object to used later
                form1.archivatorDTO = archivatorDTO;
            }
        }

        public void StartBuildArchive()
        {
            //retrive archivatorDTO object
            archivatorDTO = form1.archivatorDTO;

            if(archivatorDTO != null && archivatorDTO.Delimiter !=null && archivatorDTO.Destination != null && archivatorDTO.Source !=null && archivatorDTO.StartIndex!=null)
            {
                //check if source dir exist on disk
                if (!Directory.Exists(archivatorDTO.Source))
                {
                    ComponentsUtil.AppendTextToRichTextBox(form1.GetRichTextBoxInfo(), "\tSource dir not exist..", Color.Red, true);
                    return;
                }
                ComponentsUtil.AppendTextToRichTextBox(form1.GetRichTextBoxInfo(), "\tStarting build archive files..", Color.Green, true);
                ArchiveController archiveCtrl = new ArchiveController(form1);
                archiveCtrl.BuildZipFile();
                ComponentsUtil.AppendTextToRichTextBox(form1.GetRichTextBoxInfo(), "\tFinished build archive file..", Color.Green, true);
            }
        }
    }
}
