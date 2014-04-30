using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.Models
{
    public interface ITrainingEvent
    {
        int Id { get; set; }
        string Name { get; set; }
    }
}
