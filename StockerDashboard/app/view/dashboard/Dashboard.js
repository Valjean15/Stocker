/**
 * Vista inicial
 */
Ext.define('StockerDashboard.view.dashboard.Dashboard', {
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
        {
            xtype: 'statustile',
            height: 170,
            userCls: 'big-33 small-50 dashboard-item shadow',

            iconCls: 'x-fa fa-shopping-cart',
            iconFirst: true,
            color: '#9cc96b',
            text: 'Total',
            description: 'Shopping'
        },
        {
            xtype: 'statustile',
            height: 170,
            userCls: 'big-33 small-50 dashboard-item shadow',

            iconCls: 'x-fa fa-plus-circle',
            iconFirst: true,
            color: '#167abc',
            text: 'Total',
            description: 'Sales'
        },
        {
            xtype: 'statustile',
            height: 170,
            userCls: 'big-33 small-50 dashboard-item shadow',

            iconCls: 'x-fa fa-file',
            iconFirst: true,
            color: '#925e8b',
            text: 'Total',
            description: 'Stock'
        },
        {
            xtype: 'statustile',
            height: 170,
            userCls: 'big-33 small-50 dashboard-item shadow',

            iconCls: 'x-fa fa-tasks',
            iconFirst: true,
            color: '#ffc107',
            text: 'Total',
            description: 'Incoming'
        }
    ]
});
