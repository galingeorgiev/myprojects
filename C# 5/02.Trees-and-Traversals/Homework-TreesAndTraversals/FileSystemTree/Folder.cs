namespace FileSystemTree
{
    using System.Collections.Generic;

    public class Folder
    {
        private string name;
        private HashSet<File> files = new HashSet<File>();
        private HashSet<Folder> childFolders = new HashSet<Folder>();
        private bool hasParent = false;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public HashSet<File> Files
        {
            get { return this.files; }
            set { this.files = value; }
        }

        public HashSet<Folder> ChildFolders
        {
            get { return this.childFolders; }
            set { this.childFolders = value; }
        }

        public bool HasParent
        {
            get { return this.hasParent = false; }
            set { this.hasParent = value; }
        }

        public void AddSubFolder(Folder folder)
        {
            folder.hasParent = true;
            this.childFolders.Add(folder);
        }
    }
}
