using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingRecipe : ScriptableObject, ISerializationCallbackReceiver
{
    /// <summary>
    /// Crafting station entity
    /// </summary>
    private CraftingStation station;
    /// <summary>
    /// Crafting Recipe
    /// </summary>
    private byte[,] recipe;

    public byte[,] Recipe { get => recipe; set => recipe = value; }
    public CraftingStation Station { get => station; set => station = value; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="station"></param>
    public CraftingRecipe(CraftingStation station)
    {
        this.Station = station;
        Recipe = new byte[station.Slotwidth, station.Slotheight];
    }

    public void OnBeforeSerialize()
    {
        throw new System.NotImplementedException();
    }

    public void OnAfterDeserialize()
    {
        throw new System.NotImplementedException();
    }
}
