using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DestructibleItemType
{
    Tree,
    Box,
    Stone
}

public class DestructibleItemScriptableObject : ScriptableObject
{
    public float healthPoints;
    public DestructibleItemType destructibleItemType;
}
