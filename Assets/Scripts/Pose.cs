using System;

public class Pose
{
    private const int LimbCount = 4;
    private LimbState[] _poseData = new LimbState[LimbCount];
    
    public Pose(LimbState[] limbStates)
    {
        for (int i = 0; i < LimbCount; i++)
        {
            _poseData[i] = limbStates[i];
        }
    }

    public bool IsLimbUp(Limb limb)
    {
        switch (limb)
        {
            case Limb.LeftArm:
                return _poseData[0] == LimbState.Up;
            case Limb.LeftLeg:
                return _poseData[1] == LimbState.Up;
            case Limb.RightArm:
                return _poseData[2] == LimbState.Up;
            case Limb.RightLeg:
                return _poseData[3] == LimbState.Up;
        }

        return false;
    }
    
    public bool IsLimbDown(Limb limb)
    {
        switch (limb)
        {
            case Limb.LeftArm:
                return _poseData[0] == LimbState.Down;
            case Limb.LeftLeg:
                return _poseData[1] == LimbState.Down;
            case Limb.RightArm:
                return _poseData[2] == LimbState.Down;
            case Limb.RightLeg:
                return _poseData[3] == LimbState.Down;
        }

        return false;
    }
}