using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

using UnityEngine;

/// <summary>
/// Item Class<br></br>
/// </summary>

[Serializable]
public abstract class Item{

    #region Vars
    /// <summary>
    /// Item Name
    /// </summary>
    public string name;
	/// <summary>
	/// Item Id
	/// </summary>
	public byte id;
	/// <summary>
	/// Item description
	/// </summary>
	public string description;
	/// <summary>
	/// Type of the item (determines behiour at hand)
	/// </summary>
	public ItemType itemType;
	/// <summary>
	/// Item Sprite
	/// </summary>
	public Sprite itemImage;
	/// <summary>
	/// Item Crafting Recipe 
	/// <!--If null => not craftable-->
	/// </summary>
	public CraftingRecipe recipe;
    #endregion

    /// <summary>How much of the Item can be hold.</summary>
    public enum ItemType {
		SINGLE, STACKABLE
	}

	/// <summary>
	/// Euqals overriden
	/// </summary>
	/// <param name="obj">Other Object...</param>
	/// <returns><see langword="true"/> if the <see cref="Item.id"/> is the same</returns>
	public override bool Equals(object obj) {
		if(obj is Item)
			if(this.id == (obj as Item).id)
				return true;
		return false;
	}

	public override int GetHashCode() {
		return base.GetHashCode();
	}
}

#region ItemVariants
[Serializable]
public class BlockItem : Item {
	public byte blockId;
	public BlockData data;
}

[Serializable]
public class ToolItem : Item {
	public ushort durability, damage;
	public ToolType toolType;

	public enum ToolType {
		SWORD, SHOVEL, AXE, BOW, PICKAXE
	}
}

[Serializable]
public class EquipableItem : Item {
	//TODO:
	
}

[Serializable]
public class UseAbleItem : Item{

}
#endregion