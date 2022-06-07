using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{



    public virtual void StartState()
    {

    }
   

   public abstract void Run();

   public virtual void Stop()
    {

    }
    
    
}
