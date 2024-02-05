using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using MySql.Data.MySqlClient;
using TMPro;


public class Continue : MonoBehaviour
{
    private CollectedController Cs;
    public GameObject player;
    //public GameObject cam;
    public Camera cam;
    MySqlConnection conn;
    private int o, c, p;
    public TextMeshProUGUI Chest, Orb, Patch;
    public GameObject panel;
    public int slot;
    // Start is called before the first frame update
    void Start()
    {
        string connection = "Server=labs.inspedralbes.cat; Database=fvilches_Plataforms; Uid=fvilches_platforms; password=Plataforms115; CharSet=utf8; port= 3306";
        conn = new MySqlConnection(connection);
        
        conn.Open();
    }
    public void NW()
    {
        panel.gameObject.SetActive(false);
    }
    public void PlayPlay()
    {

       
        conn.Close();
        conn.Open();
        string query = "SELECT * FROM Partidas WHERE id=(SELECT max(ID) FROM Partidas)";
        //  string query = "SELECT * FROM Partidas";
        var command = new MySqlCommand(query, conn);

        var reader = command.ExecuteReader();
        Debug.Log(query);
        // var command = new MySqlCommand(query, conn);
        //MySqlDataReader reader = command.ExecuteReader();
        //cmd = new MySqlCommand(query, conn);
        // MySqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {


            string xps = reader.GetString("posx");
            xps = xps.Replace(".", ",");

            string xys = reader.GetString("posy");
            xys = xys.Replace(".", ",");

            string cxps = reader.GetString("cposx");
            cxps = cxps.Replace(".", ",");

            string cxy = reader.GetString("cposy");
            cxy = cxy.Replace(".", ",");



            float fxps = float.Parse(xps);
            float fxys = float.Parse(xys);

            float fcxps = float.Parse(cxps);
            float fcxy = float.Parse(cxy);


            int os = reader.GetInt32("Orb");
            int ch = reader.GetInt32("Chest");
            int pt = reader.GetInt32("Patch");


            player.transform.position = new Vector3(fxps, fxys);
            cam.transform.position = new Vector3(fcxps, fcxy, -10);
            OrbUI.Score(os);
            Cheste.Score(ch);
            //ChestUI.Score(ch);
            PatchUi.Score(pt);
            Debug.Log(fxys);
            Debug.Log(fxps);
            Debug.Log(fcxps);
            Debug.Log(fcxy);
            Debug.Log(os);
            Debug.Log(ch);
            Debug.Log(pt);
        }
        conn.Close();
        panel.gameObject.SetActive(false);
    }
    public void PlayPlay2(int slot)
    {


        conn.Close();
        conn.Open();
        string query = "SELECT * FROM Partidas WHERE id=(SELECT max(ID)- "+slot+" FROM Partidas)";
        //  string query = "SELECT * FROM Partidas";
        var command = new MySqlCommand(query, conn);

        var reader = command.ExecuteReader();
        Debug.Log("Dolor");
        // var command = new MySqlCommand(query, conn);
        //MySqlDataReader reader = command.ExecuteReader();
        //cmd = new MySqlCommand(query, conn);
        // MySqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {


            string xps = reader.GetString("posx");
            xps = xps.Replace(".", ",");

            string xys = reader.GetString("posy");
            xys = xys.Replace(".", ",");

            string cxps = reader.GetString("cposx");
            cxps = cxps.Replace(".", ",");

            string cxy = reader.GetString("cposy");
            cxy = cxy.Replace(".", ",");



            float fxps = float.Parse(xps);
            float fxys = float.Parse(xys);

            float fcxps = float.Parse(cxps);
            float fcxy = float.Parse(cxy);


            int os = reader.GetInt32("Orb");
            int ch = reader.GetInt32("Chest");
            int pt = reader.GetInt32("Patch");


            player.transform.position = new Vector3(fxps, fxys);
            cam.transform.position = new Vector3(fcxps, fcxy, -10);
            OrbUI.Score(os);
            Cheste.Score(ch);
            //ChestUI.Score(ch);
            PatchUi.Score(pt);
            Debug.Log(fxys);
            Debug.Log(fxps);
            Debug.Log(fcxps);
            Debug.Log(fcxy);

        }
        conn.Close();
        panel.gameObject.SetActive(false);
    }
}
