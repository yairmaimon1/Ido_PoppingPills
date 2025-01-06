using UnityEngine;
using CodeMonkey;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private GameObject EndScreen;
    [SerializeField] private AudioSource DeathAudio;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<PlayerController>().enabled = true;
        respawnSpikes.SpikesSpeed = 30f;
        MoveGround.GroundSpeed = 30f;
        EndScreen.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Die();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Die();
    }

    private void Die()
    {
        GetComponent<PlayerController>().enabled = false;
        respawnSpikes.SpikesSpeed = 0f;
        MoveGround.GroundSpeed = 0f;
        DeathAudio.Play();
        EndScreen.SetActive(true);
        CMDebug.TextPopupMouse("Dead!");
    }
}
