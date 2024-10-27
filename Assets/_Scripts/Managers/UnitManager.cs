using Assets.HeroEditor4D.Common.Scripts.Enums;
using Assets.HeroEditor4D.Common.Scripts.ExampleScripts;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public static UnitManager Instance;

    private List<ScriptableUnit> _units;
    private void Awake()
    {
        Instance = this;
        _units = Resources.LoadAll<ScriptableUnit>("units").ToList();   
    }


    public void spawnHeroes()
    {

        var humanCount = 4;

        for(int i= 0; i < humanCount; i++)
        {
            var randomPrefab = GetRandomUnit<BaseHuman>(Faction.Human);
            var spawnedHuman = Instantiate(randomPrefab);

            var a = spawnedHuman.GetComponent<ControlsExample>();
            a.Character.AnimationManager.SetState(CharacterState.Run);
            spawnedHuman.transform.position = new Vector3(0.5f+i-2, 0.3f-2, 0);
            spawnedHuman.transform.localScale = new Vector3(0.5f,0.5f,0.5f);
        }

    }

    private T GetRandomUnit<T>(Faction faction) where T: BaseUnit
    {
        return (T)_units.Where(u => u.Faction == faction).OrderBy(o => Random.value).First().UnitPrefab;

    }
    
 
}
