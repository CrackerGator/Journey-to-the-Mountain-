using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Perguntar_Nome : Interagir{
    public GameObject Dialogo1;
    public GameObject Dialogo2;
    public GameObject InputNome;
    public GameObject Dialogo3;
    public GameObject Dialogo4;
    public GameObject UltimoDialogo;
    public bool EmSequencia;
    public int i = 0;

    private Jogador J;

     private void Awake(){
        J = GameObject.FindWithTag("Jogador").GetComponent<Jogador>();
    }

    public override void Interagir1(){
        switch (i){
            case 0:
                Dialogo1.SetActive(true);
                i++;
            break;

            case 1:
                EmSequencia = true;
                J.enabled = false;
                
                StartCoroutine(Nome());
            break;

            case 2: 
                Dialogo4.SetActive(true);
                i++;
            break;

            case 3: 
                UltimoDialogo.SetActive(true);
            break;       
        }
    }

    private IEnumerator Nome(){
        Dialogo2.SetActive(true);
        yield return new WaitUntil(() => !Caixa_Dialogo.Ativa);
        
        J.enabled = false;
        
        InputNome.SetActive(true);
        yield return new WaitUntil(() => UI_Nome.Confirmado);

        Dialogo3.SetActive(true);
        yield return new WaitUntil(() => !Caixa_Dialogo.Ativa);

        i++;

        EmSequencia = false;
        J.enabled = true;
    }
}