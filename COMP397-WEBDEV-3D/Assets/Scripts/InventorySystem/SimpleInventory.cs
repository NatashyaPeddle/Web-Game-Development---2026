using JetBrains.Annotations;
using static UnityEditor.Progress;

public class SimpleInventory : PersistentSingleton<SimpleInventory>
{
    public int currency = 0;
    public int wood = 0;
    public int metal = 0;
    public int meals = 0;
    public bool hasSword = false;
    public bool hasSheild = false;
    public bool hasHelment = false;
}

public class ArrayInventory : PersistentSingleton<ArrayInventory>
{
    public Item[] backpack = new Item[8];
    public Item[] homeChest = new Item[64];
}

[System.Serializable]
public class Item 
{
    public bool isStackable = false; ///set to true if you want to stack the same item on the same location

}
