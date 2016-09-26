using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWriter
{
    public class Document
    {
        private string _fileName;

        public string Title { get; set; }
        public string Content { get; set; }

        public Document(string fileName)
        {
            _fileName = fileName;

            if (File.Exists(_fileName))
                Content = File.ReadAllText(_fileName);
            else
                Content = "";

            Title = Path.GetFileNameWithoutExtension(_fileName);
        }

        public void Save()
        {
            if (Path.GetFileNameWithoutExtension(_fileName) != Title)
            {
                File.Delete(_fileName);
                _fileName = _fileName.Replace(Path.GetFileNameWithoutExtension(_fileName), Title);
            }

            File.WriteAllText(_fileName, Content);
        }

        public int CalculateWordCount()
        {
            return Content.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Count();
        }
    }
}
