/*Add an enumeration BatteryType (Li-Ion, NiMH,
 *NiCd, …) and use it as a new field for the batteries.
*/
using System;

namespace AboutPhone
{
    public enum BatteryType
    {
        LiIon, NiMH, NiCd, LiPolymer, not_specified
    }
}
