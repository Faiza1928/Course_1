using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasSetanColor = new Color32(255, 0, 0, 255);
    [SerializeField] Color32 noSetanColor = new Color32(255, 255, 255, 255);
    [SerializeField] float destroyDelay = 1f;
    
    [SerializeField] Dialogue dialogue; // Tambahkan referensi ke skrip Dialogue.cs

    bool hasSetan = false;
    Setan setanDibawa;
    SpriteRenderer spriteRenderer;

    void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();    
        spriteRenderer.color = noSetanColor; // Warna awal
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        // PICKUP SETAN
        if (other.CompareTag("Setan") && !hasSetan) 
        {
            Debug.Log("Setan naik ke kambing!");
            hasSetan = true;
            setanDibawa = other.GetComponent<Setan>(); 
            spriteRenderer.color = hasSetanColor; // Ganti warna kendaraan
            
            // MUNCULKAN UI DIALOG DAN SETAN BERBICARA
            dialogue.StartDialogue(setanDibawa.GetDialog());

            Destroy(other.gameObject, destroyDelay); // Hapus setan setelah delay
        }

        // DROP SETAN DI TUJUAN YANG BENAR
        if (other.CompareTag("TujuanSetan") && hasSetan)
        {
            string tujuanSetan = setanDibawa.tujuanSetan;
            string tujuanSekarang = other.gameObject.name;

            if (tujuanSekarang == tujuanSetan)
            {
                Debug.Log("Setan berhasil diantar ke " + tujuanSekarang + "!");
                hasSetan = false;
                spriteRenderer.color = noSetanColor; // Kembalikan warna ke normal
                setanDibawa = null;
            }
            else
            {
                Debug.Log("Setan tidak mau turun di sini! Tujuan yang benar: " + tujuanSetan);
            }
        }
    }
}
