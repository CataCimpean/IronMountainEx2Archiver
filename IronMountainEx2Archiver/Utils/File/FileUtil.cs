using IronMountainEx2Archiver.DTO;
using IronMountainEx2Archiver.Utils.Date;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace IronMountainEx2Archiver.Utils
{
    public class FileUtil
    {

        public static string BuildContentMetaFile(ArchivatorDTO archivatorDTO)
        {
            try
            {
                StringBuilder sbContentMeta = new StringBuilder();
                sbContentMeta.AppendLine(GetHeaderMetaFile());

                ///obtain imagesPath
                string[] imagesPath = GetImagesFromDir(archivatorDTO.Source);

                //obtain initialIndex from XML file
                int intialIndex;
                Int32.TryParse(archivatorDTO.StartIndex, out intialIndex);

                //build content of .meta file
                foreach (string imagePath in imagesPath)
                {
                    sbContentMeta.AppendLine(String.Format("{0}{1}{2}{3}{4}", GetIDImage(intialIndex++), archivatorDTO.Delimiter, DateUtil.GetDateTimeWithoutPMorAM(GetDateCreatedFile(imagePath)), archivatorDTO.Delimiter, GetImageRoute(imagePath)));
                }
                return sbContentMeta.ToString();
            }
            catch(Exception ex) { throw ex; };
        }


        public static void BuildFile(string metaContent,string destination)
        {
            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(destination))
            {
                file.WriteLine(metaContent);
            }
        }

        public static void BuildDirectory(string dirPath)
        {
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
        }

        private static string GetImageRoute(string pathImg) {
            return String.Format("{0}/{1}", DateUtil.GetToday(), pathImg.Substring(pathImg.LastIndexOf(@"\") + 1));
        }

        private static string GetIDImage(int noImg)
        {
            StringBuilder builderId = new StringBuilder();
            builderId.Append("{0}{1}");
            builderId.Replace("{0}", DateUtil.ConvertDateTimeToJulianYYJJJ(DateTime.Now).ToString()); //Add Julian part to Id
            builderId.Replace("{1}", noImg.ToString("D5")); //add imgNumber to Id
            return builderId.ToString();
        }

        private static string GetHeaderMetaFile()
        {
            StringBuilder sbHeader = new StringBuilder();
            sbHeader.Append("ID | Creation Date | Image route");
            return sbHeader.ToString();
        }

        public static DateTime GetDateCreatedFile(string path)
        {
            return File.GetCreationTime(path);
        }

        public static string[] GetImagesFromDir(string path)
        {
            string[] patterns = new[] { "*.jpg", "*.jpeg", "*.jpe", "*.jif", "*.jfif", "*.jfi", "*.webp", "*.gif", "*.png", "*.apng", "*.bmp", "*.dib", "*.tiff", "*.tif", "*.svg", "*.svgz", "*.ico", "*.xbm" };
            string[] images = CustomDirectoryTools.GetFiles(path, patterns, SearchOption.AllDirectories);
            return images;
        }
    }

    public static class CustomDirectoryTools
    {
        public static string[] GetFiles(string path, string[] patterns = null, SearchOption options = SearchOption.TopDirectoryOnly)
        {
            if (patterns == null || patterns.Length == 0)
                return Directory.GetFiles(path, "*", options);
            if (patterns.Length == 1)
                return Directory.GetFiles(path, patterns[0], options);
            return patterns.SelectMany(pattern => Directory.GetFiles(path, pattern, options)).Distinct().ToArray();
        }
    }
}
