using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TestFramework.OpenCart
{
    //class Reader
    //{
    //    public const int PATH_PREFIX = 6;
    //    public const string PATH_SEPARATOR = "\\";
    //    protected const string FOLDER_DATA = "Data";
    //    protected const string FOLDER_RESOURCES = "Resources";
    //    protected const string FOLDER_BIN = "bin";

    //    public string Filename { get; private set; }
    //    public string Path { get; protected set; }

    //    protected Reader(string filename)
    //    {
    //        Filename = filename;
    //        Path = System.IO.Path.GetDirectoryName(Assembly.GetAssembly(typeof(Reader)).CodeBase)
    //                .Substring(PATH_PREFIX);
    //        Path = Path.Remove(Path.IndexOf(FOLDER_BIN)) + PATH_SEPARATOR + FOLDER_DATA + PATH_SEPARATOR + FOLDER_RESOURCES + PATH_SEPARATOR + filename;
    //        //MessageBox.Show("Path.GetDirectoryName(Assembly.GetAssembly(typeof(AExternalReader)).CodeBase):\n"
    //        //    + System.IO.Path.GetDirectoryName(Assembly.GetAssembly(typeof(AExternalReader)).CodeBase),
    //        //    "Full PATH ", MessageBoxButtons.OK, MessageBoxIcon.Information);
    //    }

    //    public abstract IList<IList<string>> GetAllCells();

    //    public abstract IList<IList<string>> GetAllCells(string path);

    //    public abstract string GetConnection();
    //    private const char CSV_SPLIT_BY = ';';
    //    //public string Filename { get; private set; }
    //    //public string Path { get; private set; }

    //    public CSVReader(string filename) : base(filename)
    //    {
    //        //Filename = filename;
    //        //Path = System.IO.Path.GetDirectoryName(Assembly.GetAssembly(typeof(CSVReader)).CodeBase)
    //        //        .Substring(PATH_PREFIX);
    //        //Path = Path.Remove(Path.IndexOf(FOLDER_BIN)) + FOLDER_DATA + PATH_SEPARATOR + filename;
    //        //MessageBox.Show("Path.GetDirectoryName(Assembly.GetAssembly(typeof(CSVReader)).CodeBase): "
    //        //    + System.IO.Path.GetDirectoryName(Assembly.GetAssembly(typeof(CSVReader)).CodeBase),
    //        //    "Full PATH ", MessageBoxButtons.OK, MessageBoxIcon.Information);
    //    }

    //    public override IList<IList<string>> GetAllCells()
    //    {
    //        return GetAllCells(Path);
    //    }

    //    public override IList<IList<string>> GetAllCells(string path)
    //    {
    //        Path = path;
    //        IList<IList<string>> allCells = new List<IList<string>>();
    //        string row;
    //        //
    //        using (StreamReader streamReader = new StreamReader(path))
    //        {
    //            while ((row = streamReader.ReadLine()) != null)
    //            {
    //                allCells.Add(row.Split(CSV_SPLIT_BY).ToList());
    //            }
    //        }
    //        return allCells;
    //    }

    //    public override string GetConnection()
    //    {
    //        return Path;
    //    }
    //}
}
