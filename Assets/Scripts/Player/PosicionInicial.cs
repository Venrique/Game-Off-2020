using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosicionInicial : MonoBehaviour
{
    public Vector3 posInicial;
   private void Start() {
       posInicial = this.transform.position;
   }
}

