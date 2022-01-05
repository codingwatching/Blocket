using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingInterface : MonoBehaviour
{
    #region settings
    public int rows;
    public int columns;
    public float hX;
    public float hY;
    public float OffsetX;
    public float OffsetY;
    #endregion

    public GameObject slotprefab;


    void Awake()
    {
        for(int i = 0; i < rows; i++)
        {
            GameObject currentrow = new GameObject("Row "+i);
            currentrow.transform.parent = transform;
            currentrow.transform.position = new Vector3(transform.position.x- OffsetX, transform.position.y + OffsetY - hY*i,-1f);
            for (int j = 0; j < columns; j++)
            {
                GameObject currentcolumn = GameObject.Instantiate(slotprefab, transform);
                currentcolumn.transform.parent = currentrow.transform;
                currentcolumn.transform.position = new Vector3(currentrow.transform.position.x+ hX * j, currentrow.transform.position.y , -1f);
            }
        }
    }
}
