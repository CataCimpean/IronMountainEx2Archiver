using Ionic.Zip;
using IronMountainEx2Archiver.Utils.Date;

namespace IronMountainEx2Archiver.Utils.Archive
{
    public class ArchiveUtil
    {

        public static void ZipDirectory(string dirOnDisk, string dirPathInArchive, string zipPath)
        {
            using (var zip = new Ionic.Zip.ZipFile())
            {
                zip.AddDirectory(dirOnDisk, dirPathInArchive);
                zip.Save(zipPath);
            }
        }

        public static void ZipDirectory(string dirOnDisk, string zipPath)
        {
            using (var zip = new Ionic.Zip.ZipFile())
            {
                zip.AddDirectory(dirOnDisk);
                zip.Save(zipPath);
            }
        }

        public static void UnzipFile(string zipSource, string pathToExtract)
        {
            using (ZipFile zip = ZipFile.Read(zipSource))
            {
                zip.ExtractAll(pathToExtract, ExtractExistingFileAction.InvokeExtractProgressEvent);
            }
        }

        public static void ZipData(string[] imagesPath, string metaDataPath, string destinationPath)
        {
            using (ZipFile zip = new ZipFile())
            {
                string today = DateUtil.GetToday();
                foreach(string imagePath in imagesPath)
                {
                    zip.AddFile(imagePath, today);
                }
                zip.AddFile(metaDataPath, @"");
                zip.Save(destinationPath);
            }
        }
    }
}
