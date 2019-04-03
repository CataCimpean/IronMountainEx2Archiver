using IronMountainEx2Archiver.DTO;
using IronMountainEx2Archiver.Utils;
using System;

namespace IronMountainEx2Archiver.Controller
{
    public class FileController
    {
        private Form1 form1;
        private ArchivatorDTO archivatorDTO;
        public FileController(Form1 form1)
        {
            this.form1 = form1;
            this.archivatorDTO = form1.archivatorDTO;
        }

        public string BuildMetaFile()
        {
            try
            {
               return FileUtil.BuildContentMetaFile(archivatorDTO);
            }
            catch (Exception ex) { throw ex; };
        }
    }
}
