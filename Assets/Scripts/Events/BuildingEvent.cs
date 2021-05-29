using System;
using Buildings;
using UnityEngine.Events;

namespace Events
{
    [Serializable]
    public class BuildingEvent : UnityEvent<BaseBuilding> { }
}