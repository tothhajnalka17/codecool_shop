using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Codecool.CodecoolShop.Models;

namespace Codecool.CodecoolShop.Data
{
    public class CodecoolCodecoolShopContext : DbContext
    {
        public CodecoolCodecoolShopContext (DbContextOptions<CodecoolCodecoolShopContext> options)
            : base(options)
        {
        }

        public DbSet<Codecool.CodecoolShop.Models.Registration> RegistrationModel { get; set; } = default!;
    }
}
