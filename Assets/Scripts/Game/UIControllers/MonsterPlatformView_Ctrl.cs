using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using CaiLu_LegendOfValmosian;

public class MonsterPlatformView_Ctrl: UICtrl 
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

    void InitBreakBricksGame()
    {
        GameObject ShootingGameMapFrefab = ResMgr.Instance.GetMapAssets<GameObject>(AssetsType.Map, "ShootingGameMap");
        GameObject ShootingGameMap = GameObject.Instantiate(ShootingGameMapFrefab);
        ShootingGameMap.name = ShootingGameMapFrefab.name;

        Transform camera = TransformHelper.FindChild(ShootingGameMap.transform, "ShootingGameCamera");
        //camera.gameObject.AddComponent<Movement>();
        //camera.gameObject.AddComponent<Fire>();
        ////camera.gameObject.AddComponent<Dyeing>();
        //camera.gameObject.AddComponent<ScoreCheck>();

        //foreach (var item in GameObject.FindGameObjectsWithTag("Bricks"))
        //{
        //    item.gameObject.AddComponent<Dyeing>();
        //}

        //UIMgr.Instance.ShowUI("BreakBricksScore");

        PlayerStatus.PlayerGO.SetActive(false);
    }
}
