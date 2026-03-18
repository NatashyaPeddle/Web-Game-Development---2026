using System.Collections;
using Unity.VisualScripting;

public interface ISerializer
{
    
    string Serialize<T>(T obj); ///this will recieve the obj and serialize it

    T Deserialize<T>(string json);

}
