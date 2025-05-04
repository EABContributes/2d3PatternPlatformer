using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndBlock : MonoBehaviour
{
    [SerializeField] private Canvas endingCanvas;
    [SerializeField] private Button endButton;

    private void Start()
    {
        endingCanvas.gameObject.SetActive(false);
        endButton.onClick.AddListener(EndGame);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            endingCanvas.gameObject.SetActive(true);
        }
    }

    private void EndGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
