/**
 * Vista principal - modern
 */
Ext.define('StockerDashboard.view.main.Main', {
    extend: 'Ext.Container',

    /**
     * Dependencias de la vista
     */
    requires: [
        'Ext.Button',
        'Ext.list.Tree',
        'Ext.navigation.View'
    ],

    /**
     * Controlador de la vista principal - modern
     */
    controller: 'main',

    /**
     * Configuarciones de la vista
     */
    platformConfig: {
        phone: {
            controller: 'phone-main'
        }
    },

    /**
     * Layout de la vista
     */
    layout: 'hbox',

    /**
     * Elementos de la vista
     */
    items: [
        /**
         * Barra de herramientas de la aplicacion
         */
        {
            xtype: 'maintoolbar',
            docked: 'top',
            userCls: 'main-toolbar shadow'
        },
        /**
         * Contenedor del arbol de navegacion
         */
        {
            xtype: 'container',
            userCls: 'main-nav-container',
            reference: 'navigation',
            scrollable: true,
            items: [
                /**
                 * Arbol de navegacion de la aplicacion
                 */
                {
                    xtype: 'treelist',
                    reference: 'navigationTree',
                    ui: 'navigation',
                    store: 'NavigationTree',
                    expanderFirst: false,
                    expanderOnly: false,
                    listeners: {
                        itemclick: 'onNavigationItemClick',
                        selectionchange: 'onNavigationTreeSelectionChange'
                    }
                }
            ]
        },
        /**
         * Contenedor principal de las vistas de la apliacion
         */
        {
            xtype: 'navigationview',
            flex: 1,
            reference: 'mainContainer',
            userCls: 'main-container',
            navigationBar: false
        }
    ]
});
