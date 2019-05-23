/**
 * Controlador para cuando la vista es de un telefono
 */
Ext.define('StockerDashboard.view.phone.main.MainController', {
    extend: 'StockerDashboard.view.main.MainController',
    alias: 'controller.phone-main',

    /**
     * Cls de Slide para el menu de navegacion
     */
    slidOutCls: 'main-nav-slid-out',

    /**
     * Indica si mostrar la barra de navegacion
     */
    showNavigation: false,

    /**
     * Funcion de inicio de la vista principal
     * @param {StockerDashboard.view.main.Main} view - Vista principal
     */
    init: function (view) {
        var me = this;
        me.callParent([ view ]);

        // Remueve del panel de naevgacion el elemento a navegar y se anexa como elemento flotante
        me.navigation.getParent().remove(me.navigation, false);
        me.navigation.addCls(['x-floating', 'main-nav-floated', me.slidOutCls]);
        me.navigation.setScrollable(true);
        me.navigation.getRefOwner = function () {
            return view;
        };
        
        // Agregamos el logo del toolbar a la barra de navegacion
        me.navigation.add(me.logo);
        me.logo.setDocked('top');

        Ext.getBody().appendChild(me.navigation.element);
    },

    /**
     * Evento cuando se da click en un item de navegacion.
     * Se mantiene este evento por compatibildad en el uso
     * de dispositivos mobiles
     * @param {Ext.list.Tree} tree - Menu de la aplicacion
     * @param {*} info 
     */
    onNavigationItemClick: function (tree, info) {
        if (info.select) this.setShowNavigation(false);
    },

    /**
     * Accion que intenta obtener la direcion que redirige un nodo y si 
     * existe la cambia a ello.
     * Los nodos cuentas con dos propiedades para realizar el cambio de ruta:
     * - routeId
     * - viewType
     * @param {Ext.list.Tree} tree - Arbol en donde se encuentra el nodo
     * @param {Ext.list.TreeItem} node - Nodo seleccionado del arbol
     */
    onNavigationTreeSelectionChange: function (tree, node) {
        this.setShowNavigation(false);
        this.callParent(arguments);
    },

    /**
     * Actualiza la vista de navegacion de la aplicacion
     * @param {Boolean} newValue
     * @param {Boolean} oldValue 
     */
    updateShowNavigation: function (newValue, oldValue) {
        if (oldValue == undefined) return;

        var me = this,
            navigation = me.navigation,
            mask = me.mask;

        if (newValue) {
            me.mask = mask = Ext.Viewport.add({
                xtype: 'loadmask',
                userCls: 'main-nav-mask'
            });

            mask.element.on({
                tap: me.onToggleNavigationSize,
                scope: me,
                single: true
            });
        } else if (mask) {
            mask.destroy();
            me.mask = null;
        }

        navigation.toggleCls(me.slidOutCls, !newValue);
    }
});
