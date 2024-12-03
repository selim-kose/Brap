using UnityEngine;

public class Billboard : MonoBehaviour
{

    public Transform cam;

    private void Start()
    {
        cam = GameObject.FindGameObjectWithTag("Cinemachine").transform;
    }
    private void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }
}
