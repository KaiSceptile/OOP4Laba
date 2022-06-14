using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;


namespace WinFormsApp1
{
    public class Deserialization
    {
        Dictionary<string, int> NumberOfAttributes = new Dictionary<string, int>()
        {
            { "Magazine", 6 },
            { "Non_Fiction", 7 },
            { "SchoolBook", 8 },
            { "Novel", 7 },
            { "Adventure", 7 },
            { "Detective", 7 }

        };
        public string FileName;
        private Deserialization(string fileName)
        {
            this.FileName = fileName;
        }
        private static Deserialization deserialization;
        public static Deserialization GetDeserialization(string fileName)
        {
            if (deserialization == null)
            {
                deserialization = new Deserialization(fileName);
            }
            return deserialization;
        }

        private PrintedEdition GetPrintedEdition(string type, StreamReader reader)
        {
            int counter = 0, result;
            Type ourtype = typeof(PrintedEdition); 
            IEnumerable<Type> list = Assembly.GetAssembly(ourtype).GetTypes().Where(type => type.IsSubclassOf(ourtype));              
            foreach (Type itm in list)
            {
                if (itm.Name == type)
                {
                    PrintedEdition instance = (PrintedEdition)Activator.CreateInstance(itm);
                    string line, name = "", val = "";
                    int i;
                    bool done = false;
                    while (!reader.EndOfStream && !done)
                    {
                        line = reader.ReadLine();
                        if (line == "end")
                        {
                            done = true;
                            break;
                        }
                        i = 0;
                        name = "";
                        while (line[i] != ' ')
                        {
                            name = name + line[i];
                            i++;
                        }
                        i++;
                        val = "";
                        while (i < line.Length)
                        {
                            val = val + line[i];
                            i++;
                        }
                        FieldInfo[] fieldInfo = instance.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static
                        | BindingFlags.NonPublic);
                        foreach (FieldInfo field in fieldInfo)
                        {
                            if (field.Name == name && val!="")
                            {
                                try
                                {
                                    counter++;
                                    field.SetValue(instance, val);
                                }
                                catch{
                                    if (int.TryParse(val, out result)==false)
                                        return null;
                                    else field.SetValue(instance, result);                                  
                                   
                                }
                               
                            }                            
                        }
                    }
                    if (counter == NumberOfAttributes[type])
                        return instance as PrintedEdition;
                    else return null;
                }
            }            
            return null;
        }

        public List<PrintedEdition> Deserialize()
        {
            List<PrintedEdition> list = new List<PrintedEdition>();
            string s, type = "";
            int len;
            FileStream fs = new FileStream(this.FileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(fs);
            while (!reader.EndOfStream)
            {
                s = reader.ReadLine();
                
                if (s.Contains(':'))
                {
                    type = "";
                    len = s.Length;
                    for (int i = s.IndexOf(':') + 1; i < len; i++)
                    {
                        type = type + s[i];
                    }
                }
                list.Add(GetPrintedEdition(type, reader));
                if (list[list.Count - 1] == null)
                {
                    MessageBox.Show("Inavlid data");
                    return null;
                }
            }
            fs.Close();
            reader.Close();
            return list;
        }
    }
}
