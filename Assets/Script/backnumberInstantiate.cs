using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using System.Linq;
using UnityEngine.Experimental.Rendering.LWRP;
using UnityEngine.SceneManagement;
public class backnumberInstantiate : MonoBehaviour {

    private int H = 10;
    private int W = 10;
    public GameObject Obj;
    private Vector2 Pos;
    public GameObject Parent;
    public GameObject PlayerPrefab;
    private GameObject Computer,dummyplayer;
    public static backnumberInstantiate insta;
    public int Number;
    public Button Spinbtn;
    
    public GameObject Dot;
    public int[] UniqueArray;
    public GameObject playerBunch,PCBunch,TotalForPlayer,TotalForPC;
    public List<int> lsendpointgenerate; 
    public List<int> UniqueArrayList;

    public bool isplayermove;

    public GameObject msgbox;
    public Sprite[] img;
    public Sprite[] playerimg;
    
    
    void Awake()
     {
    insta=this;
 

    }

    public void LSEndPointGenerate(int min ,int Max )                   //crateing list of end points of ladder and snake 
    {
        int temp= UnityEngine.Random.Range(min,Max);
        if (UniqueArrayList.Contains(temp))
        {
        LSEndPointGenerate(min ,Max);
        }else if(lsendpointgenerate.Contains(temp))
        {
            LSEndPointGenerate(min ,Max);
        }else
        {
            lsendpointgenerate.Add(temp);
            
        }





    }

	void Start () {
            isplayermove=true;
            Number=GameHolder.Ladder*2;                     //how many ladder and snake will generate
            CreatePlayer();                                             
            CreateTable();         
            UniqeRandomArray(Number, 5, 99);                //Generate Ladder and snake start point and add to this array
            UniqueArrayList=UniqueArray.ToList();           //convert array to list
            CreateLadderAndTable();                         //create ladder and snake end points
            playerBunch.transform.GetChild(1).GetComponent<Text>().text=GameHolder.Playename;           // add by defoult plyer name to scren
            PCBunch.transform.GetChild(1).GetComponent<Text>().text="PC";       //add PC name on scren
            msgbox.SetActive(false); 
         //     PCBunch.SetActive(false);
	}


    public int[] UniqeRandomArray(int size, int Min, int Max)           //creatinf uniqe and non repatable snake and laader nummber
    {
        UniqueArray = new int[size];
      System.Random rnd = new System.Random();
        int Random;
        for (int i = 0; i < size; i++)
        {
            Random = rnd.Next(Min, Max);
           for (int j = i; j >= 0; j--)
            {
                if (UniqueArray[j] == Random)
                { Random = rnd.Next(Min, Max); j = i; }
            }
            UniqueArray[i] = Random;
        }
        return UniqueArray;
    }



    public void CreateLadderAndTable()
    {      

            for (int i = 0; i < UniqueArray.Length; i++)
            {
               if (i%2==0)
                {
                        GameObject Smaple=GameObject.Find(UniqueArray[i].ToString());                               // for ladder
                        Smaple.transform.GetChild(1).GetComponent<SpriteRenderer>().color=Color.green;              // add green color for ladder indication
                        LSEndPointGenerate(UniqueArray[i] ,99);     
                        Debug.Log("LAdder"+i +"is"+ UniqueArray[i]);                                            //this number pass to end point of ladder set
              }else
              {
                         GameObject Smaple=GameObject.Find(UniqueArray[i].ToString());            
                        Smaple.transform.GetChild(1).GetComponent<SpriteRenderer>().color=Color.red;                    // for snake
                      LSEndPointGenerate(1,UniqueArray[i]);         
                      Debug.Log("snake "+i +"is"+ UniqueArray[i]); 
                }
            }

    }

