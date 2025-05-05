using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Vince Herrera
 */
public class Player_Death : MonoBehaviour
{
    [SerializeField] public float delay = 2f;
    [SerializeReference] AudioSource myDeathSound;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Kill")
        {
            myDeathSound.Play();
            StartCoroutine(WaitAndLoadScene());
        }
    }

    private System.Collections.IEnumerator WaitAndLoadScene()
    {
        //wait for the death clip to end, then load the scene
        yield return new WaitForSeconds(myDeathSound.clip.length);
        gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
