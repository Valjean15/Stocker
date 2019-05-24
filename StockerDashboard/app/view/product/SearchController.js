/**
 * Aqui se definen todas las funciones que utiliza la vista principal - modern
 */
Ext.define('StockerDashboard.view.product.SearchProductController', {
    extend: 'Ext.app.ViewController',
    alias: 'controller.searchProduct',

    /**
     * Funcion de inicio de la vista
     * @param {StockerDashboard.view.product.SearchProductController} view - Vista
     */
    init: function(view){   
        this.callParent([ view ]);
        this.loadProducts();
        this.view = view;
    },

    /**
     * Abre configuraciones de producto
     * @param {Number} id - Id del producto a navegar
     */
    navigateProduct: function(id){
        debugger;
    },

    loadProducts: function(){
        for (let index = 1; index < 11; index++) {
            this.view.add(this.generateLinkedTile({ Name: 'Producto ' + index  }));
        }
    },

    /**
     * Metodos privados del controlador
     */
    privates: {
        
        /**
         * Obtiene un componente aplicando la configuracion brindada
         * @param {Configuration} configuration - Configuraciona a aplicar
         */
        generateLinkedTile: function(configuration){
            return new StockerDashboard.view.widgets.LinkedTile({
                height: 170,
                userCls: 'big-20 small-50 dashboard-item shadow',
                iconCls: Icon.get('archive'),
                color: "#" + Math.random().toString(16).slice(2, 8),
                text: !configuration.Name ? Translate.get('products') : configuration.Name,
                description: !configuration.Description ? '' : configuration.Description
            });
        }
    }
});
