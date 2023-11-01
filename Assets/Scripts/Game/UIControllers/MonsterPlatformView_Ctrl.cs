using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using CaiLu_LegendOfValmosian;

public class MonsterPlatformView_Ctrl: UICtrl 
 {
    public static float BeforeCharHealth;
 
	public override void Awake() 
	{
		base.Awake();	
	}
    void Start()
    {
        BeforeCharHealth = TransformHelper.FindChild(UIMgr.canvas, "HealthBar").GetComponent<Slider>().value;

        this.AddButtonListener("DoIt", OnDoitClick);
        this.AddButtonListener("Exit", OnExitClick);
    }

    void OnDoitClick()
    {
        InitShootingGame();
        Destroy(this.gameObject);

    }

    void OnExitClick()
    {
        Destroy(this.gameObject);
    }

    public static void InitShootingGame()
    {
        GameObject ShootingGameMapFrefab = ResMgr.Instance.GetMapAssets<GameObject>(AssetsType.Map, "ShootingGameMap");
        GameObject ShootingGameMap = GameObject.Instantiate(ShootingGameMapFrefab);
        ShootingGameMap.name = ShootingGameMapFrefab.name;

        Transform camera = TransformHelper.FindChild(ShootingGameMap.transform, "ShootingGameCamera");
        camera.gameObject.AddComponent<FollowTarget>();
        //camera.gameObject.AddComponent<ScoreCheck1>();

        Transform player = TransformHelper.FindChild(ShootingGameMap.transform, "Player");
        player.gameObject.AddComponent<PlayerController>();
        player.gameObject.AddComponent<ScoreCheck1>();


        Transform Gun = TransformHelper.FindChild(player, "Gun");
        Gun.gameObject.AddComponent<GunController>();

        foreach (var item in GameObject.FindGameObjectsWithTag("Spawner"))
        {
            item.gameObject.AddComponent<Spawner>();
        }

        //UIMgr.Instance.ShowUI("ShootingGameHealth");

        PlayerStatus.PlayerGO.SetActive(false);
    }
}
