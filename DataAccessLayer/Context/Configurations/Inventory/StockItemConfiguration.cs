﻿namespace DataAccess.Context.Configurations.Inventory
{
    using Util.Constants;
    using Models.Inventory;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    ///     Configuraciones de la tabla de items de inventario
    /// </summary>
    internal class StockItemConfiguration : IEntityTypeConfiguration<StockItem>
    {
        /// <summary>
        ///     Método llamado para configurar un tipo de entidad.
        /// </summary>
        /// <param name="Builder">
        ///     Constructor que se utilizará para configurar el tipo de entidad.
        /// </param>
        public void Configure(EntityTypeBuilder<StockItem> Builder)
        {
            Builder.ToTable(nameof(StockItem), Modules.Inventory);
            Builder.HasKey(stockItem => stockItem.Id);

            Builder.HasOne(stockItem => stockItem.Product)
                .WithMany(product => product.StockItems)
                .HasForeignKey(stockItem => stockItem.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            Builder.HasOne(stockItem => stockItem.Stock)
                .WithMany(stock => stock.Items)
                .HasForeignKey(stockItem => stockItem.StockId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
