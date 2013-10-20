using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantle.MongoDB
{
    public interface IMongoDbConfiguration
    {
        string ConnectionString { get; set; }

        void Validate();
    }
}
