﻿using System;
using UnityEngine;
using UnityEngine.Events;

namespace Events
{
    [Serializable]
    public class KeyCodeEvent : UnityEvent<KeyCode> { }
}