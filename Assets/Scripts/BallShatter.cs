using UnityEngine;

// INHERITANCE
public class BallShatter : Ball
{
    [SerializeField] private GameObject fragmentPrefab;
    [SerializeField] private int fragmentQuantity = 3;
    [SerializeField] private float fragmentForce = 70;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // POLYMORPHISM
    protected override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            // Shatter into multiple balls
            for (int i = 0; i < fragmentQuantity; i++)
            {
                //SpawnFragment(i * (360 / fragmentQuantity));
                SpawnFragment(Random.Range(0f, 360f));
            }

            // Then destroy this
            Destroy(gameObject);
        }
        
    }

    private void SpawnFragment(float yRotation)
    {
        GameObject fragment = Instantiate(fragmentPrefab, transform.position + new Vector3(0f, 0.05f, 0f), fragmentPrefab.transform.rotation);
        Vector3 forceVector = Quaternion.AngleAxis(yRotation, Vector3.up) * new Vector3(0, 1, 0.5f);
        fragment.GetComponent<Rigidbody>().AddForce(forceVector * fragmentForce, ForceMode.Impulse);
    }
}
