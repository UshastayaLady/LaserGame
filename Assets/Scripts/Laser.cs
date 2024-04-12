using Palmmedia.ReportGenerator.Core.Parser.Analysis;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    static public Laser instance;

    List<LaserGun> lasers = new List<LaserGun>();
    List<GameObject> lines = new List<GameObject>();

    private float maxDistance = 50;
    public GameObject linePrefab;

    public void AddLaser(LaserGun laser) { lasers.Add(laser); }
    public void RemoveLaser(LaserGun laser) { lasers.Remove(laser); }

    void RemovedOldLines(int linesCount)
    {
        if (linesCount < lines.Count)
        {
            Destroy(lines[lines.Count - 1]);
            lines.RemoveAt(lines.Count - 1);
            RemovedOldLines(linesCount);
        }
    }

    void Awake()
    {
        instance = this;      

    }

    // Update is called once per frame
    void Update()
    {
        int linesCount = 0;
        foreach (var laser in lasers)
        {
            linesCount+=CalcLaserLine(laser.transform.position + laser.transform.forward * 0.6f, laser.transform.forward, linesCount);
        }
        RemovedOldLines(linesCount);
    }

    int CalcLaserLine(Vector3 startPosition, Vector3 direction, int index)
    {
        int result = 1;
        RaycastHit hit;
        Ray ray = new Ray(startPosition, direction);
        bool intersect = Physics.Raycast(ray, out hit, maxDistance);

        Vector3 hitPosition = hit.point;

         
        if (!intersect) hitPosition = startPosition + direction * maxDistance;
        DrawLine(startPosition, hitPosition, index);
        if (intersect) 
        {
            result += CalcLaserLine(hitPosition, Vector3.Reflect(direction, hit.normal), index+result);
        }
        

        return result;
    }

    void DrawLine(Vector3 startPosition, Vector3 finishPosition,int index)
    {
        LineRenderer line = null;
        if (index < lines.Count)
        {
            line = lines[index].GetComponent<LineRenderer>();
        }
        else { 

            GameObject go = Instantiate(linePrefab, Vector3.zero, Quaternion.identity);
            line = go.GetComponent<LineRenderer>();
            lines.Add(go);

        }
        
        line.SetPosition(0, startPosition);
        line.SetPosition(1, finishPosition);
      
    }
}
