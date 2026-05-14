using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Perguntar_Nome : MonoBehaviour{
    public GameObject Dialogo1;
    public GameObject Dialogo2;
    public GameObject InputNome;
    public GameObject Dialogo3;
    public GameObject UltimoDialogo;
    public bool Perto;
    public bool EmSequencia;
    public int i = 0;

    private Jogador J;

     private void Awake(){
        J = GameObject.FindWithTag("Jogador").GetComponent<Jogador>();
    }

    private void Update(){
        if (Perto && !EmSequencia && Input.GetKeyDown(KeyCode.Return) && !Caixa_Dialogo.Ativa){
            Interagir();
        }
    }

    public void Interagir(){
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

    private void OnTriggerEnter2D(Collider2D collider){
        if (collider.CompareTag("Jogador")){Perto = true;}
    }
    private void OnTriggerExit2D(Collider2D collider){
        if (collider.CompareTag("Jogador")){Perto = false;}
    }
}