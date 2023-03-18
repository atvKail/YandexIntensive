using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchAndReaction : MonoBehaviour
{
    private Resources res;
    private FlyingCoinCreator creator;

    public void Launch(Vector3 direction)
    {
        GetComponent<Rigidbody>().AddForce(direction);
    }

    public void Init(FlyingCoinCreator cr, Resources res)
    {
        creator = cr;
        this.res = res;
    }

    public void Hit()
    {
        creator.CreateFlyingCoin(transform.position);
        res.CollectCoins(1, transform.position);
        Destroy(gameObject);
    }
}
