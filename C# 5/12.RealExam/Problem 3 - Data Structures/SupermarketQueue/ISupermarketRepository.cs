using System.Collections.Generic;

public interface ISupermarketRepository
{
    void Append(string name);
    void Insert(int position, string name);
    int Find(string name);
    IList<string> Serve(int count);
}
