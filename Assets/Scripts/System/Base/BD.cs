using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;
using TMPro;

public class BD : MonoBehaviour
{
    private CollectedController Cs;
    public GameObject player;
    public Camera cam;
    MySqlConnection conn;
    private int o, c, p;
    public TextMeshProUGUI Chest, Orb, Patch;
    public GameObject panel;
    public int slot;
    // public List<GameObject> Coll;
    public GameObject perch1,ch1,or1,perch2,perch3,ch2,or2,ch3,ch4,or3,perch4,or4,perch5,ch5,or5,ch6,perch6;
    void Start()
    {
        Cs = GetComponent<CollectedController>();
        //pea = GetComponent<Patch>();
        string connection = "Server=labs.inspedralbes.cat; Database=fvilches_Plataforms; Uid=fvilches_platforms; password=Plataforms115; CharSet=utf8; port= 3306";
        conn = new MySqlConnection(connection);

        conn.Open();
       // Pos();
       // conn.Close();
    }
    private void Pos()
    {
        string query = "SELECT * FROM Partidas";
        var command = new MySqlCommand(query, conn);
        MySqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            string xps = reader.GetString("posx");
            xps = xps.Replace(".", ",");
            string xys = reader.GetString("poxy");
            xys = xys.Replace(".", ",");

            float fxps = float.Parse(xps);
            float fxys = float.Parse(xys);


            int os = reader.GetInt32("Orb");
            int ch = reader.GetInt32("Chest");
            int pt = reader.GetInt32("Patch");


            player.transform.position = new Vector3(fxps, fxys);
            OrbUI.Score(os);
            ChestUI.Score(ch);
            PatchUi.Score(pt);
            Debug.Log(fxys);
            Debug.Log(fxps);

        }
        conn.Close();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            conn.Close();
            conn.Open();
            Debug.Log("AAA guardaste los datos");
            string xps = player.transform.position.x.ToString();
            xps = xps.Replace(",", ".");
            string xy = player.transform.position.y.ToString();
            xy = xy.Replace(",", ".");

            //Camera
           
            string cxps = cam.transform.position.x.ToString();
            cxps= cxps.Replace(",", ".");
            
            string cxy = cam.transform.position.y.ToString();
            cxy= cxy.Replace(",", ".");
            
          
            
            int ob = Cs.getO(o);
            int ch = Cs.getC(c);
            int pa = Cs.getP(p);
            // bool pe = pea.GetIsCaught(pb);
            bool Perch1 = perch1.activeInHierarchy;
            bool Perch2 = perch2.activeInHierarchy;
            bool Perch3 = perch3.activeInHierarchy;
            bool Perch4 = perch4.activeInHierarchy;
            bool Perch5 = perch5.activeInHierarchy;
            bool Perch6 = perch6.activeInHierarchy;

            bool Ch1 = ch1.activeInHierarchy;
            bool Ch2 = ch2.activeInHierarchy;
            bool Ch3 = ch3.activeInHierarchy;
            bool Ch4 = ch4.activeInHierarchy;
            bool Ch5 = ch5.activeInHierarchy;
            bool Ch6 = ch6.activeInHierarchy;

            bool Or1 = or1.activeInHierarchy;
            bool Or2 = or2.activeInHierarchy;
            bool Or3 = or3.activeInHierarchy;
            bool Or4 = or4.activeInHierarchy;
            bool Or5 = or5.activeInHierarchy;

