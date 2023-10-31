using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using CaiLu_LegendOfValmosian;

public class GressLandPointView_Ctrl: UICtrl 
 {  
 
	public override void Awake() 
	{
		base.Awake();	
	}	
	void Start() 
	{
		this.AddButtonListener("DoIt", OnDoitClick);
		this.AddButtonListener("Exit", OnExitClick);
	}

	void OnDoitClick()
	{
        InitBreakBricksGame();
        Destroy(this.gameObject);

    }

    void OnExitClick()
	{
        Destroy(this.gameObject);
    }
    public static void InitBreakBricksGame()
    {

        GameObject BreakBricksMapFrefab = ResMgr.Instance.GetMapAssets<GameObject>(AssetsType.Map, "BreakBricksMap");
        GameObject BreakBricksMap = GameObject.Instantiate(BreakBricksMapFrefab);
        BreakBricksMap.name = BreakBricksMapFrefab.name;

        Transform camera = TransformHelper.FindChild(BreakBricksMap.transform, "BreakBricksCamera");
        camera.gameObject.AddComponent<Movement>();
        camera.gameObject.AddComponent<Fire>();
        //camera.gameObject.AddComponent<Dyeing>();
        camera.gameObject.AddComponent<ScoreCheck>();

        foreach (var item in GameObject.FindGameObjectsWithTag("Bricks"))
        {
            item.gameObject.AddComponent<Dyeing>();
        }

        UIMgr.Instance.ShowUI("BreakBricksScore");

        PlayerStatus.PlayerGO.SetActive(false);
    }
}
