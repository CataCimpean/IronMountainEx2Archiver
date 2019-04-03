using IronMountainEx2Archiver.DTO;
using IronMountainEx2Archiver.Utils;
using IronMountainEx2Archiver.Utils.Archive;
using IronMountainEx2Archiver.Utils.Components;
using IronMountainEx2Archiver.Utils.Date;
using System;
using System.Drawing;

namespace IronMountainEx2Archiver.Controller
{
    public class ArchiveController
    {
        private Form1 form1 = null;
        private ArchivatorDTO archivatorDTO = null;
        public ArchiveController(Form1 form1)
        {
            this.form1 = form1;
            this.archivatorDTO = form1.archivatorDTO;
        }

        public void BuildZipFile()
        {
            try
            {
                //message info step1 (create .meta file)
                ComponentsUtil.AppendTextToRichTextBox(form1.GetRichTextBoxInfo(), "\t\tStep1:Create .meta file", Color.Blue, true);

                //build meta file
                FileController fileCtrl = new FileController(form1);
                string metaDataContent = fileCtrl.BuildMetaFile();
                string pathMetadata = String.Format(@"{0}\{1}", archivatorDTO.Source, "InfoImages.meta");
                FileUtil.BuildFile(metaDataContent, pathMetadata);
                ComponentsUtil.AppendTextToRichTextBox(form1.GetRichTextBoxInfo(), "\t\tOK..", Color.Blue, true);

                //message info step2 (create .zip file)
                ComponentsUtil.AppendTextToRichTextBox(form1.GetRichTextBoxInfo(), "\t\tStep2:Create archive file", Color.Blue, true);
                
                //build zil file
                string[] imagesPath = FileUtil.GetImagesFromDir(archivatorDTO.Source);
                string destinationZipData = String.Format(@"{0}\{1}.zip", archivatorDTO.Destination,DateUtil.GetDateYYYMMDDHHMMSS());
                ArchiveUtil.ZipData(imagesPath, pathMetadata, destinationZipData);
                ComponentsUtil.AppendTextToRichTextBox(form1.GetRichTextBoxInfo(), "\t\tOK..", Color.Blue, true);
            }
            catch(Exception ex) {
                ComponentsUtil.AppendTextToRichTextBox(form1.GetRichTextBoxInfo(), String.Format("\t\tError:{0}",ex.Message),Color.Red,true);
            };
        }
    }
}
