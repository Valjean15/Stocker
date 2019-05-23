/**
 * Arbol de navegacion de la aplicacion
 */
Ext.define('StockerDashboard.store.NavigationTree', {
    extend: 'Ext.data.TreeStore',

    storeId: 'NavigationTree',

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
                text: 'Dashboard',
                iconCls: 'x-fa fa-desktop',
                rowCls: 'nav-tree-badge',
                viewType: 'admindashboard',
                routeId: 'dashboard',
                leaf: true
            },
            {
                text: 'Products',
                iconCls: 'x-fa fa-box',
                viewType: 'productsearch',
                leaf: true
            },
            /*{
                text: 'Search',
                iconCls: 'x-fa fa-search',
                viewType: 'search',
                leaf: true,
                hidden: true
            }*/
        ]
    }
});
