using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GloveManager 
{

    IStone mainStone;
    IStone secondaryStone;
    IStone additionalStone;

    public void getMainStone(Stone stone)
    {
        this.mainStone = stone;
    }
    public void getSecondaryStone(Stone stone)
    {
        this.secondaryStone = stone;
    }
    public void getaAdditionalStone(Stone stone)
    {
        this.additionalStone = stone;
    }
    


}
public interface IStone
{
    void display(out string n, out Sprite image);
    void effects();
}

[CreateAssetMenu(fileName = "Stone", menuName = "Scriptable Object/New Store")]
public class Stone : ScriptableObject, IStone
{
    [SerializeField]
    private string name;
    [SerializeField]
    private Sprite Icon;
    public Color color;


    public void display(out string n, out Sprite image)
    {
        n = name;
        image = Icon;
    }

    public void effects()
    {
        
    }
}
