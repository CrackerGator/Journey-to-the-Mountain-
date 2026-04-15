using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class Caixa_Dialogo : MonoBehaviour{

    [System.Serializable]
    public class FalaDialogo{
        [TextArea(2, 4)]
        public string Texto;
        public Sprite ImagemPersonagem;
        public string NomePersonagem;
        public bool Jogador;
        public Font Fonte;
        public AudioClip Som;
    }

    [Header("UI")]
    public Text TextoUI;
    public Image ImagemUI;
    public Text NomeUI;
    private AudioSource Audio;

    [Header("Configurações")]
    public List<FalaDialogo> ListaFalas;
    public float Velocidade = 0.03f;
    private int Indice;
    public static bool Ativa = false;
    private Jogador J;

    public void Awake(){
        Audio = GetComponent<AudioSource>();
        J = GameObject.FindWithTag("Jogador").GetComponent<Jogador>();
    }

    private void OnEnable(){
        Indice = 0;
        StartCoroutine(Sequencia());
    }

    private IEnumerator Sequencia(){
        Ativa = true;
        J.enabled = false;

        while(Indice < ListaFalas.Count){
            FalaDialogo F = ListaFalas[Indice];

            ImagemUI.sprite = F.ImagemPersonagem;

            if(F.Jogador == true){
                NomeUI.text = Geral.Instancia.NomeJogador;
            }
            else
            NomeUI.text = F.NomePersonagem;

            yield return StartCoroutine(EscreverLinha(F.Texto));
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Q));

            Indice++;
        }
        
        Ativa = false;
        J.enabled = true;
        
        gameObject.SetActive(false);
    }

    private IEnumerator EscreverLinha(string Texto){
        FalaDialogo F = ListaFalas[Indice];

        TextoUI.text = "";

        Texto = Texto.Replace("{Nome}", Geral.Instancia.NomeJogador);
        
        foreach (char Letra in Texto){
            TextoUI.text += Letra;
            Audio.PlayOneShot(F.Som);
            yield return new WaitForSeconds(Velocidade);

            if (Input.GetKeyDown(KeyCode.Q)){
                TextoUI.text = Texto;
                break;
            }
        }
    }
}