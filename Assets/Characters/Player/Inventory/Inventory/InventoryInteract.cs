using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryInteract : MonoBehaviour
{


    private Camera cashedCamera;


    private void Start()
    {
        cashedCamera = Camera.main;
    }


    private void Update()
    {

        if (Physics.Raycast(cashedCamera.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
        {
            Debug.DrawRay(cashedCamera.ScreenPointToRay(Input.mousePosition).origin, cashedCamera.ScreenPointToRay(Input.mousePosition).direction, Color.green);
            if (hit.transform.GetComponent<ItemCell>())
            {
                Debug.Log('s');
            }

        }
    }


}
