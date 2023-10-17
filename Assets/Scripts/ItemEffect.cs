using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEffect : MonoBehaviour
{
    [SerializeField] int _scoreBonus = 10;
    [SerializeField] ItemEffectCategory _itemEffect;

    public int Score
    {
        get { return _scoreBonus; }
    }
    public ItemEffectCategory teachEffect
    { get { return _itemEffect; } }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.tag == "Player")
        //{
        //    Destroy(this.gameObject);
        //}
    }
}
