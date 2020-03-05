using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Movimentacao : MonoBehaviour {
    public Animator anim;
    public float speedMov;
    public float speedRot;
    private bool Run;
    private bool TurnL;
    private bool TurnR;
    private bool Equip;
    private bool Arm;
    private bool Back;
    private bool LauchBomb;
    public Transform hand;
    public GameObject bomb;

    // Use this for initialization
    void Start()
    {
        speedMov = 25.0f;
        speedRot = 80.0f;
    }

    // Update is called once per frame
    void Update()
    {

        bomb.transform.position = hand.position;
        bomb.transform.rotation = hand.rotation;
        bomb.transform.SetParent(hand);
        //verifica se está equipado
        
        if (Input.GetButton("w"))
        {
            transform.Translate(0, 0, speedMov * Time.deltaTime);
            Run = true;
            anim.SetBool("Run", Run);
        }
        else
        {
            if (Input.GetButton("s"))
            {
                transform.Translate(0, 0, -(speedMov * Time.deltaTime));
                Back = true;
                anim.SetBool("Back", Back);
            }
            else
            {
                if (Input.GetButton("a"))
                {
                    transform.Rotate(0, -speedRot * Time.deltaTime, 0);
                    TurnL = true;
                    anim.SetBool("TurnL", TurnL);
                }
                else
                {
                    if (Input.GetButton("d"))
                    {
                        transform.Rotate(0, speedRot * Time.deltaTime, 0);
                        TurnR = true;
                        anim.SetBool("TurnR", TurnR);
                    }
                    else
                    {
                        if (Input.GetButton("Fire1"))
                        {
                            LauchBomb = true;
                            anim.SetBool("LauchBomb", LauchBomb);
                        }
                        else
                        {
                            TurnL = false;
                            TurnR = false;
                            Run = false;
                            Back = false;
                            LauchBomb = false;
                            anim.SetBool("Run", Run);
                            anim.SetBool("TurnL", TurnL);
                            anim.SetBool("TurnR", TurnR);
                            anim.SetBool("Back", Back);
                            anim.SetBool("LauchBomb", LauchBomb);
                        }
                    }
                }
            }
        }
    }
}
