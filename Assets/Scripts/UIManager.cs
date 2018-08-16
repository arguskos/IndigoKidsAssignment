using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private HanoiRecursion _hanoi;
    [SerializeField]
    private InputField _numberOfDisks;

    [SerializeField]
    private GameObject _after;

    public void Solve()
    {
        _hanoi.SolvedAction += OnSolve;
        int disks;
        if (!int.TryParse(_numberOfDisks.text, out disks))
        {
            _numberOfDisks.text = "Только цифры";
        }
        else
        {
            _hanoi.Init(disks);
            _numberOfDisks.transform.parent.gameObject.SetActive(false);
        }
    }

    public void OnSolve()
    {
        _after.gameObject.SetActive(true);
    }

}
