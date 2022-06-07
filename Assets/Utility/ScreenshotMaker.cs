using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenshotMaker : MonoBehaviour
{
    private Camera _camera;
    public int width;
    public int height;
   
    private void Awake()
    {
        _camera = GetComponent<Camera>();
       
        
    }
    private void Update()
    {
        if (Input.GetButtonDown("MakeScreenshot"))
        {
          
            _camera.targetTexture = RenderTexture.GetTemporary(Screen.width, Screen.height, 16);
            Debug.Log(Screen.width);
            StartCoroutine(Coroutine());

        }
       
    }


    private IEnumerator Coroutine()
    {
        yield return new WaitForEndOfFrame();
       
        RenderTexture texture = _camera.targetTexture;
        Texture2D result = new Texture2D(texture.width, texture.height, TextureFormat.ARGB32, false);
        Rect rect = new Rect(0, 0, texture.width, texture.height);
        result.ReadPixels(rect, 0, 0);
        byte[] byteArray = result.EncodeToJPG();
        System.IO.File.WriteAllBytes(Application.dataPath + "/Screenshot.jpg", byteArray);
        Debug.Log("Maked!");
        RenderTexture.ReleaseTemporary(texture);
        _camera.targetTexture = null;
        RenderTexture.active = texture;
     
    }
}
