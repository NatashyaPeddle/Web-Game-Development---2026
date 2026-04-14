using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// this class will be responsible to hold all of the channels for the observer pattern
/// </summary>


public  class EventChannelManager : PersistentSingleton2<EventChannelManager>
{
    public VoidEventChannel voidEvent;
    public FloatEventChannel floatEvent;
    public GameDataEventChannel gameDataEvent;

}
