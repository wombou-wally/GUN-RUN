using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("Shooting")]
    [Tooltip("The ray cast origin position")][SerializeField] private Transform muzzle;
    [Tooltip("Gun Range")][SerializeField] private float gunRange = 20f;
    [Tooltip("Gun Damage")][SerializeField] private float damage = 20f;
    [Header("Timing")]
    [Tooltip("Shoot cool down")][SerializeField] private float fireRate = 0.5f;
    private Rigidbody rb;
    [SerializeField][Tooltip("Recoil force")] private float recoilForce = 1.0f;
    [SerializeField][Tooltip("Recoil force")] private float torqueForce = 1.0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private float nextFireTime = 0f;
    public void Shoot()
    {
        RaycastHit hit;
        Debug.DrawRay(muzzle.position, muzzle.forward * gunRange, Color.red, 5);
        Recoil();
        if (Physics.Raycast(muzzle.position, muzzle.forward, out hit, gunRange))
        {
            if (hit.collider.TryGetComponent<IDamageable>(out var damageable))
            {
                damageable.TakeDamage(damage);
            }

            Debug.Log(hit.collider.gameObject);
        }

    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.R) && Time.time >= nextFireTime)
        {
            Debug.Log("Shoot");
            Shoot();
            nextFireTime = Time.time + fireRate;
        }

    }
    public void Recoil()
    {
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.AddForce(-muzzle.forward * recoilForce,ForceMode.Impulse);
        rb.AddTorque(Vector3.left * torqueForce,ForceMode.Impulse);
        Debug.Log("recoling...");
        
    }
}