            string query = $"INSERT INTO Partidas(posx,posy,Orb,Chest,Patch,cposx,cposy,Perch1,Ch1,Or1,Perch2,Perch3,Ch2,Or2,Ch3,Ch4,Or3,Perch4,Or4,Perch5,Ch5,Or5,Ch6,Perch6) VALUES({xps},{xy},{ob},{ch},{pa},{cxps},{cxy},{Perch1},{Ch1},{Or1},{Perch2},{Perch3},{Ch2},{Or2},{Ch3},{Ch4},{Or3},{Perch4},{Or4},{Perch5},{Ch5},{Or5},{Ch6},{Perch6})";
            Debug.Log(query);
            var command = new MySqlCommand(query, conn);
            command.ExecuteNonQuery();
            conn.Close();
        }

       if (Input.GetKeyDown(KeyCode.P))
        {
            conn.Close();
            conn.Open();
            string query = "SELECT * FROM Partidas WHERE id=(SELECT max(ID) FROM Partidas)";
            
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

                bool patch1 = reader.GetBoolean("Perch1");
                
                int os = reader.GetInt32("Orb");
               int ch = reader.GetInt32("Chest");
              int pt = reader.GetInt32("Patch");


                player.transform.position = new Vector3(fxps, fxys);
                cam.transform.position = new Vector3(fcxps, fcxy,-10);
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
        } 
        if (Input.GetKeyDown(KeyCode.K))
        {
            conn.Close();
            conn.Open();
            Debug.Log("AAA borraste los datos");
            string query = "DELETE FROM Partidas";
            var command = new MySqlCommand(query, conn);
            command.ExecuteNonQuery();
            conn.Close();
        }


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
            ////Perch1////

            bool patch1 = reader.GetBoolean("Perch1");
            // Debug.Log(patch1);
            if (patch1 == false)
            {
                
                perch1.SetActive(false);
            }

            bool patch2 = reader.GetBoolean("Perch4");
            // Debug.Log(patch2);
            if (patch2 == false)
            {

                perch2.SetActive(false);
            }

            bool patch3 = reader.GetBoolean("Perch4");
            // Debug.Log(patch3);
            if (patch3 == false)
            {

                perch3.SetActive(false);
            }
            bool patch4 = reader.GetBoolean("Perch4");
            // Debug.Log(patch4);
            if (patch4 == false)
            {

                perch4.SetActive(false);
            }

            bool patch5 = reader.GetBoolean("Perch5");
            // Debug.Log(patch5);
            if (patch5 == false)
            {

                perch5.SetActive(false);
            }

            bool patch6 = reader.GetBoolean("Perch6");
            // Debug.Log(patch6);
            if (patch6 == false)
            {

                perch6.SetActive(false);
            }

            ////CHEST////
            bool Chest1 = reader.GetBoolean("Ch1");
            // Debug.Log(Chest1);
            if (Chest1 == false)
            {

                ch1.SetActive(false);
            }

            bool Chest2 = reader.GetBoolean("Ch2");
            // Debug.Log(Chest2);
            if (Chest2 == false)
            {

                ch2.SetActive(false);
            }

            bool Chest3 = reader.GetBoolean("Ch3");
            // Debug.Log(Chest3);
            if (Chest3 == false)
            {

                ch3.SetActive(false);
            }
            bool Chest4 = reader.GetBoolean("Ch4");
            // Debug.Log(Chest4);
            if (Chest4 == false)
            {

                ch4.SetActive(false);
            }

            bool Chest5 = reader.GetBoolean("Ch5");
            // Debug.Log(Chest5);
            if (Chest5 == false)
            {

                ch5.SetActive(false);
            }

            bool Chest6 = reader.GetBoolean("Ch6");
            // Debug.Log(Chest6);
            if (Chest6 == false)
            {

                ch6.SetActive(false);
            }
            ////Orb////

            bool orb1 = reader.GetBoolean("Or1");
           // Debug.Log(orb1);
            if (orb1 == false)
            {
                or1.SetActive(false);
            }
            bool orb2 = reader.GetBoolean("Or2");
            // Debug.Log(orb1);
            if (orb2 == false)
            {
                or2.SetActive(false);
            }
            bool orb3 = reader.GetBoolean("Or3");
            // Debug.Log(orb1);
            if (orb3 == false)
            {
                or3.SetActive(false);
            }
            bool orb4 = reader.GetBoolean("Or4");
            // Debug.Log(orb1);
            if (orb4 == false)
            {
                or4.SetActive(false);
            }
            bool orb5 = reader.GetBoolean("Or5");
            // Debug.Log(orb1);
            if (orb5 == false)
            {
                or5.SetActive(false);
            }
        }
        conn.Close();
        panel.gameObject.SetActive(false);
    }
    public void PlayPlay2(int slot)
    {


        conn.Close();
        conn.Open();
        string query = "SELECT * FROM Partidas WHERE id=(SELECT max(ID)- " + slot + " FROM Partidas)";
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

            ////Perch1////

            bool patch1 = reader.GetBoolean("Perch1");
            // Debug.Log(patch1);
            if (patch1 == false)
            {

                perch1.SetActive(false);
            }

            bool patch2 = reader.GetBoolean("Perch4");
            // Debug.Log(patch2);
            if (patch2 == false)
            {

                perch2.SetActive(false);
            }

            bool patch3 = reader.GetBoolean("Perch4");
            // Debug.Log(patch3);
            if (patch3 == false)
            {

                perch3.SetActive(false);
            }
            bool patch4 = reader.GetBoolean("Perch4");
            // Debug.Log(patch4);
            if (patch4 == false)
            {

                perch4.SetActive(false);
            }

            bool patch5 = reader.GetBoolean("Perch5");
            // Debug.Log(patch5);
            if (patch5 == false)
            {

                perch5.SetActive(false);
            }

            bool patch6 = reader.GetBoolean("Perch6");
            // Debug.Log(patch6);
            if (patch6 == false)
            {

                perch6.SetActive(false);
            }

            ////CHEST////
            bool Chest1 = reader.GetBoolean("Ch1");
            // Debug.Log(Chest1);
            if (Chest1 == false)
            {

                ch1.SetActive(false);
            }

            bool Chest2 = reader.GetBoolean("Ch2");
            // Debug.Log(Chest2);
            if (Chest2 == false)
            {

                ch2.SetActive(false);
            }

            bool Chest3 = reader.GetBoolean("Ch3");
            // Debug.Log(Chest3);
            if (Chest3 == false)
            {

                ch3.SetActive(false);
            }
            bool Chest4 = reader.GetBoolean("Ch4");
            // Debug.Log(Chest4);
            if (Chest4 == false)
            {

                ch4.SetActive(false);
            }

            bool Chest5 = reader.GetBoolean("Ch5");
            // Debug.Log(Chest5);
            if (Chest5 == false)
            {

                ch5.SetActive(false);
            }

            bool Chest6 = reader.GetBoolean("Ch6");
            // Debug.Log(Chest6);
            if (Chest6 == false)
            {

                ch6.SetActive(false);
            }
            ////Orb////

            bool orb1 = reader.GetBoolean("Or1");
            // Debug.Log(orb1);
            if (orb1 == false)
            {
                or1.SetActive(false);
            }
            bool orb2 = reader.GetBoolean("Or2");
            // Debug.Log(orb1);
            if (orb2 == false)
            {
                or2.SetActive(false);
            }
            bool orb3 = reader.GetBoolean("Or3");
            // Debug.Log(orb1);
            if (orb3 == false)
            {
                or3.SetActive(false);
            }
            bool orb4 = reader.GetBoolean("Or4");
            // Debug.Log(orb1);
            if (orb4 == false)
            {
                or4.SetActive(false);
            }
            bool orb5 = reader.GetBoolean("Or5");
            // Debug.Log(orb1);
            if (orb5 == false)
            {
                or5.SetActive(false);
            }
        }
        conn.Close();
        panel.gameObject.SetActive(false);
    }
}
