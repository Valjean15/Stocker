﻿namespace Models.Sale
{
    using Models.Common;
    using Models.Interfaces;
    using Models.Workflow;
    using Models.Contact;
    using System;
    using System.Collections.Generic;
    using Models.Administration;

    /// <summary>
    ///     Representa una venta, salida de elementos de inventario
    /// </summary>
    public class Sale : EntityBase<int>, IWorkflowState, IUser
    {
        /// <summary>
        ///     Fecha en la que se realiza la venta
        /// </summary>
        public DateTime SaleDate { get; set; }

        /// <summary>
        ///     Total de la venta
        /// </summary>
        public decimal Total { get; set; }

        #region Foreing Keys

        /// <summary>
        ///     Llave foranea de la entidad <see cref="Common.Currency"/>
        /// </summary>
        public int CurrencyId { get; set; }

        /// <summary>
        ///     Llave foranea de la entidad <see cref="Workflow.State"/>
        /// </summary>
        public int StateId { get; set; }

        /// <summary>
        ///     Llave foranea de la entidad <see cref="Contact"/>
        /// </summary>
        public int ContactId { get; set; }

        /// <summary>
        ///     Usuario que genero la venta
        ///     <para>
        ///     Llave foranea de la entidad <see cref="Administration.User"/>
        ///     </para>
        /// </summary>
        public string UserId { get; set; }

        #endregion

        #region Virtual Properties

        /// <summary>
        /// <para>
        ///     Propiedad virtual de la llave foranea de <see cref="CurrencyId"/>
        /// </para>
        /// <para>
        ///     Indica la moneda en que se encuntran los montos de la venta
        /// </para>
        /// </summary>
        public virtual Currency Currency { get; set; }

        /// <summary>
        /// <para>
        ///     Propiedad virtual de la llave foranea de <see cref="StateId"/>
        /// </para>
        /// <para>
        ///     Indica el estado actual de la venta
        /// </para>
        /// </summary>
        public virtual State State { get; set; }

        /// <summary>
        /// <para>
        ///     Propiedad virtual de la llave foranea de <see cref="ContactId"/>
        /// </para>
        /// <para>
        ///     Representa la persona a la cual se le esta realizando la venta
        /// </para>
        /// </summary>
        public virtual Contact Contact { get; set; }

        /// <summary>
        /// <para>
        ///     Propiedad virtual de la llave foranea de <see cref="UserId"/>
        /// </para>
        /// <para>
        ///     Usuario que genero la venta
        /// </para>
        /// </summary>
        public virtual User User { get; set; }

        /// <summary>
        ///     Cuotas asociadas a esta venta
        /// </summary>
        public virtual ICollection<SaleQuota> Quotas { get; set; }

        /// <summary>
        ///     Items realacionados a la venta
        /// </summary>
        public virtual ICollection<SaleItem> Items { get; set; }

        #endregion
    }
}
