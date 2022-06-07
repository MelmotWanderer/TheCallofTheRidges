using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextWriter : MonoBehaviour
{
    private Text _text;
    public float Speed;
    public bool isComplete;
   

    private void Start()
    {
        _text = GetComponent<Text>();
    


    }
    

    public void WriteText(string text, SoundWriting soundWriting = null)
    {
    
        _text.text = "";
        isComplete = false;
        StartCoroutine(TextCoroutine(text, soundWriting));
       
    }

   
    public void Stop()
    {
        StopAllCoroutines();
    }
   private IEnumerator TextCoroutine(string text, SoundWriting soundWriting)
    {
        foreach(char c in text)
        {
            if (soundWriting != null)
            {
                soundWriting.PlayWritingSound();
            }
            _text.text += c;
         
            
            if (c == '.' || c == '!' || c == '?')
            {
                yield return new WaitForSeconds(Speed * 10f);
            }
            if(c == ',')
            {
                yield return new WaitForSeconds(Speed * 2f);
            }
            yield return new WaitForSeconds(Speed);
        }
        isComplete = true;
     
    }
    
    
}
