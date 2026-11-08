using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] string cena;
    public Animator transition;
    public void Colisao(GameObject objeto)
    {
        if (objeto == player && cena == "IgrejaExterna")
        {
            LoadNextLevel();
        }
    }
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(1));
    }
    IEnumerator LoadLevel(int nivelAtual)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(nivelAtual); 
    }
}