using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    [SerializeField] int wheelId;
    public int WheelId => wheelId;

    [SerializeField] List<WheelControl> wheelControls;
    List<WheelControl> _wheelControlsInternal;
    [SerializeField] List<WheelWaypoint> waypoints;

    private void Start()
    {
        _wheelControlsInternal = new(wheelControls);

        //Initial Setup
        /*foreach (var waypoint in waypoints)
        {
            var randomWheelControl = Random.Range(0, _wheelControlsInternal.Count);
            randomWheelControl = 0;
            _wheelControlsInternal[randomWheelControl].SetWaypoint(waypoint);
            _wheelControlsInternal.RemoveAt(randomWheelControl);
        }*/
    }

    public void MoveNext()
    {
        foreach (var wheelControl in wheelControls)
        {
            wheelControl.MoveToPreviousWaypoint();
        }
    }
    public void MovePrev()
    {
        foreach (var wheelControl in wheelControls)
        {
            wheelControl.MoveToNextWaypoint();
        }
    }
}
