using UnityEngine;

public class ShowPostion : MonoBehaviour
{
    public Color color;
    public float Radius;
    private void OnDrawGizmos()
    {
        Gizmos.color = color;
        Gizmos.DrawSphere(transform.position, Radius);
    }
}
