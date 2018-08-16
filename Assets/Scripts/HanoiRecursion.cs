using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HanoiRecursion : MonoBehaviour
{
    private List<Stack<AbstractDisk>> _hanoiTowers = new List<Stack<AbstractDisk>>();
    private float _delay = 0;
    [SerializeField]
    private AbstractDisk _disksPrefab;

    public int Disks = 4;
    public float AnimationDelay = 0.5f;
    public Action SolvedAction;

    protected void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            _hanoiTowers.Add(new Stack<AbstractDisk>());
        }
    }

    public void Init(int disks)
    {
        Disks = disks;
        for (int diskIndex = Disks - 1; diskIndex > -1; diskIndex--)
        {
            var disk = Instantiate(_disksPrefab, Vector3.zero, Quaternion.identity, transform);
            disk.Init(diskIndex);
            disk.transform.localPosition = Vector3.zero;
            disk.Move(0, Disks - diskIndex);
            StartCoroutine(disk.Draw(0));
            _hanoiTowers[0].Push(disk);
        }

        SolveHanoi(Disks, 0, 1, 2);
    }

    private IEnumerator UpdateHanoi(int disk, int from, int to)
    {
        _delay += AnimationDelay;
        yield return new WaitForSeconds(_delay);
        AbstractDisk d = _hanoiTowers[from].Pop();
        d.Move(to, _hanoiTowers[to].Count + 1);
        StartCoroutine(d.Draw(AnimationDelay));
        _hanoiTowers[to].Push(d);
        yield return new WaitForSeconds(AnimationDelay);
        if (_hanoiTowers[to].Count == Disks)
        {
            if (SolvedAction!=null)
                SolvedAction();
        }
    }
  
    void SolveHanoi(int disk, int fromRod,
                           int toRod, int otherRod)
    {
       
        if (disk == 1)
        {
            StartCoroutine(UpdateHanoi(disk, fromRod, toRod));
            return;
        }

        SolveHanoi(disk - 1, fromRod, otherRod, toRod);
        StartCoroutine(UpdateHanoi(disk, fromRod, toRod));

        SolveHanoi(disk - 1, otherRod, toRod, fromRod);

    }

}
