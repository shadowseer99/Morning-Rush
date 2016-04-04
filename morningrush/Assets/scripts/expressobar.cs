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
    void Start()
    {
        cup = display.GetComponent<Image>();
        ticker = ticket.GetComponent<Text>();
    }
	public void newcold()
    {
        activecup = new coldcup();
        activecup.size = 3;
        cup.sprite=ecold;
        cup.color = Color.white;
        cup.preserveAspect = true;
    }

    public void newhot(int size)
    {
        activecup = new hotcup();
        activecup.size = size;
        cup.sprite = hot;
        cup.color = Color.white;
        cup.preserveAspect = true;
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
            return false;
        }
        //ticker.text = "test";
        if (!activecup.fail)
        {
            //ticker.text = "test";
            if (activecup.size==activecup.shots)
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
                if(activecup.size == count&&mocha &&activecup.basefluid!=-1&&activecup.finish!=-1)
                {
                    if(activecup is coldcup)
                    {
                        ticker.text = "Iced Mocha";
                        activecup = null;
                        cup.color = Color.white;
                        if(order==ticker.text)
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
                        if(activecup.size==1)
                        {
                            ticker.text = "Tall Mocha";
                        }else if (activecup.size == 2)
                        {
                            ticker.text = "Grande Mocha";
                        }
                        else if (activecup.size == 3)
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
                }
                else if (activecup.size == count && whitemocha && activecup.basefluid != -1 && activecup.finish != -1)
                {
                    if (activecup is coldcup)
                    {
                        ticker.text = "Iced White Chocolate Mocha";
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
                        if (activecup.size == 1)
                        {
                            ticker.text = "Tall White Chocolate Mocha";
                        }
                        else if (activecup.size == 2)
                        {
                            ticker.text = "Grande White Chocolate Mocha";
                        }
                        else if (activecup.size == 3)
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
                }//order types
                else if (activecup.size == count && latte && activecup.basefluid != -1 && activecup.finish != -1)
                {
                    if (activecup is coldcup)
                    {
                        ticker.text = "Iced Vanilla Latte";
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
                        if (activecup.size == 1)
                        {
                            ticker.text = "Tall Vanilla Latte";
                        }
                        else if (activecup.size == 2)
                        {
                            ticker.text = "Grande Vanilla Latte";
                        }
                        else if (activecup.size == 3)
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
            else if(activecup.shots==0)
            {
                int moch = 0;
                int vanilla=0;
                bool hchocolat = true;
                foreach (int a in activecup.syrup)
                {
                    //ticker.text = "test";
                    if (a != 1)
                    {
                        moch++;
                    }
                    else if (a != 3)
                    {
                        vanilla++;
                    }
                    else
                    {
                        hchocolat = false;
                    }

                }
                if(hchocolat&& activecup.size == moch && activecup.size == vanilla && activecup.basefluid != -1 && activecup.finish != -1)
                {
                    if (activecup.size == 1)
                    {
                        ticker.text = "Tall Hot Chocolate";
                    }
                    else if (activecup.size == 2)
                    {
                        ticker.text = "Grande Hot Chocolate";
                    }
                    else if (activecup.size == 3)
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
