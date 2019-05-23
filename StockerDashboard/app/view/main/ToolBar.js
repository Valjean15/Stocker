/**
 * Barra de herramientas
 */
Ext.define('StockerDashboard.view.main.Toolbar', {
    extend: 'Ext.Toolbar',
    xtype: 'maintoolbar',

    /**
     * Dependencias del componente
     */
    requires: [
        'Ext.button.Segmented'
    ],

    items: [
        /**
         * Logo de la aplicacion
         */
        {
            xtype: 'component',
            reference: 'logo',
            userCls: 'main-logo',
            html: 'Stocker'
        },
        /**
         * Boton que abre el menu de navegacion
         */
        {
            xtype: 'button',
            ui: 'header',
            iconCls: 'x-fa fa-bars',
            margin: '0 0 0 10',
            listeners: {
                tap: 'onToggleNavigationSize'
            }
        },
        /**
         * Indica que los siguientes elementos se alinearan a la derecha
         */
        '->',
        /**
         * Boton de busqueda
         */
        {
            xtype:'button',
            iconCls:'x-fa fa-search',
        }
    ]
});
