using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.WSA;

public class Clickable : MonoBehaviour
{
    [Header("Depency:")]
    [SerializeField] private Resources resources;
    [SerializeField] private FlyingCoinCreator creator;

    [SerializeField] private AnimationCurve _scaleCurve;
    [SerializeField] private float _scaleTime = 0.25f;
    [SerializeField] private GameObject miniCube;
    [SerializeField] private List<Vector3> ForceDirections;

    // Метод вызывается из Interaction при клике на объект
    public void Hit()
    {
        StartCoroutine(HitAnimation());
        
        CreateMiniCubs();
    }

    // Анимация колебания куба
    private IEnumerator HitAnimation()
    {
        for (float t = 0; t < 1f; t += Time.deltaTime / _scaleTime)
        {
            float scale = _scaleCurve.Evaluate(t);
            transform.localScale = Vector3.one * scale;
            yield return null;
        }
        transform.localScale = Vector3.one;
    }

    private void CreateMiniCubs()
    {
        foreach(Vector3 v in ForceDirections)
        {
            GameObject cube = Instantiate(miniCube);
            LaunchAndReaction ret = cube.GetComponent<LaunchAndReaction>();
            ret.Init(creator, resources);
            ret.Launch(v);
        }
    }
}
