/**
 * Aqui se definen todas las funciones que utiliza la vista principal - modern
 */
Ext.define('StockerDashboard.view.main.MainController', {
    extend: 'Ext.app.ViewController',
    alias: 'controller.main',

    /**
     * Se indica que accion ejecutar al momento de 
     * realizar un cambio en la barra de navegacion
     * localhost#navegacion
     */
    listen : {
        controller: {
            '#' : {
                unmatchedroute : 'onRouteChange'
            }
        }
    },

    /**
     * Indica que accion realizar cuando se selccionada un nodo
     */
    routes: {
        ':node' : 'onRouteChange'
    },

    /**
     * Configuraciones del controlador, estas son configuraciones generales
     * de la vista principal
     */
    config : {
        /**
         * Indica si mostrar la barra de navegacion
         */
        showNavigation : true
    },

    /**
     * Variables globales del controlador
     */
    collapsedCls: 'main-nav-collapsed',

    /**
     * Funcion de inicio de la vista de principal
     * @param {StockerDashboard.view.main.MainController} view - Vista Principal
     */
    init: function(view){
        var me = this,
            references = me.getReferences();

        me.callParent([ view ]);
        me.navigation = references.navigation;
        me.navigationTree = references.navigationTree;
    },

    /**
     * Evento cuando se da click en un item de navegacion.
     * Se mantiene este evento por compatibildad en el uso
     * de dispositivos mobiles
     */
    onNavigationItemClick: function (){

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
    onNavigationTreeSelectionChange: function(tree, node){
        var destination = node && (node.get('routeId') || node.get('viewType'));
        if (destination) this.redirectTo(destination);
    },

    /**
     * Accion que realiza cambio de ruta
     * @param {String} id - Valor de la ruta a realizar cambio
     */
    onRouteChange: function(id){
        this.setCurrentView(id);
    },

    /**
     * Realiza cambio en la propiedad para mostrar la barra de navegacion
     */
    onToggleNavigationSize: function () {
        this.setShowNavigation(!this.getShowNavigation());
    },

    /**
     * Realiza cambio de ruta en la applicacion.
     * Los nodos cuentas con dos propiedades para realizar el cambio de ruta:
     * - routeId
     * - viewType
     * @param {String} destinationId - Clave de la ruta destino
     */
    setCurrentView: function(destinationId){
        destinationId = (destinationId || '').toLowerCase();

        var me = this,
            // Se buscan encuentran referecias a utilizar
            references = me.getReferences(),
            mainContainer = references.mainContainer,
            navigationTree = me.navigationTree,

            // Se obtiene el panel a navegar
            item = mainContainer.child('component[routeId=' + destinationId + ']');

            // Se busca el nodo a seleccionar en el panel de navegacion
            store = navigationTree.getStore(),
            node = store.findNode('routeId', destinationId) || store.findNode('viewType', destinationId);
            
        // Si la vista a el panel a buscar no existe, se crea
        if (!item) {
            try {
                item = Ext.create({
                    xtype: node.get('viewType'),
                    routeId: destinationId,
                });
            } catch (error) {
                return;
            }
        }

        mainContainer.setActiveItem(item);
        navigationTree.setSelection(node);
    },

    /**
     * Actualiza el arbol de navegacion
     * @param {Boolean} newValue - Valor nuevo de la barra de navegacion
     * @param {Boolean} oldValue - Valor anterior de navegacion
     */
    updateShowNavigation: function(newValue, oldValue){

        // Cuando la aplicacion inicia por primera vez esta no contiene un valor 
        // anterior
        if (oldValue === undefined) return;

        var me = this,
            navigation = me.navigation,
            rootEl = me.navigationTree.rootItem.el;

        me.navigation.toggleCls(me.collapsedCls);

        if (newValue)
        // Restaure el texto y otras decoraciones antes de expandirlas 
        // para que se revelen correctamente.
            me.navigationTree.setMicro(false);
        // Asegúrate de que las decoraciones del lado derecho se 
        // recorten apuntalando el ancho del elemento raíz del árbol 
        // mientras estamos colapsados.
        else
            rootEl.setWidth(rootEl.getWidth());
    },

    /**
     * Realiza redireccionamiento a la referencia que tiene 
     * configurado el boton
     * @param {Ext.button.Button} button 
     */
    toolbarButtonClick: function(button){
        this.redirectTo(button.config.href);
    }
});
