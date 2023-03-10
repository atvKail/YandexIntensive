using UnityEngine;

public class ShipPresenter : Presenter
{
    private Root _init;

    public void Init(Root init)
    {
        _init = init;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (_init.Ship.lifes > 0)
            {
                _init.Ship.lifes--;
            }
            if (_init.Ship.lifes == 0)
            {
                _init.Ship.Destroy();
            }
        }
    }
}
