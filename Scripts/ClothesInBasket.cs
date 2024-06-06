using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClothesInBasket : MonoBehaviour
{
    public AudioSource ClothesFall;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Clothes")
        {
            ClothesFall.Play();
            Destroy(collider.gameObject);
        }
    }
    void LevelComplete()
    {
        SceneManager.LoadScene(7);
    }
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Clothes").Length <= 0)
            Invoke("LevelComplete", 2.0f);
    }
}