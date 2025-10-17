using UnityEngine;
using UnityEngine.Rendering;

public enum item
{ 

}
public class Items : MonoBehaviour
{
    public GameObject[] itemName;
    
    public int dropItemIndex(GameObject item)
    {
        for (int itemIndex = 0; itemIndex < itemName.Length; itemIndex++)
        {
            if (itemName[itemIndex] == item)
            {
                return itemIndex;
            }
        }    
             return -1;  
    }




    private void PickUp()
    {
    
    }
    private void DropItem()
    {

    }
} 
