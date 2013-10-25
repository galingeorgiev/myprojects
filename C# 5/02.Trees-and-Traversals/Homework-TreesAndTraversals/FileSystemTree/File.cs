namespace FileSystemTree
{
    public class File
    {
        private string name;
        private long size;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        
        public long Size
        {
            get { return this.size; }
            set { this.size = value; }
        }
    }
}
