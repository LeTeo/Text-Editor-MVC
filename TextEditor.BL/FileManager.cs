using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextEditorMVC
{
    public interface IFileManager
    {
         string GetContent(string filepath);
         string GetContent(string filepath, Encoding encoding);
         void SaveContent(string content, string filepath);
         void SaveContent(string content, string filepath, Encoding encoding);
         bool IsExist(string filepath);
         int GetSymbolCount(string content);
    }
    public class FileManager : IFileManager
    {
        private readonly Encoding _defaultEncoding = Encoding.GetEncoding(1251);

        public string GetContent(string filepath) 
        {
            return GetContent(filepath, _defaultEncoding);
        }

        public string GetContent(string filepath, Encoding encoding)
        {
            return System.IO.File.ReadAllText(filepath, encoding);
        }

        public void SaveContent(string content, string filepath)
        {
            SaveContent(content, filepath, _defaultEncoding);
        }

        public void SaveContent(string content, string filepath, Encoding encoding)
        {
            System.IO.File.WriteAllText(filepath, content, encoding);
        }

        public int GetSymbolCount(string content)
        {
            return content.Length;
        }


        public bool IsExist(string filepath)
        {
            return System.IO.File.Exists(filepath);
        }
    }
}
