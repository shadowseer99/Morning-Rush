using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class expressobar : MonoBehaviour {

    private exvessel activecup;
    public GameObject display;
    private Image cup;
    public GameObject ticket;
    private Text ticker;
    public Sprite ecold;
    public Sprite ocold;
    public Sprite tcold;
    public Sprite thcold;
    public Sprite fcold;
    public Sprite hot;

    public AudioClip cupSound;
    public AudioClip pouringSound;
    AudioSource sound;

    void Start()
    {
        sound = GetComponent<AudioSource>();
        cup = display.GetComponent<Image>();
        ticker = ticket.GetComponent<Text>();
    }
	public void newcold(int size)
    {
        activecup = new coldcup();
        activecup.size = size;
        cup.sprite=ecold;
        cup.color = Color.white;
        cup.preserveAspect = true;

        sound.PlayOneShot(cupSound, 1);
    }

    public void newhot(int size)
    {
        activecup = new hotcup();
        activecup.size = size;
        cup.sprite = hot;
        cup.color = Color.white;
        cup.preserveAspect = true;

        sound.PlayOneShot(cupSound, 1);
    }
    public void addSyrup(int type)
    {
        if (!activecup.fail)
        {
            if(activecup.shots!=-1|| activecup.basefluid != -1 || activecup.finish != -1 )
            {
                activecup.fail = true;
                cup.color = Color.red;
            }
            else
            {
                if(activecup is coldcup)
                {
                    cup.sprite = ocold;
                    cup.preserveAspect = true;
                }
                activecup.syrup.Add(type);
            }
            
        }
    }
    public void expresso(int number)
    {
        
        if (!activecup.fail)
        {
            if (activecup.shots != -1 || activecup.basefluid != -1 || activecup.finish != -1)
            {
                activecup.fail = true;
                cup.color = Color.red;

            }
            else
            {
                activecup.shots = number;
                if (activecup is coldcup)
                {
                    cup.sprite = tcold;
                    cup.preserveAspect = true;
                }

                sound.PlayOneShot(pouringSound, 1);
            }
        }
    }
    public void mixbase(int type)
    {
        if (!activecup.fail)
        {
            if ( activecup.basefluid != -1 || activecup.finish != -1)
            {
                activecup.fail = true;
                cup.color = Color.red;

            }
            else
            {
                if (activecup is coldcup && type == 1)
                {
                    activecup.basefluid = type;
                    if (activecup is coldcup)
                    {
                        cup.sprite = thcold;
                        cup.preserveAspect = true;
                    }
                }
                else if (activecup is hotcup && type == 2)
                {
                    activecup.basefluid = type;
                }
                else
                {
                    cup.color = Color.red;
                    activecup.fail = true;
                }
            }
        }
    }
    public void addfinish(int type)
    {
        if (!activecup.fail)
        {
            if (activecup.basefluid == -1 || activecup.finish != -1)
            {
                activecup.fail = true;
                cup.color = Color.red;

            }
            else
            {
                if(activecup is coldcup&&type==2)
                {
                    activecup.finish = type;
                    if (activecup is coldcup)
                    {
                        cup.sprite = fcold;
                        cup.preserveAspect = true;
                    }
                }
                else if(activecup is hotcup&&type==1)
                {
                    activecup.finish = type;
                }
                else
                {
                    cup.color = Color.red;
                    activecup.fail = true;
                }
            }
        }
    }
    public bool orderup(string order)
    {
        if (activecup == null)
        {
            //return false;
        }
        //ticker.text = "test";
        if (!activecup.fail)
        {
            //ticker.text = "test";
            if (activecup.shots>0)
            {
                //ticker.text = "test";
                bool mocha = true;
                bool whitemocha = true;
                bool latte = true;
                int count = 0;
                foreach(int a in activecup.syrup)
                {
                    //ticker.text = "test";
                    count++;
                    if(a!=1)
                    {
                        mocha = false;
                    }
                    if (a != 2)
                    {
                        whitemocha = false;
                    }
                    if (a != 3)
                    {
                        latte = false;
                    }

                }
                if(mocha &&activecup.basefluid!=-1&&activecup.finish!=-1)
                {
                    if(activecup is coldcup)
                    {
                        if(activecup.shots==activecup.size)
                        {
                            if (activecup.size == 1&&count==3)
                            {
                                ticker.text = "Tall Iced Mocha";
                            }
                            else if (activecup.size == 2 && count == 4)
                            {
                                ticker.text = "Grande Iced Mocha";
                            }
                            else if (activecup.size == 3 && count == 6)
                            {
                                ticker.text = "Venti Iced Mocha";
                            }
                            else
                            {
                                activecup = null;
                                cup.color = Color.white;
                                return false;
                            }
                            activecup = null;
                            cup.color = Color.white;
                            if (order == ticker.text)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            activecup = null;
                            cup.color = Color.white;
                            return false;
                        }
                    }
                    else if(activecup.size+2==count)
                    {
                        if(activecup.size==1&&activecup.shots==1)
                        {
                            ticker.text = "Tall Mocha";
                        }else if (activecup.size == 2 && activecup.shots == 2)
                        {
                            ticker.text = "Grande Mocha";
                        }
                        else if (activecup.size == 3 && activecup.shots == 2)
                        {
                            ticker.text = "Venti Mocha";
                        }
                        activecup = null;
                        cup.color = Color.white;
                        if (order == ticker.text)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        activecup = null;
                        cup.color = Color.white;
                        return false;
                    }
                }
                else if (whitemocha && activecup.basefluid != -1 && activecup.finish != -1)
                {
                    if (activecup is coldcup)
                    {
                        if (activecup.shots == activecup.size)
                        {
                            if (activecup.size == 1 && count == 3)
                            {
                                ticker.text = "Tall Iced White Chocolate Mocha";
                            }
                            else if (activecup.size == 2 && count == 4)
                            {
                                ticker.text = "Grande Iced White Chocolate Mocha";
                            }
                            else if (activecup.size == 3 && count == 6)
                            {
                                ticker.text = "Venti Iced White Chocolate Mocha";
                            }
                            else
                            {
                                activecup = null;
                                cup.color = Color.white;
                                return false;
                            }
                            activecup = null;
                            cup.color = Color.white;
                            if (order == ticker.text)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            activecup = null;
                            cup.color = Color.white;
                            return false;
                        }
                    }
                    else if(activecup.size + 2 == count)
                    {
                        if (activecup.size == 1 && activecup.shots == 1)
                        {
                            ticker.text = "Tall White Chocolate Mocha";
                        }
                        else if (activecup.size == 2 && activecup.shots == 2)
                        {
                            ticker.text = "Grande White Chocolate Mocha";
                        }
                        else if (activecup.size == 3 && activecup.shots == 2)
                        {
                            ticker.text = "Venti White Chocolate Mocha";
                        }
                        activecup = null;
                        cup.color = Color.white;
                        if (order == ticker.text)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        activecup = null;
                        cup.color = Color.white;
                        return false;
                    }
                }//order types
                else if (latte && activecup.basefluid != -1 && activecup.finish != -1)
                {
                    if (activecup is coldcup)
                    {
                        if (activecup.shots == activecup.size)
                        {
                            if (activecup.size == 1 && count == 3)
                            {
                                ticker.text = "Tall Iced Vanilla Latte";
                            }
                            else if (activecup.size == 2 && count == 4)
                            {
                                ticker.text = "Grande Iced Vanilla Latte";
                            }
                            else if (activecup.size == 3 && count == 6)
                            {
                                ticker.text = "Venti Iced Vanilla Latte";
                            }
                            else
                            {
                                activecup = null;
                                cup.color = Color.white;
                                return false;
                            }
                            activecup = null;
                            cup.color = Color.white;
                            if (order == ticker.text)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            activecup = null;
                            cup.color = Color.white;
                            return false;
                        }
                    }
                    else if (activecup.size + 2 == count)
                    {
                        if (activecup.size == 1 && activecup.shots == 1)
                        {
                            ticker.text = "Tall Vanilla Latte";
                        }
                        else if (activecup.size == 2 && activecup.shots == 2)
                        {
                            ticker.text = "Grande Vanilla Latte";
                        }
                        else if (activecup.size == 3 && activecup.shots == 2)
                        {
                            ticker.text = "Venti Vanilla Latte";
                        }
                        activecup = null;
                        cup.color = Color.white;
                        if (order == ticker.text)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        activecup = null;
                        cup.color = Color.white;
                        return false;
                    }
                }
                else
                {
                    ticker.text = "Trashed";
                    activecup = null;
                    cup.color = Color.white;
                    return false;
                }
                //
            }//noshots
            else if(activecup.shots==-1)
            {
                int moch = 0;
                int vanilla=0;
                bool hchocolat = true;
                foreach (int a in activecup.syrup)
                {
                    //ticker.text = "test";
                    if (a == 1)
                    {
                        moch++;
                    }
                    else if (a == 3)
                    {
                        vanilla++;
                    }
                    else
                    {
                        hchocolat = false;
                    }

                }
                if(hchocolat&& activecup.size+2 == moch  && activecup.basefluid != -1 && activecup.finish != -1)
                {
                    if (activecup.size == 1&&vanilla==1)
                    {
                        ticker.text = "Tall Hot Chocolate";
                    }
                    else if (activecup.size == 2 && vanilla == 1)
                    {
                        ticker.text = "Grande Hot Chocolate";
                    }
                    else if (activecup.size == 3 && vanilla == 2)
                    {
                        ticker.text = "Venti Hot Chocolate";
                    }
                    activecup = null;
                    cup.color = Color.white;
                    if (order == ticker.text)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    ticker.text = "Trashed";
                    activecup = null;
                    cup.color = Color.white;
                    return false;
                }
            }
            else
            {
                ticker.text = "Trashed";
                activecup = null;
                cup.color = Color.white;
                return false;
            }
            //
        }
        else
        {
            ticker.text = "Trashed";
            activecup = null;
            cup.color = Color.white;
            return false;
        }
        //
    }
    public void clearTicker()
    {
        ticker.text = "";
    } 

}
