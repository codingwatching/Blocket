
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Handles all items in Game
/// </summary>
public class ItemAssets : MonoBehaviour
{
	public List<BlockItem> BlockItemsInGame = new List<BlockItem>();
	public List<ToolItem> ToolItemsInGame = new List<ToolItem>();
	public List<EquipableItem> EquipableItemsInGame = new List<EquipableItem>();
	public List<UseAbleItem> UseableItemsInGame = new List<UseAbleItem>();
	public List<Structure> Structures = new List<Structure>();
	public List<EnemySO> Enemies = new List<EnemySO>();
	/// <summary>
	/// Key => Block it belongs to
	/// </summary>
	[SerializeField]
	private List<CraftingRecipe> _recipes = new List<CraftingRecipe>();
	public Dictionary<int, CraftingRecipe> Recipes { get => ListToDict(); }
	public Dictionary<int, CraftingRecipe> ListToDict()
	{
		var list = _recipes;
		var dict = list.Select((s, i) => new { s, i }).ToDictionary(x => x.i, x => x.s);
		return dict;
	}
	/// <summary>
	/// List of all Crafting stations
	/// </summary>
	[SerializeField]
	public List<CraftingStationData> CraftingStationBlocks =new List<CraftingStationData>();


	private void Awake() => GlobalVariables.ItemAssets = this;

	/// <summary>
	/// Returns a Sprite from Item-ID
	/// </summary>
	/// <param name="itemId"></param>	
	/// <returns></returns>
	public Sprite GetSpriteFromItemID(uint itemId) {
		return GetItemFromItemID(itemId)?.itemImage;
	}

	public Item GetItemFromItemID(uint itemId) {
		foreach (Item item in BlockItemsInGame)
			if (item.id == itemId)
				return item;
		foreach (Item item in ToolItemsInGame)
			if (item.id == itemId)
				return item;
		foreach (Item item in EquipableItemsInGame)
			if (item.id == itemId)
				return item;
		foreach (Item item in UseableItemsInGame)
			if (item.id == itemId)
				return item;
		Debug.LogWarning($"Item not found: {itemId}");
		return null;
	}


	[Serializable]
	public class CraftingStationData
	{
		/// <summary>
		/// ID of the CS
		/// </summary>
		[SerializeField]
		private byte id;
		[SerializeField]
		private CraftingStation station;

		public byte Id { get => id; set => id = value; }
		public CraftingStation Station { get => station; set => station = value; }

		// override object.Equals
		public override bool Equals(object obj)
		{
			if (obj == null || GetType() != obj.GetType()) { return false; }
			CraftingStationData other = obj as CraftingStationData;
			if (Id == other.Id) { return true; }
			return false;
		}

		// override object.GetHashCode
		public override int GetHashCode()
		{
			// TODO: write your implementation of GetHashCode() here
			throw new NotImplementedException();
			return base.GetHashCode();
		}
	}
}
