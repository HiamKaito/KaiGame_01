using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class PlayerController : MonoBehaviour
{
    [Header("Attack System")]
    [SerializeField] private int _comboCount = 0;
    [SerializeField] private int _maxComboCount = 3;

    private void CheckCombo()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) { Start_Combo(); }
        else { FinishCombo(); }
    }

    public void Start_Combo()
    {
        if (_comboCount < _maxComboCount)
        {
            _comboCount++;
            animator.SetTrigger("Attack_" + _comboCount);
        }
        else { FinishCombo(); }
    }

    public void FinishCombo()
    {
        _comboCount = 0;
    }
}
