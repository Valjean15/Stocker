/**
 * Acciones que ejecuta la vista de inicio
 */
Ext.define('StockerDashboard.view.dashboard.DashboardController', {
    extend: 'Ext.app.ViewController',
    alias: 'controller.dashboard',

    /**
     * Dependencias del controlador
     */
    requires: [
        'Ext.util.TaskRunner'
    ],

    /**
     * Accion de refrescar
     * @param {*} tool 
     * @param {*} event 
     * @param {*} owner 
     */
    onRefreshToggle: function(tool, event, owner) {
    },

    /**
     * Limpia las actualizaciones
     */
    clearChartUpdates : function() {
        this.chartTaskRunner = Ext.destroy(this.chartTaskRunner);
    },
    
    /**
     * Destruye actualizaciones
     */
    destroy: function () {
        this.clearChartUpdates();
        this.callParent();
    },
    
    /**
     * Oculta actualizaiones
     */
    onHideView: function () {
        this.clearChartUpdates();
    }
});
