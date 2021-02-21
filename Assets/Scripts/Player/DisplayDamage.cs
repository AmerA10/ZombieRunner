using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{


    [SerializeField] Canvas damagedCanvas;
    [SerializeField] float damagedTime = 0.3f;
    // Start is called before the first frame update

    private void Awake()
    {
        damagedCanvas.enabled = false;
    }

    void Start()
    {
        
    }

    public void ShowDamageImpact()
    {
        StartCoroutine(ShowBlood());
    }

    private IEnumerator ShowBlood()
    {
        damagedCanvas.enabled = true;
        yield return new WaitForSeconds(damagedTime);
        damagedCanvas.enabled = false;
    }
}
