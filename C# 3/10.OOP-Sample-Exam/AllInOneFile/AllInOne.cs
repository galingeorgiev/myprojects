using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DocumentSystem
{
    static void Main()
    {
        IList<string> allCommands = ReadAllCommands();
        ExecuteCommands(allCommands);
    }

    private static IList<string> ReadAllCommands()
    {
        List<string> commands = new List<string>();
        while (true)
        {
            string commandLine = Console.ReadLine();
            if (commandLine == "")
            {
                // End of commands
                break;
            }
            commands.Add(commandLine);
        }
        return commands;
    }

    private static void ExecuteCommands(IList<string> commands)
    {
        foreach (var commandLine in commands)
        {
            int paramsStartIndex = commandLine.IndexOf("[");
            string cmd = commandLine.Substring(0, paramsStartIndex);
            int paramsEndIndex = commandLine.IndexOf("]");
            string parameters = commandLine.Substring(
                paramsStartIndex + 1, paramsEndIndex - paramsStartIndex - 1);
            ExecuteCommand(cmd, parameters);
        }
    }

    private static void ExecuteCommand(string cmd, string parameters)
    {
        string[] cmdAttributes = parameters.Split(
            new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        if (cmd == "AddTextDocument")
        {
            AddTextDocument(cmdAttributes);
        }
        else if (cmd == "AddPDFDocument")
        {
            AddPdfDocument(cmdAttributes);
        }
        else if (cmd == "AddWordDocument")
        {
            AddWordDocument(cmdAttributes);
        }
        else if (cmd == "AddExcelDocument")
        {
            AddExcelDocument(cmdAttributes);
        }
        else if (cmd == "AddAudioDocument")
        {
            AddAudioDocument(cmdAttributes);
        }
        else if (cmd == "AddVideoDocument")
        {
            AddVideoDocument(cmdAttributes);
        }
        else if (cmd == "ListDocuments")
        {
            ListDocuments();
        }
        else if (cmd == "EncryptDocument")
        {
            EncryptDocument(parameters);
        }
        else if (cmd == "DecryptDocument")
        {
            DecryptDocument(parameters);
        }
        else if (cmd == "EncryptAllDocuments")
        {
            EncryptAllDocuments();
        }
        else if (cmd == "ChangeContent")
        {
            ChangeContent(cmdAttributes[0], cmdAttributes[1]);
        }
        else
        {
            throw new InvalidOperationException("Invalid command: " + cmd);
        }
    }

    #region AddDocument

    private static void AddTextDocument(string[] attributes)
    {
        AddDocument(attributes, new TextDocument());
    }

    private static void AddPdfDocument(string[] attributes)
    {
        AddDocument(attributes, new PDFDocument());
    }

    private static void AddWordDocument(string[] attributes)
    {
        AddDocument(attributes, new WordDocument());
    }

    private static void AddExcelDocument(string[] attributes)
    {
        AddDocument(attributes, new ExcelDocument());
    }

    private static void AddAudioDocument(string[] attributes)
    {
        AddDocument(attributes, new AudioDocument());
    }

    private static void AddVideoDocument(string[] attributes)
    {
        AddDocument(attributes, new VideoDocument());
    }

    #endregion

    private static void ListDocuments()
    {
        if (listOfDocuments.Count > 0)
        {
            foreach (var doc in listOfDocuments)
            {
                Console.WriteLine(doc);
            }
        }
        else
        {
            Console.WriteLine("No documents found");
        }
    }

    private static void EncryptDocument(string name)
    {
        bool isFound = false;
        foreach (var doc in listOfDocuments)
        {
            if (doc.Name == name)
            {
                isFound = true;
                if (doc is IEncryptable)
                {
                    (doc as IEncryptable).Encrypt();
                    Console.WriteLine("Document encrypted: {0}", doc.Name);
                }
                else
                {
                    Console.WriteLine("Document does not support encryption: {0}", doc.Name);
                }
            }
        }
        if (!isFound)
        {
            Console.WriteLine("Document not found: {0}", name);
        }
    }

    private static void DecryptDocument(string name)
    {
        bool isFound = false;
        foreach (var doc in listOfDocuments)
        {
            if (doc.Name == name)
            {
                isFound = true;
                if (doc is IEncryptable)
                {
                    (doc as IEncryptable).Decrypt();
                    Console.WriteLine("Document decrypted: {0}", doc.Name);
                }
                else
                {
                    Console.WriteLine("Document does not support decryption: {0}", doc.Name);
                }
            }
        }
        if (!isFound)
        {
            Console.WriteLine("Document not found: {0}", name);
        }
    }

    private static void EncryptAllDocuments()
    {
        bool isFound = false;
        foreach (var doc in listOfDocuments)
        {
            if (doc is IEncryptable)
            {
                (doc as IEncryptable).Encrypt();
                isFound = true;
            }
        }
        if (!isFound)
        {
            Console.WriteLine("No encryptable documents found");
        }
        else
        {
            Console.WriteLine("All documents encrypted");
        }
    }

    private static void ChangeContent(string name, string content)
    {
        bool isFoundName = false;
        foreach (var doc in listOfDocuments)
        {
            if (doc.Name == name)
            {
                isFoundName = true;
                if (doc is IEditable)
                {
                    (doc as IEditable).ChangeContent(content);
                    Console.WriteLine("Document content changed: {0}", doc.Name);
                }
                else
                {
                    Console.WriteLine("Document is not editable: {0}", doc.Name);
                }
            }
        }

        if (!isFoundName)
        {
            Console.WriteLine("Document not found: {0}", name);
        }
    }

    #region MyMethods

    private static IList<Document> listOfDocuments = new List<Document>();

    private static void AddDocument(string[] attributes, IDocument docType)
    {
        for (int i = 0; i < attributes.Length; i++)
        {
            string[] nameAndProperty = attributes[i].Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
            string property = nameAndProperty[0].ToLower().Trim();
            string value = nameAndProperty[1].ToLower().Trim();

            docType.LoadProperty(property, value);
        }
        StringBuilder result = new StringBuilder();
        if (docType.Name != null)
        {
            result.Append("Document added: ");
            result.Append(docType.Name);
        }
        else
        {
            result.Append("Document has no name");
        }
        Console.WriteLine(result);
        listOfDocuments.Add((docType as Document));
    }

    #endregion
}


public class AudioDocument : MultimediaDocuments
{
    private double sampleRate;

    public double SampleRate
    {
        get { return sampleRate; }
        set { sampleRate = value; }
    }

    public override void LoadProperty(string key, string value)
    {
        if (key == "samplerate")
        {
            this.sampleRate = double.Parse(value);
        }
        else
        {
            base.LoadProperty(key, value);
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        foreach (var property in output)
        {
            this.LoadProperty(property.Key, property.Value.ToString());
        }
    }
}


public abstract class BinaryDocument : Document
{
    private ulong? size;

    public ulong? Size
    {
        get { return size; }
        protected set { size = value; }
    }

    public override void LoadProperty(string key, string value)
    {
        if (key == "size")
        {
            this.size = ulong.Parse(value);
        }
        else
        {
            base.LoadProperty(key, value);
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        foreach (var property in output)
        {
            this.LoadProperty(property.Key, property.Value.ToString());
        }
    }
}



public abstract class Document : IDocument
{
    private string name;
    protected string content;
    protected List<KeyValuePair<string, object>> properties = new List<KeyValuePair<string, object>>();

    public string Name
    {
        get { return this.name; }
        protected set { this.name = value; }
    }

    public string Content
    {
        get { return this.content; }
        protected set { this.content = value; }
    }

    public virtual void LoadProperty(string key, string value)
    {
        if (key == "name")
        {
            this.name = value;
        }
        else if (key == "content")
        {
            this.content = value;
        }

        if (key != null & value != null)
        {
            KeyValuePair<string, object> input = new KeyValuePair<string, object>(key, value);
            this.properties.Add(input);
        }
    }

    public virtual void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        foreach (var property in output)
        {
            this.LoadProperty(property.Key, property.Value.ToString());
        }
    }

    public override string ToString()
    {
        //List<KeyValuePair<string, object>> properties =
        //new List<KeyValuePair<string, object>>();
        //this.SaveAllProperties(properties);
        properties.Sort((a, b) => a.Key.CompareTo(b.Key));
        StringBuilder result = new StringBuilder();
        result.Append(this.GetType().Name);
        result.Append("[");
        bool first = true;
        foreach (var prop in properties)
        {
            if (prop.Value != null)
            {
                if (!first)
                {
                    result.Append(";");
                }
                result.AppendFormat("{0}={1}", prop.Key, prop.Value);
                first = false;
            }
        }
        result.Append("]");
        return result.ToString();
    }
}


public class ExcelDocument : OfficeDocument
{
    private int numberOfRows;
    private int numberOfCols;

    public int NumberOfCols
    {
        get { return numberOfCols; }
        set { numberOfCols = value; }
    }


    public int NumberOfRows
    {
        get { return numberOfRows; }
        set { numberOfRows = value; }
    }

    public override void LoadProperty(string key, string value)
    {
        if (key == "rows")
        {
            this.numberOfRows = int.Parse(value);
        }
        else if (key == "cols")
        {
            this.numberOfCols = int.Parse(value);
        }
        else
        {
            base.LoadProperty(key, value);
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        foreach (var property in output)
        {
            this.LoadProperty(property.Key, property.Value.ToString());
        }
    }
}


public abstract class MultimediaDocuments : BinaryDocument
{
    private int length;

    public int Length
    {
        get { return length; }
        protected set { length = value; }
    }

    public override void LoadProperty(string key, string value)
    {
        if (key == "length")
        {
            this.length = int.Parse(value);
        }
        else
        {
            base.LoadProperty(key, value);
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        foreach (var property in output)
        {
            this.LoadProperty(property.Key, property.Value.ToString());
        }
    }
}


public abstract class OfficeDocument : BinaryDocument, IEncryptable
{
    private string version;
    private bool isEncrypted = false;

    public string Version
    {
        get { return version; }
        set { version = value; }
    }

    public override void LoadProperty(string key, string value)
    {
        if (key == "framerate")
        {
            this.version = value;
        }
        else
        {
            base.LoadProperty(key, value);
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        foreach (var property in output)
        {
            this.LoadProperty(property.Key, property.Value.ToString());
        }
    }

    public bool IsEncrypted
    {
        get { return this.isEncrypted; }
    }

    public void Encrypt()
    {
        this.isEncrypted = true;
    }

    public void Decrypt()
    {
        this.isEncrypted = false;
    }

    //public override string ToString()
    //{
    //    StringBuilder result = new StringBuilder();
    //    if (this.isEncrypted)
    //    {
    //        result.Append("Document encrypted: ");
    //        result.Append(this.Name);
    //    }
    //    else
    //    {
    //        base.ToString();
    //    }
    //    return result.ToString();
    //}
}



public class PDFDocument : BinaryDocument, IEncryptable
{
    private int? numberOfPages;
    private bool isEncrypted = false;

    public int? NumberOfPages
    {
        get { return numberOfPages; }
        set { numberOfPages = value; }
    }

    public bool IsEncrypted
    {
        get { return this.isEncrypted; }
    }

    public void Encrypt()
    {
        this.isEncrypted = true;
    }

    public void Decrypt()
    {
        this.isEncrypted = false;
    }

    public override void LoadProperty(string key, string value)
    {
        if (key == "pages")
        {
            this.numberOfPages = int.Parse(value);
        }
        else
        {
            base.LoadProperty(key, value);
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        foreach (var property in output)
        {
            this.LoadProperty(property.Key, property.Value.ToString());
        }
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        if (this.isEncrypted)
        {
            result.Append("Document encrypted: ");
            result.Append(this.Name);
            return result.ToString();
        }
        else
        {
            return base.ToString();
        }
    }
}



public class TextDocument : Document, IEditable
{
    private string charSet;

    public string CharSet
    {
        get { return charSet; }
        set { charSet = value; }
    }

    public void ChangeContent(string newContent)
    {
        base.content = newContent;
    }

    public override void LoadProperty(string key, string value)
    {
        if (key == "charset")
        {
            this.charSet = value;
        }
        else
        {
            base.LoadProperty(key, value);
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        foreach (var property in output)
        {
            this.LoadProperty(property.Key, property.Value.ToString());
        }
    }
}



public class VideoDocument : MultimediaDocuments
{
    private double frameRate;

    public double FrameRate
    {
        get { return frameRate; }
        set { frameRate = value; }
    }

    public override void LoadProperty(string key, string value)
    {
        if (key == "framerate")
        {
            this.frameRate = double.Parse(value);
        }
        else
        {
            base.LoadProperty(key, value);
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        foreach (var property in output)
        {
            this.LoadProperty(property.Key, property.Value.ToString());
        }
    }
}


public class WordDocument : OfficeDocument, IEditable
{
    private ulong numberOfChars;

    public ulong NumberOfChars
    {
        get { return numberOfChars; }
        set { numberOfChars = value; }
    }

    public void ChangeContent(string newContent)
    {
        base.content = newContent;
    }

    public override void LoadProperty(string key, string value)
    {
        if (key == "chars")
        {
            this.numberOfChars = ulong.Parse(value);
        }
        else
        {
            base.LoadProperty(key, value);
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        foreach (var property in output)
        {
            this.LoadProperty(property.Key, property.Value.ToString());
        }
    }
}

public interface IDocument
{
    string Name { get; }
    string Content { get; }
    void LoadProperty(string key, string value);
    void SaveAllProperties(IList<KeyValuePair<string, object>> output);
    string ToString();
}

public interface IEditable
{
    void ChangeContent(string newContent);
}

public interface IEncryptable
{
    bool IsEncrypted { get; }
    void Encrypt();
    void Decrypt();
}
