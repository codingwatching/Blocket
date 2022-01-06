using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// TW: Used for MainMenu-Scene<br></br>
/// 
/// Handles the <see cref="Button"/>-Click-Events
/// 
/// </summary>
public class UIInventorySlot : MonoBehaviour
{
	#region Static Resources
	/// <summary><see cref="UIInventory"/> </summary>
	public UIInventory _uIInventory;
	/// <summary><see cref="Text"/></summary>
	public Text textDown;
	/// <summary><see cref="Button"/>-Button</summary>
	public Button button;
	/// <summary><see cref="Image"/>-Button</summary>
	public Image itemImage, backgroundImage;
	/// <summary>Image Sprites which are swapable</summary>
	public Sprite imgActive, imagInactive, defaultSprite;
	/// <summary>Checks Whether or not this Slot is just a copy</summary>
	public bool isHotBarSlot;
	/// <summary>InventorySlots parent => this Slot will be the copy for Hotbar <summary>
	public UIInventorySlot parent;
	#endregion

	/// <summary><see cref="Item"/></summary>
	private Item _item;

	private ushort _itemCount = 0;

	public Item Item { 
		get => _item;
		set {
			_item = value;
			ReloadSlot();
		}
	}

	public ushort ItemCount {
		get => _itemCount;
		set {
			_itemCount = value;
			ReloadSlot();
		}
	}

	/// <summary>Reloads the Itemslot<br></br><b>Be carfull when deleting!</b></summary>
	public void ReloadSlot() {
		itemImage.sprite = _item?.itemImage;
		itemImage.sprite ??= defaultSprite;
		//Hide counttext if item is Single type
		if(_item != null) {
			textDown.gameObject.SetActive(_item.itemType == Item.ItemType.STACKABLE);
			//Write itemCount into the texfield
			textDown.color = Color.white;
			//textDown.gameObject.transform.position.Set(textDown.gameObject.transform.position.x,textDown.gameObject.transform.position.y + 100, textDown.gameObject.transform.position.z);
			textDown.text = string.Empty+_itemCount;
		}
		itemImage.gameObject.SetActive(_item != null);
		textDown.gameObject.SetActive(_item != null);
	}

	private bool _active;
	public bool Active {
		get { return _active; }
		set {
			if(value) {
				_uIInventory.DescriptionText = _item?.description ?? string.Empty;
				_uIInventory.TitleText = _item?.name ?? string.Empty;
			}
			_active = value;
		}
	}

    public void Awake() {
		button.gameObject.AddComponent<SlotOptionsScript>();
		button.gameObject.GetComponent<SlotOptionsScript>().invSlot = this;
		if(_uIInventory!=null)
		button.gameObject.GetComponent<SlotOptionsScript>().SlotOptions = _uIInventory._slotOptions; 
		
	}

	public void OnMouseOver() {
		Debug.Log("ABC");
	}

    /// <summary>
    /// Asign <see cref="EventHandler"/> (Listeners) for Button-Presses Event
    /// </summary>
    public void Start() {
		_uIInventory = GlobalVariables.UIInventory;
	}
}
