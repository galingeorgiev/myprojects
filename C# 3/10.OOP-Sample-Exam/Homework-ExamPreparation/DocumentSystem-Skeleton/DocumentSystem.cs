using System;
using System.Text;
using System.Collections.Generic;
using DocumentSystem;

public class DocumentSystems
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