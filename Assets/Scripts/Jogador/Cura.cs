using UnityEngine;
using Unity.Mathematics;
using Unity.VisualScripting;
using System;

public class Cura : MonoBehaviour{

    private void OnTriggerEnter2D(Collider2D collider){
        Jogador J = collider.GetComponent<Jogador>();
        
        if(J != null  && J.Vida < J.VidaTotal){
            J.Vida++;
            Destroy(gameObject);
        }
        else
        return;
    }
}
