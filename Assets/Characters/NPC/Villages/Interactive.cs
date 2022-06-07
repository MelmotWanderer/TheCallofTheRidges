using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactive : MonoBehaviour
{
    public string Name;

    public abstract void Interact();
    public virtual void UnInteract() {



    }
}
