using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    private Vector3 startVector = Vector3.zero;

    private float finishBoundary = -19.2f;

    [SerializeField] private float speed;

    void Update()
    {
        if (transform.position.x <= finishBoundary)
        {
            transform.position = startVector;
        }

        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
