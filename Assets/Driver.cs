using UnityEngine;
using System.Collections;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 1f; 
    [SerializeField] float moveSpeed = 20f;
    [SerializeField] float slowSpeed = 15f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float boostDuration = 0.01f; // Boost sementara
  
    private float defaultSpeed;

    void Start()
    {
        defaultSpeed = moveSpeed; 
    }

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Kambing nabrak! Kecepatan berkurang.");
        moveSpeed = slowSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Boost")
        {
            StopCoroutine("BoostCoroutine");
            StartCoroutine(BoostCoroutine());
        }
    }

///in aku gatau bener apa ngga waa

    IEnumerator BoostCoroutine()
    {
        moveSpeed = boostSpeed;
        yield return new WaitForSeconds(boostDuration);
        moveSpeed = defaultSpeed;
    }
}
