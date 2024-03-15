using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory:MonoBehaviour {
    [Header("UI")]
    public GameObject inventory;
    public List<Slot> InventorySlots = new List<Slot>();
    public Image crosshair;
    public TMP_Text itemHoverText;

    [Header("Raycast")]
    public float raycastDistance = 5f;
    public LayerMask itemLayer;

    public void Start()
    {
        toggleInventory(false);

        foreach (Slot uiSlot in InventorySlots) {
            uiSlot.inistialisSlot();
        }
    }

    public void Update()
    {
        itemRaycast(Input.GetMouseButtonDown(0));

        if (Input.GetKeyDown(KeyCode.E))
            toggleInventory(!inventory.activeInHierarchy);
    }

    public void itemRaycast(bool hasClicked = false)
    {
        itemHoverText.text = "";
        Ray ray = Camera.main.ScreenPointToRay(crosshair.transform.position);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, raycastDistance, itemLayer))
        {
            if(hit.collider != null)
            {
                if (hasClicked)
                {
                    Item newItem = hit.collider.GetComponent<Item>();
                    if (newItem)
                    {
                        addItemToInventory(newItem);
                    }
                }
                else
                {
                    Item newItem = hit.collider.GetComponent<Item>();
                    if (newItem)
                    {
                        itemHoverText.text = newItem.name;
                    }
                }

            }
        }
    }

    private void addItemToInventory(Item itemToAdd)
    {
        int leftoverQuantity = itemToAdd.currentQuantity;
        Slot openSlot = null;
        for(int i = 0; i < InventorySlots.Count; i++)
        {
            Item heldItem = InventorySlots[i].getItem();

            if (heldItem != null && itemToAdd.name == heldItem.name)
            {
                int freeSpaceInSlot = heldItem.maxquantity - heldItem.currentQuantity;

                if (freeSpaceInSlot >= leftoverQuantity)
                {
                    heldItem.currentQuantity += leftoverQuantity;
                    Destroy(itemToAdd.gameObject);
                    return;
                }
                else
                {
                    heldItem.currentQuantity = heldItem.maxquantity;
                    leftoverQuantity -= freeSpaceInSlot;
                }
            }
            else if(heldItem == null)
            {
                if(!openSlot)
                openSlot = InventorySlots[i];
            }
        }
        if (leftoverQuantity > 0 && openSlot)
        {
            openSlot.setItem(itemToAdd);
            itemToAdd.currentQuantity = leftoverQuantity;
            itemToAdd.gameObject.SetActive(false);
        }
        else
        {
            itemToAdd.currentQuantity = leftoverQuantity;
        }
    }

    private void toggleInventory(bool enable)
    {
        inventory.SetActive(enable);

        Cursor.lockState = enable ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = enable;

        

    }
}
