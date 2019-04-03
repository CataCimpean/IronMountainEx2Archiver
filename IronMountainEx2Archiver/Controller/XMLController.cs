using IronMountainEx2Archiver.DTO;
using IronMountainEx2Archiver.Utils.Components;
using IronMountainEx2Archiver.Utils.Xml;
using System;
using System.Drawing;
using System.IO;

namespace IronMountainEx2Archiver.Controller
{
    public class  XMLController
    {
        private Form1 form1 = null;
        private ArchivatorDTO archivatorDTO = null;

        public XMLController(Form1 form1)
        {
            this.form1 = form1;
        }

        public ArchivatorDTO ConvertXMLToObject()
        {
            try
            {
                if (form1.xmlPath != string.Empty && form1.xmlPath != null)
                {
                    XMLConverter xmlConv = new XMLConverter();
                    string xmlInputData = File.ReadAllText(form1.xmlPath);
                    archivatorDTO = xmlConv.Deserialize<ArchivatorDTO>(xmlInputData);
                    ComponentsUtil.AppendTextToRichTextBox(form1.GetRichTextBoxInfo(), "XML structure is OK..", Color.Green, true);
                }
                else
                {
                    ComponentsUtil.AppendTextToRichTextBox(form1.GetRichTextBoxInfo(), "Error please check XML structure", Color.Red, true);
                }
                return archivatorDTO;
            }
            catch (Exception ex)
            {
                ComponentsUtil.AppendTextToRichTextBox(form1.GetRichTextBoxInfo(),String.Format("Error Load XML: {0}",ex.Message), Color.Red, true);
                return archivatorDTO;
            };
        }
    }
}
