using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Cutscenes : MonoBehaviour{
    public Image Imagem; 
    public Sprite[] Quadros;
    public string ProximaFase;

    public CanvasGroup canvasGroup;
    public float VelocidadeFade = 2f;

    private int i = 0;
    private bool Fading = false;

    void Start(){
        MostrarQuadro();

    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.Return) && !Fading){
            StartCoroutine(ProximoQuadro());
        }
    }

    void MostrarQuadro(){
        Imagem.sprite = Quadros[i];
    }

    IEnumerator ProximoQuadro(){
        Fading = true;
        yield return StartCoroutine(FadeOut());

        i++;

        if (i >= Quadros.Length){
            SceneManager.LoadScene(ProximaFase);
            yield break;
        }

        MostrarQuadro();

        yield return StartCoroutine(FadeIn());
        Fading = false;
    }

    IEnumerator FadeIn(){
        while(canvasGroup.alpha < 1){
            canvasGroup.alpha += Time.deltaTime * VelocidadeFade;
            yield return null;
        }
        canvasGroup.alpha = 1;
    }
    IEnumerator FadeOut(){
        while (canvasGroup.alpha > 0){
            canvasGroup.alpha -= Time.deltaTime * VelocidadeFade;
            yield return null;
        }
        canvasGroup.alpha = 0;
    }
}