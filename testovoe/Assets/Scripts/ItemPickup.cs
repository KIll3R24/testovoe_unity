using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Transform holdPosition;
    private GameObject heldItem;
    private Rigidbody itemRb;
    public GameObject dropButton;
    void Start()
    {
        dropButton.SetActive(false);
    }
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                if (Physics.Raycast(ray, out RaycastHit hit, 10f))
                {
                    if (hit.collider.CompareTag("Pickup") && heldItem == null)
                    {
                        PickupItem(hit.collider.gameObject);
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            DropItem();
        }
    }

    void PickupItem(GameObject item)
    {
        heldItem = item;
        itemRb = item.GetComponent<Rigidbody>();
        itemRb.isKinematic = true;
        item.transform.SetParent(holdPosition);
        item.transform.localPosition = Vector3.zero;
        item.transform.localRotation = Quaternion.identity;

        dropButton.SetActive(true);
    }

    public void DropItem()
    {
        Debug.Log("It works");

        if (heldItem != null)
        {
            Debug.Log("dropped");

            itemRb.isKinematic = false;
            heldItem.transform.SetParent(null);
            itemRb.AddForce(Camera.main.transform.forward * 5f, ForceMode.Impulse);

            heldItem = null;
            dropButton.SetActive(false);
        }
        else
        {
            Debug.Log("no item");
        }
    }

}