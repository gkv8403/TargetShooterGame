using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerShooter : MonoBehaviour
{
    [Header("Shooting")]
    public GameObject projectilePrefab;
    public Transform shootPoint;
    public float shootForce = 10f;

    [Header("Movement")]
    public float moveSpeed = 5f;
    public float rotationSpeed = 100f;

    private Rigidbody rb;
    private float moveInput;
    private float rotateInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Forward/backward
        moveInput = Input.GetAxisRaw("Vertical");   // W/S
        rotateInput = Input.GetAxisRaw("Horizontal"); // A/D
    }

    private void FixedUpdate()
    {
        // Move forward/backward
        Vector3 move = transform.forward * moveInput * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + move);

        // Rotate left/right
        Quaternion turn = Quaternion.Euler(0f, rotateInput * rotationSpeed * Time.fixedDeltaTime, 0f);
        rb.MoveRotation(rb.rotation * turn);
    }

    public void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);
        Rigidbody rbProjectile = projectile.GetComponent<Rigidbody>();
        rbProjectile.AddForce(transform.forward * shootForce, ForceMode.Impulse);
    }
}
