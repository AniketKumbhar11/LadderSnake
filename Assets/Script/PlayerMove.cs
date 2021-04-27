using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour {

   
    public int Step, TotalStep,temptotal;
    private int deadnumber = 5;
    private Vector2 RespwanPos;
  
  
    public bool Istart;
    public static PlayerMove objplayermove;
    private Animator Aim;
    public GameObject ParticalSystem;

    private AudioSource Audio;
    public AudioClip Clip;
    public GameObject MsgBox;


    void Awake() {
        objplayermove=this;
    }

	void Start () 
    {
		Aim=GetComponent<Animator>();
  ParticalSystem.SetActive(false);
      Istart=true;
        Audio = GetComponent<AudioSource>();
        

	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Spin()
    {
        backnumberInstantiate.insta.Spinbtn. gameObject.SetActive(false);
         
        Step= UnityEngine.Random.Range(1, 6);
         GameHolder.result=Step; 
         temptotal=Step+temptotal;
       
        
         GameHolder.Isdiceplay=true;
        StartCoroutine(waiting());
        
                  
    }








        IEnumerator waiting()
        {
        yield return new WaitForSeconds(1.5f);
        if(temptotal<=99)
        StartCoroutine(StepMove());
        else
         StartCoroutine(Respine());
       

        }

     IEnumerator StepMove()
    {
     bool isdicenumberissix=false;
             if (Step==6)
            {
                isdicenumberissix=true;
            }

        for (int i = 0; i < Step; i++)
        {
          
            TotalStep++;
            if (TotalStep == 99)
            break;

          
            yield return new WaitForSeconds(0.5f);
           
            Aim.SetBool("play",true);
            Movement();
          

             
            if (i==Step-1)
            {

                for (int D = 0; D < backnumberInstantiate.insta.Number; D++)
                {
                        if ( backnumberInstantiate.insta.UniqueArrayList[D]==TotalStep)
                        {
                         yield return new WaitForSeconds(1f);

                              if (D%2==0)
                                {
                                      if (this.gameObject.tag=="PLayer")
                                      {
                                         backnumberInstantiate.insta.isplayermove=true;
                                     
                                      }
                                      else
                                      {
                                        backnumberInstantiate.insta.isplayermove=false;
                                      
                                       }
                                 
                                isdicenumberissix=true;
                                
                                 StartCoroutine(DisplayMsg("Got Ladder and Goto ",D));
                                }
 
                                else
                                {
                                  isdicenumberissix=false;
                                 Debug.Log("Snake Find");
                                 StartCoroutine(DisplayMsg("Kill By Snake and Goto ",D));

                                }
                        }
                }  
               

                if (isdicenumberissix)
                 {
                       if (this.gameObject.tag=="PLayer")
                        {
                            backnumberInstantiate.insta.isplayermove=true;
                            Debug.Log("player valeu"+backnumberInstantiate.insta.isplayermove);

                        }
                        else
                        {                            
                           backnumberInstantiate.insta.isplayermove=false;
                            Debug.Log("pc valeu"+backnumberInstantiate.insta.isplayermove);
                      
                        }
                }
                yield return new WaitForSeconds(1f);

                 StartCoroutine(Respine());




                
              
            } 
        }

    }


IEnumerator Respine()
{

                 backnumberInstantiate.insta.Spinbtn. gameObject.SetActive(true);

                 if (!backnumberInstantiate.insta.isplayermove)
                 {
                     backnumberInstantiate.insta.Spinbtn.interactable = false;
                     yield return new WaitForSeconds(1f);

                     backnumberInstantiate.insta.Spin();
                 //   backnumberInstantiate.insta.playerBunch.SetActive(false);
                  //   backnumberInstantiate.insta.PCBunch.SetActive(true);

                 }
                 else
                 {  
                     backnumberInstantiate.insta.Spinbtn.interactable = true;
                       yield return new WaitForSeconds(1f);
                   //  backnumberInstantiate.insta.playerBunch.SetActive(true);
                  //   backnumberInstantiate.insta.PCBunch.SetActive(false);
                     
                 }
}

    private void Respwan( int Chanel)
    {

        if (this.gameObject.tag=="PLayer")
        {
           
          int tableNumber=backnumberInstantiate.insta.lsendpointgenerate[Chanel];
            GameObject obj = GameObject.Find(tableNumber.ToString());
            Vector3 pos = new Vector3(obj.transform.position.x, obj.transform.position.y - 0.2f, obj.transform.position.z);

          transform.position=pos;
         
         temptotal= TotalStep=tableNumber;
        }
        else
        {

    
          int tableNumber=backnumberInstantiate.insta.lsendpointgenerate[Chanel];
             GameObject obj = GameObject.Find(tableNumber.ToString());
            Vector3 pos = new Vector3(obj.transform.position.x, obj.transform.position.y +0.2f, obj.transform.position.z);
          transform.position=pos;
          
        temptotal=  TotalStep=tableNumber;
        }






    }


    IEnumerator DisplayMsg(string msg, int t)
    {
        MsgBox.SetActive(true);
        MsgBox.transform.GetChild(0).GetComponent<Text>().text=this.gameObject.name+" "+msg+ backnumberInstantiate.insta.lsendpointgenerate[t].ToString();


        yield return new WaitForSeconds(2f);
        MsgBox.SetActive(false);
             yield return new WaitForSeconds(2f);
         Respwan(t);

    }




    private void Movement()
    {
         
             
          Audio.PlayOneShot(Clip);
        if (TotalStep > 0 && TotalStep < 10)
        {
            transform.position += Vector3.right * 1;
           
        }

        else if (TotalStep == 10)
            transform.position += Vector3.up * 1;


        else if (TotalStep > 10 && TotalStep < 20)
            transform.position -= Vector3.right * 1;
        else if (TotalStep == 20)
        transform.position += Vector3.up * 1;


        else if (TotalStep > 20 && TotalStep < 30)
            transform.position += Vector3.right * 1;
        else if (TotalStep == 30)
            transform.position += Vector3.up * 1;


        else if (TotalStep > 30 && TotalStep < 40)
            transform.position -= Vector3.right * 1;
        else if (TotalStep == 40)
            transform.position += Vector3.up * 1;

        else if (TotalStep > 40 && TotalStep < 50)
            transform.position += Vector3.right * 1;
        else if (TotalStep == 50)
           transform.position += Vector3.up * 1;


        else if (TotalStep > 50 && TotalStep < 60)
            transform.position -= Vector3.right * 1;
        else if (TotalStep == 60)
            transform.position += Vector3.up * 1;



        else if (TotalStep > 60 && TotalStep < 70)
           transform.position += Vector3.right * 1;
        else if (TotalStep == 70)
           transform.position += Vector3.up * 1;


        else if (TotalStep > 70 && TotalStep < 80)
            transform.position -= Vector3.right * 1;
        else if (TotalStep == 80)
            transform.position += Vector3.up * 1;


        else if (TotalStep > 80 && TotalStep < 90)
            transform.position += Vector3.right * 1;
        else if (TotalStep == 90)
            transform.position += Vector3.up * 1;


        else if (TotalStep > 90 && TotalStep < 99)
           transform.position -= Vector3.right * 1;
        else if (TotalStep == 99)
        {
            
            transform.position -= Vector3.right * 1;
       
                StartCoroutine(DisplayMsg(this.gameObject.name+"Won the game",0));
                 
        }

  
    }
           
    

}

    

