using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BarrierColorScript : MonoBehaviour
{
    [SerializeField]
    public Material BarrierP1Material;
    public Material BarrierP2Material;

    public Color Player1Barriers;
    public Color Player2Barriers;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    #region Player1Colors
    public void P1ColorRed()
    {
        Player1Barriers = Color.red;
        BarrierP1Material.color = Player1Barriers;
    }
    public void P1ColorGreen()
    {
        Player1Barriers = Color.green;
        BarrierP1Material.color = Player1Barriers;
    }
    public void P1ColorBlue()
    {
        Player1Barriers = Color.blue;
        BarrierP1Material.color = Player1Barriers;
    }
    public void P1ColorCyan()
    {
        Player1Barriers = Color.cyan;
        BarrierP1Material.color = Player1Barriers;
    }
    public void P1ColorYellow()
    {
        Player1Barriers = Color.yellow;
        BarrierP1Material.color = Player1Barriers;
    }
    public void P1ColorMagenta()
    {
        Player1Barriers = Color.magenta;
        BarrierP1Material.color = Player1Barriers;
    }
    public void P1ColorBlack()
    {
        Player1Barriers = Color.black;
        BarrierP1Material.color = Player1Barriers;
    }

    public void P1ColorWhite()
    {
        Player1Barriers = Color.white;
        BarrierP1Material.color = Player1Barriers;
    }
    #endregion

    #region Player2Colors
    public void P2ColorRed()
    {
        Player2Barriers = Color.red;
        BarrierP2Material.color = Player2Barriers;
    }
    public void P2ColorGreen()
    {
        Player2Barriers = Color.green;
        BarrierP2Material.color = Player2Barriers;
    }
    public void P2ColorBlue()
    {
        Player2Barriers = Color.blue;
        BarrierP2Material.color = Player2Barriers;
    }
    public void P2ColorCyan()
    {
        Player2Barriers = Color.cyan;
        BarrierP2Material.color = Player2Barriers;
    }
    public void P2ColorYellow()
    {
        Player2Barriers = Color.yellow;
        BarrierP2Material.color = Player2Barriers;
    }
    public void P2ColorMagenta()
    {
        Player2Barriers = Color.magenta;
        BarrierP2Material.color = Player2Barriers;
    }

    public void P2ColorBlack()
    {
        Player2Barriers = Color.black;
        BarrierP2Material.color = Player2Barriers;
    }

    public void P2ColorWhite()
    {
        Player2Barriers = Color.white;
        BarrierP2Material.color = Player2Barriers;
    }
    #endregion

}
