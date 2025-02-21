using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public Dialogue dialogueUI;
    private Setan setanTerdekat;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && setanTerdekat != null)
        {
            dialogueUI.StartDialogue(setanTerdekat.GetDialog());
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Setan"))
        {
            setanTerdekat = other.GetComponent<Setan>();
        }
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        if (other.CompareTag("Setan"))
        {
            setanTerdekat = null;
        }
    }

}
