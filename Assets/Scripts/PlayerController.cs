using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    [SerializeField] private float xBound = 1f;
    [SerializeField] private float zBound = 1f;

    // ENCAPSULATION
    public bool dead
    {
        get; private set;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (!dead)
        {
            // Prevent accelerated diagonal movement by using normalized vector if smaller
            Vector3 inputVector = new Vector3(horizontalInput, 0, verticalInput);
            Vector3 inputVectorNormalized = inputVector.normalized;
            if (inputVector.magnitude > inputVectorNormalized.magnitude)
                inputVector = inputVectorNormalized;

            Vector3 movementVector = inputVector * Time.deltaTime * speed;

            // Move
            gameObject.transform.Translate(movementVector);
        }
        
    }

    private void LateUpdate()
    {
        // If out of bounds, return to bounds
        if (transform.position.x > xBound)
            transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
        else if (transform.position.x < -xBound)
            transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);

        if (transform.position.z > zBound)
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
        if (transform.position.z < -zBound)
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!dead && collision.gameObject.CompareTag("Ball"))
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("You died!");
        dead = true;
    }
}
