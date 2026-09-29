using UnityEngine;

public class CannonController : MonoBehaviour
{
    public GameObject shellPrefab;
    public Transform fireTrans;
    Rigidbody rb;
    GameObject shell;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        
        if(Input.GetButtonDown("Fire1"))
        {
            Debug.Log(1);
            shell = Instantiate(shellPrefab, fireTrans.position, fireTrans.rotation);
            shell.GetComponent<ShellController>().Shoot(transform.up);
        }
    }
}
