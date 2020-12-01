using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    public int sceneID;
    public float positionX;
    public float positionY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            Player.spawnPositionX = positionX;
            Player.spawnPositionY = positionY;
            GameManager.ChangeScene(sceneID);
        }
    }
}
