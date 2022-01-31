using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Crafting station Class 
/// </summary>
[Serializable]
public class CraftingStation 
{
    /// <summary>
    /// Slot Size 
    /// </summary>
    [SerializeField]
    private byte slotwidth;
    [SerializeField]
    private byte slotheight;
    /// <summary>
    /// Block reference 
    /// </summary>
    [SerializeField]
    private byte craftingStationBlock;
    /// <summary>
    /// Interface background Sprite [TODO : Dynamic instantiating of the Crafting if]
    /// </summary>
    [SerializeField]
    private Sprite craftingInterfaceSprite;

    public byte Slotwidth { get => slotwidth; set => slotwidth = value; }
    public byte Slotheight { get => slotheight; set => slotheight = value; }
    public byte CraftingStationBlock { get => craftingStationBlock; set => craftingStationBlock = value; }
    public Sprite CraftingInterfaceSprite { get => craftingInterfaceSprite; set => craftingInterfaceSprite = value; }
}
