using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NoteModel : MonoBehaviour
{
    float speed = 5f;
    private void Update()
    {
        this.transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.Self);    
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