/**
 * Procesos a ejecutar antes de lanzar la aplicacion
 */
Ext.onReady(function (){
    this.loadApplication({});
});

/**
 * Carga aplicacion
 * @param {*} configurations - Configuraciones generales de la aplicacion
 */
function loadApplication(configurations){
    Ext.application({
        name: 'StockerDashboard',
        extend: 'StockerDashboard.Application',
    
        /**
         * Dependencias de la aplicacion
         */
        requires: [
            'StockerDashboard.*'
        ],
    
        /**
         * Vista principal de la aplicacion
         */
        mainView: 'StockerDashboard.view.main.Main',
    });
}
