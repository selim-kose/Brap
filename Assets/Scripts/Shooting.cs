using Unity.VisualScripting;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject missilePrefab;

    public float bulletForce = 0.1f;
    public float missileForce = 0.11f;

    public bool isFire = false;

    public InputSystem_Actions controls;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    private void Awake()
    {
        // Initialize the input actions
        controls = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        // Enable the input actions and subscribe to the Click action
        controls.Player.Enable();
        controls.Player.Attack.performed += OnClickPerformed;
        controls.Player.SecondaryAttack.performed += OnClickPerformed2;
    }

    private void OnDisable()
    {
        // Unsubscribe from the Click action and disable input actions
        controls.Player.Attack.performed -= OnClickPerformed;
        controls.Player.Disable();
    }

    private void OnClickPerformed(InputAction.CallbackContext context)
    {

        // Log to the console when the left mouse button is pressed
        // Debug.Log("Left mouse button clicked1!");
        Shoot();
    }

    private void OnClickPerformed2(InputAction.CallbackContext context)
    {

        // Log to the console when the left mouse button is pressed
        // Debug.Log("Left mouse button clicked1!");
        SecondaryAtttack();
    }
    void Shoot()
    {
        Debug.Log("Shot");
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

    void SecondaryAtttack()
    {
        Debug.Log("Secondary Attack");
        GameObject missile = Instantiate(missilePrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = missile.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * missileForce, ForceMode2D.Impulse);



    }
}

