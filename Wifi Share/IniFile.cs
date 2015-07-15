using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Wifi_Share
{
    public class IniFile
    {
        static string filename = "setting.ini";
        public static void Save(string name, string pwd)
        {
            FileStream fs = new FileStream(filename, FileMode.OpenOrCreate,FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            try
            {
                string text = name + "***" + pwd;
                text = EncryptDecryptDES.EncryptString(text, "lxzh1234");
                sw.Write(text);
            }
            catch (Exception ex)
            {
            }
            finally
            {
                sw.Close();
                fs.Close();
            }
        }

        public static string[] GetInfo()
        {
            string[] infos = null;
            if (File.Exists(filename))
            {
                FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);
                try
                {
                    string text = sr.ReadToEnd();
                    if(!string.IsNullOrEmpty(text))
                    {
                        text=EncryptDecryptDES.DecryptString(text,"lxzh1234");
                        if (text.Contains("***"))
                        {
                            infos = text.Split(new string[] { "***" }, StringSplitOptions.None);
                            if (infos.Length == 2)
                            {
                                return infos;
                            }
                            else
                            {
                                return null;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    sr.Close();
                    fs.Close();
                }
            }
            return infos;
        }
    }
}
