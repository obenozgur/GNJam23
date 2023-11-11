public static class PoseData
{
    private static Pose[] _poses =
    {
        new Pose(new LimbState[] { LimbState.Down, LimbState.Down, LimbState.Down, LimbState.Down }),
        new Pose(new LimbState[] { LimbState.Down, LimbState.Down, LimbState.Up, LimbState.Down }),
        new Pose(new LimbState[] { LimbState.Down, LimbState.Down, LimbState.Up, LimbState.Up }),
        new Pose(new LimbState[] { LimbState.Down, LimbState.Down, LimbState.Down, LimbState.Up }),
        new Pose(new LimbState[] { LimbState.Down, LimbState.Up, LimbState.Up, LimbState.Up }),
        new Pose(new LimbState[] { LimbState.Up, LimbState.Down, LimbState.Up, LimbState.Down }),
        new Pose(new LimbState[] { LimbState.Up, LimbState.Down, LimbState.Up, LimbState.Up }),
        new Pose(new LimbState[] { LimbState.Up, LimbState.Up, LimbState.Up, LimbState.Up }),
        new Pose(new LimbState[] { LimbState.Down, LimbState.Up, LimbState.Down, LimbState.Up }),
    };

    public static bool IsLimbUp(int poseId, Limb limb)
    {
        return _poses[poseId].IsLimbUp(limb);
    }
    
    public static bool IsLimbDown(int poseId, Limb limb)
    {
        return _poses[poseId].IsLimbDown(limb);
    }
}