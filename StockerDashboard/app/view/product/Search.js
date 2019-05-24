/**
 * Vista donde se buscan los productos
 */
Ext.define('StockerDashboard.view.product.Search', {
    xtype: 'productsearch',
    extend: 'Ext.Container',

    /**
     * Controlador de la vista
     */
    controller: 'searchProduct',
    cls: 'dashboard',
    scrollable: true,

    /**
     * Items de la vista
     */
    items: [
    ]
});
