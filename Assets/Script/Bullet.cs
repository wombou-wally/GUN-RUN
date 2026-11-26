using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 target;
    private float speed;
    private bool launched;

    public void Launch(Vector3 targetPoint, float bulletSpeed)
    {
        target = targetPoint;
        speed = bulletSpeed;
        launched = true;
    }

    private void Update()
    {
        if (!launched) return;

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position == target)
        {
            Destroy(gameObject);
        }
    }
}