namespace DataAccessLayer.Context.Configurations.Workflow
{
    using Models.Workflow;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    ///     Configuraciones de la tabla de transiciones de workflow
    /// </summary>
    internal class TransitionConfiguration : IEntityTypeConfiguration<Transition>
    {
        /// <summary>
        ///     Método llamado para configurar un tipo de entidad.
        /// </summary>
        /// <param name="Builder">
        ///     Constructor que se utilizará para configurar el tipo de entidad.
        /// </param>
        public void Configure(EntityTypeBuilder<Transition> Builder)
        {
            Builder.ToTable(nameof(Transition), "Workflow");
        }
    }
}
