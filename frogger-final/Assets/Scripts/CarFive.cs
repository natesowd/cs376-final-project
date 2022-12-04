using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class CarFive : MonoBehaviour
{
    public Vector2 direction = Vector2.right;
    public float speed = 1f;
    public int size = 1;

    private Vector3 leftEdge;
    private Vector3 rightEdge;

    public AudioClip hitSound;

    AudioSource audioSource;

    private void Start()
    {
        leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);
        audioSource = GetComponent<AudioSource>();

    }

    private void Update()
    {
        // Check if the object is past the right edge of the screen
        if (direction.x > 0 && (transform.position.x - size) > rightEdge.x) {
            transform.position = new Vector3(leftEdge.x - size, transform.position.y, transform.position.z);
        }
        // Check if the object is past the left edge of the screen
        else if (direction.x < 0 && (transform.position.x + size) < leftEdge.x) {
            transform.position = new Vector3(rightEdge.x + size, transform.position.y, transform.position.z);
        }
        // Move the object
        else {
            transform.Translate(direction * speed * Time.deltaTime);
        }

        if(Physics2D.OverlapBox(transform.position, new Vector3(0.5f, 0.5f, 0.5f), 0f, LayerMask.GetMask("Player")) != null)
        {
            // audioSource = GetComponent<AudioSource>();
            audioSource.PlayOneShot(hitSound);
            Debug.Log("Player hit");
        }
    }

}
