using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WorldCamera : MonoSingleton<WorldCamera>
{
    Vector3 defaultPosition;
    public Vector3 shakeVector;
    private void Start() {
        defaultPosition = this.transform.position;
    }
    private void LateUpdate() {
        this.transform.position = defaultPosition + shakeVector;
    }
    Coroutine shake;
    public void Shake()
    {
        if(shake != null)
        {
            StopCoroutine(shake);
        }
        shake = StartCoroutine(Shaking());
    }
    IEnumerator Shaking()
    {
        float force = Random.Range(0.8f, 1.4f);
        while(force > 0)
        {
            force -= 0.2f;
            shakeVector = force * Random.onUnitSphere * 0.1f;
            yield return new WaitForFixedUpdate();

        }
        shake = null;
    }
}