using UnityEngine;

namespace TestProject {
    public static class ProjectFramerate
    {
        public const int TARGET_FRAMERATE = 120;

        [RuntimeInitializeOnLoadMethod]
        private static void SetupOnInitialization()
        {
            Application.targetFrameRate = TARGET_FRAMERATE;
        }
    }
}
