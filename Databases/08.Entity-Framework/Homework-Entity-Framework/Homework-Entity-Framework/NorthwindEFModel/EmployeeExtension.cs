/* By inheriting the Employee entity class create
 * a class which allows employees to access their
 * corresponding territories as property of type 
 * EntitySet<T>.
 */

namespace NorthwindEFModel
{
    using System.Data.Linq;

    public partial class Employee
    {
        public EntitySet<Territory> Territory { get; set; }
    }
}
