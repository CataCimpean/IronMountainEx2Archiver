using IronMountainEx2Archiver.DTO;
using IronMountainEx2Archiver.Utils;
using IronMountainEx2Archiver.Utils.Archive;
using IronMountainEx2Archiver.Utils.Components;
using IronMountainEx2Archiver.Utils.Date;
using System;
using System.Drawing;
using System.IO;

namespace IronMountainEx2Archiver.Controller
{
    public class ArchiveController
    {
        private Form1 form1;
        private ArchivatorDTO archivatorDTO;
        private bool zipBuilt;
        public string pathMetadata;
        public ArchiveController(Form1 form1)
        {
            this.form1 = form1;
            this.archivatorDTO = form1.archivatorDTO;
        }

        public bool BuildZipFile()
        {
            try
            {
                //message info step1 (create .meta file)
                ComponentsUtil.AppendTextToRichTextBox(form1.GetRichTextBoxInfo(), "\t\tStep1:Create .meta file", Color.Blue, true);

                //build meta file
                FileController fileCtrl = new FileController(form1);
                string metaDataContent = fileCtrl.BuildMetaFile();
                pathMetadata = String.Format(@"{0}\{1}", archivatorDTO.Source, "InfoImages.meta");
                FileUtil.BuildFile(metaDataContent, pathMetadata);
                ComponentsUtil.AppendTextToRichTextBox(form1.GetRichTextBoxInfo(), "\t\tOK..", Color.Blue, true);

                //message info step2 (create .zip file)
                ComponentsUtil.AppendTextToRichTextBox(form1.GetRichTextBoxInfo(), "\t\tStep2:Create archive file", Color.Blue, true);
                
                //build zip file
                string[] imagesPath = FileUtil.GetImagesFromDir(archivatorDTO.Source);
                string destinationZipData = String.Format(@"{0}\{1}.zip", archivatorDTO.Destination,DateUtil.GetDateYYYMMDDHHMMSS());
                ArchiveUtil.ZipData(imagesPath, pathMetadata, destinationZipData);

                //Check if zip file was built succesfully
                if (File.Exists(destinationZipData))
                {
                    ComponentsUtil.AppendTextToRichTextBox(form1.GetRichTextBoxInfo(), "\t\tOK..", Color.Blue, true);
                    zipBuilt = true;
                }
                else{
                    ComponentsUtil.AppendTextToRichTextBox(form1.GetRichTextBoxInfo(), "\t\tZip file not built..", Color.Red, true);
                };
                return zipBuilt;
            }
            catch(Exception ex) {
                ComponentsUtil.AppendTextToRichTextBox(form1.GetRichTextBoxInfo(), String.Format("\t\tError:{0}",ex.Message),Color.Red,true);
                return zipBuilt;
            };
        }
    }
}
