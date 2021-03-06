﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public Camera mainCamera;

    private bool targettingAnItem;

    private float distanceToItem;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 rayStartingLocation = mainCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));

            RaycastHit rayHit;
            Debug.Log("thro");

            if (Physics.Raycast(rayStartingLocation, mainCamera.transform.forward, out rayHit))
            {
                if (rayHit.transform.tag == "item")
                {
                    targettingAnItem = true;
                    distanceToItem = Vector3.Distance(this.gameObject.transform.position, rayHit.transform.position);

                    //FINISH LATER
                    ItemHandler temporaryItem = rayHit.transform.gameObject.GetComponent<ItemHandler>();

                    if (targettingAnItem == true && distanceToItem <= 6f)
                    {
                        if (Input.GetMouseButton(1))
                        {
                            temporaryItem.ItemBehavior();
                            Debug.Log("working");

                        }
                    }
                }

                else
                {
                    targettingAnItem = false;
                }
            }
        }
    }
}
