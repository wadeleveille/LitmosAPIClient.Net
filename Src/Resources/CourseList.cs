using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Litmos.API.Resources
{
    [CollectionDataContract(Name = "Courses", Namespace = "")]
    public class CourseList : ListResource<Course> { }
}
