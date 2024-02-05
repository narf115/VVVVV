using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; //textos pros 
using System;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class HealthBeheivor : MonoBehaviour
{
    //primera parte 
    // public static event Action<int, int> OnHurt = delegate { }; // Lanzas un evento 
    public UnityEvent<int> OnHurt;
    [SerializeField]
    public int health=2;
   
    private int MaxHealth=10;
    public UnityEvent OnDie;
    //Referencia directa 
    // public GameObject healthcanvas; 
    
    public void Hurt(int damage)
    {
        health -= damage;

       
        //USO FIND
        //GameObject TextHealth = GameObject.Find("HealthCanvas");
        //if(TextHealth!=null)
        //TextHealth.GetComponent<Text>().text ="Life:" +health;

        //REFERENCIA DIRECTA
        // healthcanvas.GetComponent<Text>().text = "Life: " + health;

        //EVENTOS
        //lo envias, ahora hay que suscribirse. Creas un script con el mismo nombre que el objeto que deseas modificar.  
        //segunda parte 
        // OnHurt(health, MaxHealth);
        if (health <= 0)
            OnDie.Invoke();
        OnHurt.Invoke(health);
    }
    public int GetHealth()
    {
        return health;
        
    }
    public void SetHealth(int h)
    {
        if (h <= MaxHealth)
            health = h;
    }
    public void AddHealth(int h)
    {

        health += h;
        if (health > MaxHealth)
            health = MaxHealth;
    }
    public void DeathEnemy()
    {
        //ScoreBeheivor.Score(1);

        //EnemyGenerator.listEnemies.Remove(gameObject);
        gameObject.SetActive(false);
       // Destroy(gameObject);
    }
    public void DeathPlayer()
    {




        //  SceneManager.LoadScene("Game Over");
        Debug.Log("AAAAAAAA muriste");
        
    }
    
   
}
