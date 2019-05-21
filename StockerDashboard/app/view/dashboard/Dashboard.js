/**
 * Vista principal
 */
Ext.define('Admin.view.dashboard.Dashboard', {
    extend: 'Ext.Container',
    xtype: 'admindashboard',

    /**
     * Controlador asociado a la vista
     */
    controller: 'dashboard',

    /**
     * Modelo de datos asociado a la vista
     */
    viewModel: {
        type: 'dashboard'
    },

    cls: 'dashboard',
    scrollable: true,

    /**
     * Elementos de la vista
     */
    items: [
    ]
});
