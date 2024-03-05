using System;
using UnityEngine.Events;

[Serializable]
public class FloatEvent : UnityEvent<float>
{
}

[Serializable]
public class IntEvent : UnityEvent<int>
{
}

[Serializable]
public class BooleanEvent : UnityEvent<bool>
{
}
