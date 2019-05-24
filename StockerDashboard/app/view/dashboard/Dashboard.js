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

            iconCls: Icon.get('shoppingCart'),
            iconFirst: true,
            color: '#9cc96b',
            text: Translate.get('total'),
            description: Translate.get('shopping')
        },
        {
            xtype: 'statustile',
            height: 170,
            userCls: 'big-33 small-50 dashboard-item shadow',

            iconCls: Icon.get('plusCircle'),
            iconFirst: true,
            color: '#167abc',
            text: Translate.get('total'),
            description: Translate.get('sales')
        },
        {
            xtype: 'statustile',
            height: 170,
            userCls: 'big-33 small-50 dashboard-item shadow',

            iconCls: Icon.get('file'),
            iconFirst: true,
            color: '#925e8b',
            text: Translate.get('total'),
            description: Translate.get('stock')
        },
        {
            xtype: 'statustile',
            height: 170,
            userCls: 'big-33 small-50 dashboard-item shadow',

            iconCls: Icon.get('tasks'),
            iconFirst: true,
            color: '#ffc107',
            text: Translate.get('total'),
            description: Translate.get('products')
        }
    ]
});
