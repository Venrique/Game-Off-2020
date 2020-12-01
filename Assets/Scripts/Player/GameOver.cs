 using UnityEngine;
 
 public class GameOver : MonoBehaviour
 {
     private static GameOver instance = null;
     public static GameOver Instance

     {get{return instance;}}

        void Awake() {
            if(instance != null && instance != this){
                Destroy(this.gameObject);
                return;
            }else{
                instance = this;
            }
            DontDestroyOnLoad(this.gameObject);    
        }
 }