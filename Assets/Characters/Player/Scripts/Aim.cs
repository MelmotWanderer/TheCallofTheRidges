using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{

   
    private void OnEnable()
    {
        Cursor.visible = false;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = Input.mousePosition;  
    }
    private void OnDisable()
    {
        Cursor.visible = true;
    }
}
