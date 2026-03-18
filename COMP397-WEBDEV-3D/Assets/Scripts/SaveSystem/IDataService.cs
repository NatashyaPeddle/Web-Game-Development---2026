using System.Collections.Generic;
//public class XmlSerializer: ISerializer
//{
//    public T Deserialize<T>(string json)
//    {
//        return XmlSerializer.FromJson
//    }
//}

public interface IDataService
{
    void Save(GameData data, bool overwrite = true);
    GameData Load(string name);
    void Delete(string name);
    IEnumerable<string> ListSaves();

}
