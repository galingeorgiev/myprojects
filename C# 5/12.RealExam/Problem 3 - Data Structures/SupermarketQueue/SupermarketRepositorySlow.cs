using System;
using System.Collections.Generic;
using System.Linq;

public class SupermarketRepositorySlow : ISupermarketRepository
{
    List<string> repository = new List<string>();

    public void Append(string name)
    {
        this.repository.Add(name);
    }

    public void Insert(int position, string name)
    {
        this.repository.Insert(position, name);
    }

    public int Find(string name)
    {
        int occurences = 
            this.repository.Where(item => (item == name)).Count(); 
        return occurences;
    }

    public IList<string> Serve(int count)
    {
        var servedNames = this.repository.GetRange(0, count);
        this.repository.RemoveRange(0, count);
        return servedNames;
    }
}
