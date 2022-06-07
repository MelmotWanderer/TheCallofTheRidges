using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Zenject;
public class ItemCell : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    [SerializeField] private Transform _positionImage;

    public Item _item;
    public Image _image;
    private ContainerUI _inventoryUI;
    private Vector3 oldPosition;


    private void Start()
    {
        _image.raycastTarget = false;
    }

    

    public void OnBeginDrag(PointerEventData eventData)
    {
       
        oldPosition = _image.transform.position;
       

    }
    public void OnDrag(PointerEventData eventData)
    {

        _image.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, oldPosition.z);

    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.pointerDrag.GetComponent<ItemCell>() && eventData.pointerDrag.GetComponent<ItemCell>()._item != null)
        {
            if (eventData.pointerEnter != null)
            {
              
                if (eventData.pointerEnter.GetComponent<ItemCell>())
                {
                    if (eventData.pointerEnter.GetComponent<ItemCell>()._item != null)
                    {

                        _inventoryUI.ReplaceItems(eventData.pointerDrag.GetComponent<ItemCell>(), eventData.pointerEnter.GetComponent<ItemCell>()); 
                        
                    }
                    else
                    {
                        _inventoryUI.InsertItemInEmptyCell(eventData.pointerEnter.GetComponent<ItemCell>(), eventData.pointerDrag.GetComponent<ItemCell>());
                        

                    }
                }
                if (eventData.pointerEnter.GetComponent<Image>() && eventData.pointerEnter.GetComponent<Image>() == _inventoryUI.GetDropZone())
                {
                    _inventoryUI.DropItem(eventData.pointerDrag.GetComponent<ItemCell>());
                   
                }
            }
            else
            {
                _image.transform.position = oldPosition;
            }

        }

     
      

    }
    public void SetUI(ContainerUI containerUI)
    {
        _inventoryUI = containerUI;
    }
    public ContainerUI GetUI()
    {
        return _inventoryUI;
    }
    public void SetImage()
    {
        if(_item != null)
        {
            _image.sprite = _item.Data.Image;
            _image.transform.position = _positionImage.position;
            _image.gameObject.SetActive(true);
           
        }
        else
        {
            _image.sprite = null;
            _image.gameObject.SetActive(false);
        }
       
    }
 
    public void Clear()
    {
        _item = null;
        SetImage();
    }

}
