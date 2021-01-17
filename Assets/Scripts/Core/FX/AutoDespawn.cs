using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathologicalGames;
public class AutoDespawn : MonoBehaviour
{
    #region Inspector

    public float delay = 1f;
    public string poolKey;

    #endregion


    #region Properties
    public void OnSpawned()
    {
        if(GameMain.Instance == null) return;
        if(delay != 0f && poolKey != string.Empty)
        StartCoroutine(Despawn());
    }
    public IEnumerator Despawn()
    {
        yield return new WaitForSeconds(delay);
        PoolManager.Pools[poolKey].Despawn(this.transform);
    }

    #endregion


    #region Member

    #endregion


    #region Public Method

    #endregion


    #region Protected Method

    #endregion


    #region Private Method

    #endregion


}