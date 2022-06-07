using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
[RequireComponent(typeof(BoxCollider))]
public abstract class Shell : MonoBehaviour
{
    [HideInInspector] public string soundMusicPath;

    protected float _damage;

    protected BoxCollider _collider;

    

    private void Start()
    {
        _collider = GetComponent<BoxCollider>();
        _collider.enabled = false;

        if (soundMusicPath != null)
        {
            PlaySound();
        }
        

            StartCoroutine(Wait());
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<IDamagable>() != null)
        {
            Hit(collision.gameObject.GetComponent<IDamagable>());
           
        }
        Destroy(this.gameObject);

    }
    public void SetDamage(float damage)
    {
        _damage = damage;

    }

    public void SetSoundShootPath(string path)
    {
        soundMusicPath = path;
        
    }
    
    protected abstract void Hit(IDamagable damagable);
    protected void PlaySound()
    {
       
        RuntimeManager.PlayOneShot(soundMusicPath);
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.05f);
        _collider.enabled = true;
    }
    
}
