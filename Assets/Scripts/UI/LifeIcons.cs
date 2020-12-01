using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeIcons : MonoBehaviour
{
    public GameObject[] lifeIcons;
    public int lastHp;
    public int lastMaxHp;

    // Start is called before the first frame update
    void Start()
    {
        for (int i=0; i<lifeIcons.Length; i++){
            lifeIcons[i].SetActive(false);
            lifeIcons[i].GetComponent<Animator>().SetBool("active", false);
            lifeIcons[i].GetComponent<Animator>().SetBool("lost", true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateLifeIcons(int maxHp, int currentHp){
        if (maxHp != lastMaxHp || currentHp != lastHp){
            for (int i=0; i<lifeIcons.Length; i++){
                if (i >= maxHp){
                    lifeIcons[i].SetActive(false);
                } else {
                    lifeIcons[i].SetActive(true);
                    if (i+1 == currentHp){
                        lifeIcons[i].GetComponent<Animator>().SetBool("active", true);
                        lifeIcons[i].GetComponent<Animator>().SetBool("lost", false);
                    } else if (i+1 < currentHp){
                        lifeIcons[i].GetComponent<Animator>().SetBool("active", false);
                        lifeIcons[i].GetComponent<Animator>().SetBool("lost", false);
                    } else {
                        lifeIcons[i].GetComponent<Animator>().SetBool("active", false);
                        lifeIcons[i].GetComponent<Animator>().SetBool("lost", true);
                    }
                }
            }
        }
        lastHp = currentHp;
        lastMaxHp = maxHp;
    }
}
