using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheButterflyProjectMobileClient.Contracts
{
    public interface IDbInitializer
    {
        void Initialize();
        Task InitializeAsync(CancellationToken cancellationToken = default);
    }
}
