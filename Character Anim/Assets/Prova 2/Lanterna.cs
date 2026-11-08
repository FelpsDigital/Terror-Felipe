using UnityEngine;
using UnityEngine.SceneManagement;

public class Lanterna : MonoBehaviour
{
    int pontuacao = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pontuacao == 10)
        {
            Debug.Log("Ganhou"); 
            SceneManager.LoadScene("JogoDaLanterna"); 
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            pontuacao = pontuacao +1;
            Debug.Log("pontos" +  pontuacao);

        }
    }
}
