using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using System;

public   class DeathBeheivor : MonoBehaviour
{
   
    public GameObject gb;
    private Animator anim;
    private RespawnManager rw;
    public WarriorController war;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rw = GetComponent<RespawnManager>();
    }
    public void DeathEnemy(GameObject gb)
    {
        //ScoreBeheivor.Score(1);

        //EnemyGenerator.listEnemies.Remove(gameObject);
        Debug.Log("xds");
        gb.SetActive(false);
        // Destroy(gameObject);
    }
    public void DeathPlayer()
    {
        Debug.Log("Muriste");
        anim.SetBool("IsDeath?", true);

        StartCoroutine(Deathss());
    }
    
    public void DeathEnemys(GameObject gb)
    {
        //ScoreBeheivor.Score(1);

        //EnemyGenerator.listEnemies.Remove(gameObject);
      //  GameObject DD = Instantiate(GBs, gb.transform.position, gb.transform.rotation);
        gb.SetActive(false);
        // Destroy(gameObject);
    }
    public void Boom()
    {
       // GameObject DD = Instantiate(GBs, gb.transform.position, gb.transform.rotation);
    }
    IEnumerator Deathss()
    {
        yield return new WaitForSeconds(0.8f);
        anim.SetBool("IsDeath?", false);
        rw.Respawn(war);
       
        // SceneManager.LoadScene("GameOver");
    }
}
