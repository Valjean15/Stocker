namespace DataAccess.Context.Configurations.Workflow
{
    using Util.Constants;
    using Models.Workflow;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    ///     Configuraciones de la tabla de estados de workflow
    /// </summary>
    internal class StateConfiguration : IEntityTypeConfiguration<State>
    {
        /// <summary>
        ///     Método llamado para configurar un tipo de entidad.
        /// </summary>
        /// <param name="Builder">
        ///     Constructor que se utilizará para configurar el tipo de entidad.
        /// </param>
        public void Configure(EntityTypeBuilder<State> Builder)
        {
            Builder.ToTable(nameof(State), Modules.Workflow);
            Builder.HasKey(state => state.Id);

            Builder.HasOne(state => state.Flow)
                .WithMany(flow => flow.States)
                .HasForeignKey(state => state.FlowId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
