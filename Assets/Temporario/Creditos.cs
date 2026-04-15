using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Creditos : MonoBehaviour{

    public float RodaRoda= 100f;
    public SpriteRenderer Sprite;
    public Transform Nada;
    public Transform Aver;
    
    void Update(){
        if (Nada != null)
            Nada.Rotate(0, 0, RodaRoda * Time.deltaTime);

        if (Aver != null)
            Sprite.flipX = true;
            Aver.Rotate(0, 0, -RodaRoda * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Return)){
            SceneManager.LoadScene("Menu");
        }
    }
}