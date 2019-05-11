namespace DataAccessLayer.Context.Configurations.Workflow
{
    using Models.Workflow;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    ///     Configuraciones de la tabla del histrial de cambios de workflow
    /// </summary>
    internal class FlowLogConfiguration : IEntityTypeConfiguration<FlowLog>
    {
        /// <summary>
        ///     Método llamado para configurar un tipo de entidad.
        /// </summary>
        /// <param name="Builder">
        ///     Constructor que se utilizará para configurar el tipo de entidad.
        /// </param>
        public void Configure(EntityTypeBuilder<FlowLog> Builder)
        {
            Builder.ToTable(nameof(FlowLog), "Workflow");
        }
    }
}
