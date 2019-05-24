/**
 * Arbol de navegacion de la aplicacion
 */
Ext.define('StockerDashboard.store.NavigationTree', {
    extend: 'Ext.data.TreeStore',

    storeId: 'NavigationTree',
    alias: 'store.navigationTree',

    requires: [
        'StockerDashboard.data.language.*'
    ],

    /**
     * Campos de los items del arbol
     */
    fields: [{
        name: 'text'
    }],

    /**
     * Raiz del arbol
     */
    root: {
        expanded: true,
        /**
         * Elementos de navegacion del arbol
         */
        children: [
            {
                text: Translate.get('dashboard'),
                iconCls: Icon.get('desktop'),
                rowCls: 'nav-tree-badge',
                viewType: 'admindashboard',
                routeId: 'dashboard',
                leaf: true
            },
            {
                text: Translate.get('products'),
                iconCls: Icon.get('archive'),
                viewType: 'productsearch',
                leaf: true
            }
        ]
    }
});
