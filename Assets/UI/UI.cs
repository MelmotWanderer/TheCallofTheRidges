using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class UI : MonoBehaviour
{

    private Canvas _canvas;




    void Start()
    {
        _canvas = GetComponent<Canvas>();
        Init();
    }

    

    public void Disable()
    {
        gameObject.SetActive(false);
    }
    public void Enable()
    {
        gameObject.SetActive(true);
    }
    public void SetActive(bool isActive)
    {
        gameObject.SetActive(isActive);
    }
    protected virtual void Init()
    {

    }
 
    
}
