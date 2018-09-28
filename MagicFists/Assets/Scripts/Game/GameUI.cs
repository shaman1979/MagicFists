using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public static GameUI UIManager;
    [SerializeField]
    public UIStoneElement mainStone;
    [SerializeField]
    public UIStoneElement secondutyStone;
    [SerializeField]
    public UIStoneElement additionalStone;
    private void Awake()
    {
        UIManager = this;
    }
    public void Restart(int level)
    {
        SceneManager.LoadScene(level);
    }
    public void Start()
    {
        ActiveAddStonePanels(false);
    }
    public void ActiveAddStonePanels(bool flag)
    {
        mainStone.ActiveAddStonePanel(flag);
        secondutyStone.ActiveAddStonePanel(flag);
        additionalStone.ActiveAddStonePanel(flag);
    }
}
