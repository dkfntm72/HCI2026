using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController2D : MonoBehaviour
{
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }


    void OnFire(InputValue value)
    {
        anim.SetTrigger("IsFire");
    }
}
