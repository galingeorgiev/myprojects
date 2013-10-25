using System;
using System.Collections.Generic;

public class SupermarketRepositoryMix : ISupermarketRepository
{
    List<string> repository = new List<string>();
    Dictionary<string, int> names = new Dictionary<string, int>();

    public void Append(string name)
    {
        this.repository.Add(name);
        AddNameToDictionary(name);
    }

    public void Insert(int position, string name)
    {
        this.repository.Insert(position, name);
        AddNameToDictionary(name);
    }

    public int Find(string name)
    {
        int occurences;
        this.names.TryGetValue(name, out occurences);
        return occurences;
    }

    public IList<string> Serve(int count)
    {
        var servedNames = this.repository.GetRange(0, count);
        this.repository.RemoveRange(0, count);
        foreach (var name in servedNames)
        {
            this.names.Remove(name);
        }
        return servedNames;
    }

    private void AddNameToDictionary(string name)
    {
        int count;
        if (this.names.TryGetValue(name, out count))
        {
            count++;
        }
        else
        {
            count = 1;
        }
        this.names[name] = count;
    }
}
