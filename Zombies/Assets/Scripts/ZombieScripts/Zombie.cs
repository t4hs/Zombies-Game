using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int currentHealth;
    private int maxHealth;
    GameObject zombieGO;
    

    void Awake()
    {
        maxHealth = UnityEngine.Random.Range(50,150);
        InitHealth();
    }
    void Start()
    {
        
    }
    
    
    public void TakeDamage(int amount)
    {
        currentHealth-=amount;

        if(currentHealth <=0)
        {
            currentHealth = 0;
        }
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }

    public int GetHealth()
    {
        return this.currentHealth;
    }

    public void SetZombie(int amount)
    {
        for(int i=0; i<amount; i++)
        {
            GameObject zbObject = Instantiate(this.gameObject, new Vector3(i * 2.0f, 0, 0), Quaternion.identity);
            zbObject.transform.SetParent(GameManager.GetInstance().zombieSpawning.transform, false);
            ZombieManager.GetInstance().AddZombie(zbObject.GetComponent<Zombie>());
        }
    }

    // Update is called once per frame
    private void InitHealth()
    {
        currentHealth = maxHealth;
    }

    public int GetCurrentHealth()
    {
        return this.currentHealth;
    }


}
