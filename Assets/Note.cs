using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Note : MonoBehaviour
{
    float speed = 1f;
    private void Update()
    {
        this.transform.Translate(Vector3.forward * Time.deltaTime, Space.Self);    
    }
    #region Member Variables
    #endregion
    #region Properties
    #endregion
    #region Public Methods
    #endregion
    #region Protected Methods
    #endregion
    #region Private Methods
    #endregion
}