using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingSlot : MonoBehaviour
{
    [SerializeField]
    private Item item;
    public GameObject slot;

    public Item Item { get => item; 
        set{
            item = value;
            slot.GetComponent<SpriteRenderer>().sprite = item.itemImage;
        } }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