    public void CreatePlayer()
    {
            BuildPlayer();
            BuildPC();

    }
    public void BuildPlayer()                                                            
    {   
        dummyplayer =Instantiate(PlayerPrefab,Vector2.zero,Quaternion.identity);                                   //instantiate player
        dummyplayer.GetComponent<SpriteRenderer>().sprite=playerimg[GameHolder.PlayerColor];                                    //add color to it
        dummyplayer.transform.localScale = new Vector3(1.3f, 1.3f,1f);                                                     //sccale 
        dummyplayer.transform.position = new Vector2(0.24f, -0.19f);                                                    //position
        dummyplayer.gameObject.tag="PLayer";                                                                        //tag
        dummyplayer.gameObject.name="PLayer";      
        playerBunch.transform.GetChild(0).GetComponent<Image>().sprite=playerimg[GameHolder.PlayerColor];                                                                 //name

    }
    public void BuildPC()
    {
        Computer =Instantiate(PlayerPrefab,Vector2.zero,Quaternion.identity);
        Computer.GetComponent<SpriteRenderer>().color=Color.yellow;
        Computer.transform.localScale = new Vector3(1.3f, 1.3f,1f);
        Computer.transform.position = new Vector2(-0.16f, -0.19f);     
        Computer.gameObject.tag="PC";
        Computer.gameObject.name="PC";
        PCBunch.transform.GetChild(0).GetComponent<Image>().sprite=playerimg[4]; 


    }



    public void CreateTable()
    {
        int t=UnityEngine.Random.Range(0,11);               //for which BG sprite will apply

        for (int i = 0; i < 10; i++)
            for (int j = 0; j < 10; j++)
            {
                
                if (i % 2 == 0)
                {
                    LeftDeal(i, j,t);
                }
                else
                {
                    RightDeal(i,j,t);
                }
 
            }
    }
    
    public void LeftDeal(int i, int j,int t)
    {
        if(i==0)
        {
        
        Pos = new Vector2(j,i);
        GameObject OBJ = Instantiate(Obj, Pos, Quaternion.identity);
        OBJ.transform.SetParent(Parent.transform);
        OBJ.gameObject.name = (j).ToString();
        OBJ.transform.GetChild(0).GetComponent<TextMeshPro>().text= (j).ToString();
        OBJ.GetComponent<SpriteRenderer>().sprite=img[t];
        OBJ.transform.localScale = new Vector2(1f, 1f);

        }else
        {
        Pos = new Vector2(j,i);
        GameObject OBJ = Instantiate(Obj, Pos, Quaternion.identity);
        OBJ.transform.SetParent(Parent.transform);
        OBJ.gameObject.name = (i + "" + j).ToString();
        OBJ.transform.GetChild(0).GetComponent<TextMeshPro>().text= (i + "" + j).ToString();
        OBJ.GetComponent<SpriteRenderer>().sprite=img[t];
        OBJ.transform.localScale = new Vector2(1f, 1f);

        }
       // Debug.Log(OBJ.name);
    }
    public void RightDeal(int i, int j,int t)
    {
        Pos = new Vector2(j,i);
        GameObject OBJ = Instantiate(Obj, Pos, Quaternion.identity);
        OBJ.transform.SetParent(Parent.transform);
        OBJ.gameObject.name = (i + "" + (9-j)).ToString();
        OBJ.transform.GetChild(0).GetComponent<TextMeshPro>().text = (i + "" + (9-j)).ToString();
        OBJ.GetComponent<SpriteRenderer>().sprite=img[t];
        OBJ.transform.localScale = new Vector2(1f, 1f);

        // Debug.Log(OBJ.name);
    }




    public void Spin()
{


        
        if (isplayermove)
        {
       
            
            isplayermove=false;

            dummyplayer.GetComponent<PlayerMove>().Spin();
            dummyplayer.GetComponent<PlayerMove>().MsgBox=msgbox;

           // PCBunch.SetActive(false);
           // playerBunch.SetActive(true);
          

          

        }else
        {
             

            isplayermove=true;
            
            Computer.GetComponent<PlayerMove>().Spin();
             Computer.GetComponent<PlayerMove>().MsgBox=msgbox;
        //    PCBunch.SetActive(true);
         //   playerBunch.SetActive(false);
     
        }



}





void Update() 
{
      TotalForPlayer.transform.GetChild(0).GetComponent<Text>().text=(dummyplayer.GetComponent<PlayerMove>().TotalStep).ToString();
         TotalForPC.transform.GetChild(0).GetComponent<Text>().text=(Computer.GetComponent<PlayerMove>().TotalStep).ToString();
         

}

public void Looby()
{

         SceneManager.LoadScene(0);
}




}
