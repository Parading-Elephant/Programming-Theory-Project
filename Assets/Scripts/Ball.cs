using UnityEngine;

public class Ball : MonoBehaviour
{

    AudioSource hitAS;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hitAS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        // play SFX
    }
}
