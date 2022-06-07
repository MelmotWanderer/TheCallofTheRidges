using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ContainerUI : UI
{
 


    [SerializeField] private List<ItemCell> _itemCells;
    [SerializeField] private Image _dropZone;
    private Storage _storage;

    protected override void Init()
    {
        foreach(ItemCell itemCell in _itemCells)
        {
            itemCell.SetUI(this);
        }
     
        Disable();
    }

    public void SetInventory(Storage storage)
    {
        _storage = storage;
        var items = _storage._items;
        if (items.Count > 0)
        {
            
            for (int i = 0; i != items.Count; i++)
            {


                if (items[i].index == -1)
                {

                    int index = FindFirstEmptyIndex();
                    items[i].index = index;
                
                    _itemCells[index]._item = items[i];
                    
                }


            }


        }

        for (int i = 0; i != _itemCells.Count; i++)
        {

            _itemCells[i].SetImage();

            
        }



    }

    public void ActiveRaycastImageItem(bool isActive)
    {

        foreach (ItemCell itemCell in _itemCells)
        {
            itemCell._image.raycastTarget = isActive;
        }

    }


   
    public List<ItemCell> GetItemCells()
    {
        return _itemCells;
    }
    public Image GetDropZone()
    {
        return _dropZone;
    }


    public void ReplaceItems(ItemCell item1, ItemCell item2)
    {
        ContainerUI storageUIitem1 = item1.GetUI();
        ContainerUI storageUIitem2 = item2.GetUI();
        if (item2.GetUI() != item1.GetUI())
        {
            storageUIitem1.GetStorage().RemoveItem(item1._item);
            storageUIitem2.GetStorage().RemoveItem(item2._item);
            storageUIitem1.GetStorage().AddItem(item2._item);
            storageUIitem2.GetStorage().AddItem(item1._item);


        }
       
        int index1 = storageUIitem1._itemCells.IndexOf(item1);
        int index2 = storageUIitem2._itemCells.IndexOf(item2);
        var itemReplaced1 = storageUIitem1._itemCells[index1]._item;
        var itemReplaced2 = storageUIitem2._itemCells[index2]._item;
        storageUIitem1._itemCells[index1]._item = itemReplaced2;
        storageUIitem2._itemCells[index2]._item = itemReplaced1;
        storageUIitem1._itemCells[index1].SetImage();
        storageUIitem2._itemCells[index2].SetImage();

        
    }


    public void InsertItemInEmptyCell(ItemCell emptyCell, ItemCell item)
    {
        ContainerUI storageUIEmptyCell = emptyCell.GetUI();

        int index = storageUIEmptyCell._itemCells.IndexOf(emptyCell);
        storageUIEmptyCell._itemCells[index]._item = item._item;
        storageUIEmptyCell._itemCells[index]._item.index = index;
        storageUIEmptyCell._itemCells[index].SetImage();

        if (emptyCell.GetUI() != this)
        {
            
            
            storageUIEmptyCell.GetStorage().AddItem(item._item);
            GetStorage().RemoveItem(item._item);




        }

        item.Clear();
    }

    public void DropItem(ItemCell discardedItem)
    {
        GetStorage().RemoveItem(discardedItem._item);
        discardedItem._item.Drop();
        discardedItem.Clear();
    }

    public Storage GetStorage()
    {
        return _storage;
    }
    private int FindFirstEmptyIndex()
    {
        for (int i = 0; i != _itemCells.Count; i++)
        {
            if (_itemCells[i]._item == null)
            {
                return i;
            }
        }
        return -1;
    }
}
