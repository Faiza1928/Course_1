using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int nyawa = 3;
    private Vector3 checkpointPosition; // Posisi terakhir pick-up setan

    void Start()
    {
        checkpointPosition = transform.position; // Set posisi awal sebagai checkpoint pertama
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Set checkpoint saat pick-up setan
        if (other.CompareTag("Setan"))
        {
            checkpointPosition = transform.position;
            Debug.Log("Checkpoint disimpan di: " + checkpointPosition);
        }

        // Keluar jalur = nyawa berkurang dan teleport ke checkpoint
        if (other.CompareTag("KeluarJalur"))
        {
            nyawa--; // Kurangi nyawa
            Debug.Log("Keluar jalur! Nyawa tersisa: " + nyawa);

            if (nyawa > 0)
            {
                transform.position = checkpointPosition;
                Debug.Log("Respawn di checkpoint terakhir.");
            }
            else
            {
                Debug.Log("Game Over!");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
