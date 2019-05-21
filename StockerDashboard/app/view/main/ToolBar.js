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
         * Boton que abre el menu de navegacion
         */
        {
            xtype: 'button',
            ui: 'header',
            iconCls: 'x-fa fa-bars',
            margin: '0 0 0 16',
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
