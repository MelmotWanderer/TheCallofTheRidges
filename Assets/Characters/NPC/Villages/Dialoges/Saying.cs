using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[System.Serializable]
public struct Saying 
{
    [Multiline] public string Text;
    public AnswerPlayer[] Answers;
    public bool SwitchDialogue;
   // public UnityEvent Action;


    
    
}
