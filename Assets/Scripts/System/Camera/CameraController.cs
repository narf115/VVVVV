using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject PlayerPoints;
    public GameObject CameraPoints;
    public Camera Camera;
    public GameObject Player;
    // Start is called before the first frame update
    private void Start()
    {
      //  transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, -10);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        TPPlayer(collision.gameObject, PlayerPoints.transform.position);
        TPCamera(Camera, new Vector3(CameraPoints.transform.position.x, CameraPoints.transform.position.y,-100));
    }
    public void TPCamera(Camera TP, Vector3 position)
    {
        TP.transform.position = position;
    }
    public void TPPlayer(GameObject TpPlayer, Vector3 position)
    {
        TpPlayer.transform.position = position;
    }
}
