using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// CraftingRecipe Class 
/// ScriptableObject to create Recipes in the Unity-Editor
/// </summary>
public class CraftingRecipe : ScriptableObject
{
    /// <summary>
    /// required Items in correct order
    /// </summary>
    public List<Item> items;

    /// <summary>
    /// Item count (Same order as items)
    /// </summary>
    public List<int> anzahl;

    /// <summary>
    /// required CraftingStation
    /// </summary>
    public CraftingStation craftingStation;

}
