
using UnityEngine;

public class Rotator : MonoBehaviour
{

    [SerializeField] private float RotationSpeed = 300f;
    private Camera cashedCamera;
    private bool isLookAtNPC;
    private Transform transformNPC;
    private void Start()
    {
        cashedCamera = Camera.main;
    }


    void Update()
    {
        if (isLookAtNPC)
        {
            transform.LookAt(transformNPC);
        }else
        {
            Rotate();
        }
        
    }
    public void SetRotation(Quaternion rotation)
    {
        gameObject.transform.rotation = rotation;
    }
    public void Disable()
    {
        this.enabled = false;
    }
    public void Enable()
    {
        this.enabled = true;
    }

    public void LookAtNPC(Transform looked)
    {
        transformNPC = looked;
        isLookAtNPC = true;
    }
    public void DisableLookAt()
    {
        isLookAtNPC = false;
    }
    private void Rotate()
    {

     if(cashedCamera != null)
        {
            if (Physics.Raycast(cashedCamera.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
            {

                Vector3 diff = hit.point - transform.position;
                diff.Normalize();
                float rot = Mathf.Atan2(diff.x, diff.z) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, rot, 0), Time.deltaTime * RotationSpeed);

            }

        }






    }
 
}
