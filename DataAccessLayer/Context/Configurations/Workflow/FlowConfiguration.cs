namespace DataAccessLayer.Context.Configurations.Workflow
{
    using Util.Constants;
    using Models.Workflow;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    ///     Configuraciones de la tabla de workflow
    /// </summary>
    internal class FlowConfiguration : IEntityTypeConfiguration<Flow>
    {
        /// <summary>
        ///     Método llamado para configurar un tipo de entidad.
        /// </summary>
        /// <param name="Builder">
        ///     Constructor que se utilizará para configurar el tipo de entidad.
        /// </param>
        public void Configure(EntityTypeBuilder<Flow> Builder)
        {
            Builder.ToTable(nameof(Flow), Modules.Workflow);
            Builder.HasKey(flow => flow.Id);
        }
    }
}
