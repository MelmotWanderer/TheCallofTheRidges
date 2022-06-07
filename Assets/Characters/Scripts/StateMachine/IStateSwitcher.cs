using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStateCharacterSwitcher
{

     public void SwitchMoveState<T>() where T : State;
     public void SwitchShootState<T>() where T : State;
}
