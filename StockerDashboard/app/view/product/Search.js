/**
 * Vista donde se buscan los productos
 */
Ext.define('StockerDashboard.view.product.search', {
    xtype: 'productsearch',
    extend: 'Ext.Container',

    /**
     * Dependencias de la vista
     */
    requires: [
        'Ext.grid.Grid'
    ],
});
