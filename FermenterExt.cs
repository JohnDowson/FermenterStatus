using System;

namespace FermenterStatus
{
    public static class FermenterExt
    {
        public static int GetFermentationPercentage(this Fermenter fermenter)
        {
            DateTime d = new DateTime(fermenter.m_nview.GetZDO().GetLong("StartTime", 0L));
            if (d.Ticks == 0L)
            {
                return -1;
            }

            return (int)(((ZNet.instance.GetTime() - d).TotalSeconds / (double)fermenter.m_fermentationDuration) * 100);
        }

    }
}
