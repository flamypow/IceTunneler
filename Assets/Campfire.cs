using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Campfire : MonoBehaviour
{
    private Animator campfireAnimator;
    private bool _isLit = false;
    [SerializeField] private Transform associatedCheckpoint;
    [SerializeField] private int checkpointID;

    public int campfireID {get; set;}

    private void OnEnable()
    {
        campfireAnimator = GetComponent<Animator>();
        _isLit = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (!_isLit)
            {
                _isLit = true;
                GameManager.Instance.PlayerHealToFull();
                campfireAnimator.Play("Lit");
                GameManager.Instance.SetCheckpoint(associatedCheckpoint);
                GameManager.Instance.SetCheckpointID(checkpointID);
            }
        }
    }

}
