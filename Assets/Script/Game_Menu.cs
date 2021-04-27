using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Game_Menu : MonoBehaviour
{
 public GameObject FirstPage;
 public GameObject SecondPage;
 private Color[] colorselect;
 public InputField PlayerName;
public GameObject[] Tik;

 void Start()


{
    colorselect=new Color[]{Color.red,Color.green,Color.blue};

    FirstPage.SetActive(true);
    SecondPage.SetActive(false);
 
  
}

public void SinglePlayerClick()
{    FirstPage.SetActive(false);
    SecondPage.SetActive(true);
   PlayerName.text="Aniket";
}

public void ColorSelect(int i)
{
    for (int T = 0; T < 4; T++)
     {      if (i==T)
                Tik[T].SetActive(true);
            else
                Tik[T].SetActive(false);    
     }

    GameHolder.PlayerColor=i;
    Debug.Log("Pressed");
  GameHolder.colorisSelected=true;

}



public  void Save()
    {

   
         GameHolder.Ladder  = UnityEngine.Random.Range(3, 9);
         GameHolder.Playename= PlayerName.text;

         SceneManager.LoadScene(1);
 


    }
public void quit() {
    {
      Application.Quit();
    }
}



}
