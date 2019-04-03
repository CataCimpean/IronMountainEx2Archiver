using System.Data;

namespace IronMountainEx2Archiver.Controller
{
    public class DataGridViewController
    {

        /// <summary>
        /// Used only for view XML loaded by user in a GridView
        /// </summary>
        public static void FillGridViewWithDataLoaded(Form1 form1)
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(form1.xmlPath);
            form1.GetGridViewStructureXMLLoaded().DataSource = dataSet.Tables[0];
        }
    }
}
