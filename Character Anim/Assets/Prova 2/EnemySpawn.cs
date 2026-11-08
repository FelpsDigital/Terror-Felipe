using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    
    [SerializeField]GameObject enemyPrefab;
    float cooldown = 0;
    [SerializeField] GameObject[] spawnPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cooldown += Time.deltaTime;
        bool cooldownAtivo = false;
        int surgir = Random.Range(0, 10);
        

        if (cooldown < 5f)
        {
            cooldownAtivo = true;
        }
        else if(cooldown >= 5)
        {
            cooldownAtivo = false;
        }

       if(surgir == 5 && cooldownAtivo == false )
       {
        Instantiate(enemyPrefab,spawnPrefab[Random.Range(0, spawnPrefab.Length)].transform.position,Quaternion.identity);
        cooldown = 0;
        cooldownAtivo = true;    
        
       }
    }
}
