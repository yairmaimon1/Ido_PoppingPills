using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const float JUMP_AMOUNT = 100.0f;
    private Rigidbody2D birdRigidbody2D;
    [SerializeField] private AudioSource JumpAudio;

    private void Awake()
    {
        birdRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began  || Input.GetKey(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Jump();
        }
        transform.eulerAngles = new Vector3(0f, 0f, GetComponent<Rigidbody2D>().velocity.y * 0.2f);
    }

    void Jump()
    {
        birdRigidbody2D.velocity = new Vector2(0, JUMP_AMOUNT);
        JumpAudio.Play();
    }
}
