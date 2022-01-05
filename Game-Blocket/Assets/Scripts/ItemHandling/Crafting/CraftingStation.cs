using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingStation : MonoBehaviour
{
    public GameObject craftingInterface;
    public GameObject cIf;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
                if(cIf != null)
                    cIf.SetActive(!cIf.activeSelf);
                else
                {
                    cIf = GameObject.Instantiate(craftingInterface, transform);
                    cIf.transform.position = new Vector3(transform.position.x - 1.5f, transform.position.y + 2, transform.position.z);
                }
            }
        }
    }
}
