﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UdeAPI.Core.Models;

namespace UdeAPI.Data.Seeds
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        private readonly int[] _ids;
        public ProductSeed(int[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product
                {
                    Id=1,
                    Name="Pilot Kalem",
                    Price=12.50m,
                    Stock=100,
                    CategoryId=_ids[0]
                },
                new Product
                {
                    Id = 2,
                    Name = "Kurşun Kalem",
                    Price = 40.50m,
                    Stock = 200,
                    CategoryId = _ids[0]
                },
                 new Product
                 {
                     Id = 3,
                     Name = "Tükenmez Kalem",
                     Price = 25.5m,
                     Stock = 300,
                     CategoryId = _ids[0]
                 },
                 new Product
                 {
                     Id = 4,
                     Name = "A4 Defter",
                     Price = 60m,
                     Stock = 150,
                     CategoryId = _ids[1]
                 });
        }
    }
}
