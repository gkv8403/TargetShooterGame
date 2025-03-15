using UnityEngine;

public class MiniMapFollow : MonoBehaviour
{
    public Transform target;

    private void LateUpdate()
    {
        if (target == null) return;

        Vector3 newPosition = target.position;
        newPosition.y = transform.position.y; // Keep same height
        transform.position = newPosition;

       
        transform.rotation = Quaternion.Euler(90f, target.eulerAngles.y, 0f);
    }
}
