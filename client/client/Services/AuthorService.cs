using client.Core;
using client.Models;
using client.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.Services
{
    class AuthorService
    {
        public static async Task<List<Author>> Browse()
        {
            var res = await Rest.Get<List<AuthorBrowsePartialResponse>>
        }
    }
}
