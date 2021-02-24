using System;
using System.Collections.Generic;
using System.Text;

namespace OOD
{
    interface IFile
    {
        string Extension { get; set; }
        float getSize();
        string Name { get; set; }

        List<IFile> get();
        bool IsDirectory();
    }

    class File: IFile
    {
        public File(string name, string extension, float size)
        {
            Name = name;
            Extension = extension;
            Size = size;
        }
        public string Name { get; set; }
        public string Extension { get; set; }
        public float Size { get; set; }
        public float getSize()
        {
            return Size;
        }

        public bool IsDirectory()
        {
            return false;
        }
        public List<IFile> get()
        {
            return new List<IFile>() { this };
        }
    }

    class Folder: IFile
    {
        List<IFile> files;
        private string extension;
        public Folder(string name)
        {
            Name = name;
            extension = "folder";
            files = new List<IFile>();
        }
        public string Extension { get => extension; set => extension = "folder"; }
        public string Name { get; set; }

        public float getSize()
        {
            float size = 0;
            foreach (var file in files)
            {
                size += file.getSize();
            }
            return size;
        }

        public bool IsDirectory()
        {
            return true;
        }

        public List<IFile> get()
        {
            return files;
        }
        
        public void addFile(IFile f)
        {
            files.Add(f);
        }
    }


    interface IRule
    {
        bool IsTheFile(IFile file, SearchSpec spec);
    }

    class SearchSpec
    {
        public string extension { get; set; }
        public string name { get; set; }
        public float minSize { get; set; }
        public float maxSize { get; set; }
    }

    
    class RuleForSearch: IRule
    {
        public bool IsTheFile(IFile file, SearchSpec spec)
        {
            return IsTheSize(file, spec) && nameMatch(file, spec) && extensionMatch(file, spec);
        }

        private bool IsTheSize(IFile file, SearchSpec spec)
        {
            return spec.minSize <= file.getSize() && file.getSize() <= spec.maxSize;
        }

        private bool nameMatch(IFile file, SearchSpec spec)
        {
            return file.Name.Contains(file.Name);
        }
            
        private bool extensionMatch(IFile file, SearchSpec spec)
        {
            return file.Extension == spec.extension;
        }
    }
    

    class UnixFind
    {
        private IFile currentNode;
        public IRule rule { get; set; }

        public void CD(IFile node)
        {
            currentNode = node;
        }

        public List<IFile> Search(SearchSpec spec)
        {
            var result = new List<IFile>();
            Queue<IFile> filesQueue = new Queue<IFile>() ;
            filesQueue.Enqueue(currentNode);
            while (filesQueue.Count != 0)
            {
                var f = filesQueue.Dequeue();
                if (f.IsDirectory())
                {
                    foreach(var subF in f.get())
                    filesQueue.Enqueue(subF);
                }
                else
                {
                    if (rule.IsTheFile(f, spec))
                    {
                        result.Add(f);
                    }
                }
            }
            return result;

        }
    }
}
